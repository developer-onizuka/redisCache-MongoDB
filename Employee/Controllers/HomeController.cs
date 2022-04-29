using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Employee.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Employee.Controllers
{
    	public class HomeController : Controller
    	{
		private readonly ILogger<HomeController> _logger;
    		private IMongoCollection<EmployeeEntity> collection;
		private EmployeeEntity key = new EmployeeEntity() {};
		private readonly IWebHostEnvironment hostingEnvironment;
		IDatabase cache = Connection.GetDatabase();
		private int cacheLine = 5;
		private int redisTTL = 30;

        	public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
   		{
			hostingEnvironment = environment;
			var ipaddr = Environment.GetEnvironmentVariable("MONGO");
			if (string.IsNullOrEmpty(ipaddr))
		       	{
				ipaddr = "127.0.0.1:27017";
			}	
			ipaddr = ipaddr.Replace("mongodb://","");
			string connectionString = "mongodb://" + ipaddr;
			MongoClient client = new MongoClient(connectionString);
			IMongoDatabase db = client.GetDatabase("mydb");
			collection = db.GetCollection<EmployeeEntity>("Employee");

			var envCacheLine = Environment.GetEnvironmentVariable("REDIS_CACHELINE");
			if (!string.IsNullOrEmpty(envCacheLine))
		       	{
				try
				{
					cacheLine = Convert.ToInt32(envCacheLine);
				}
				catch (FormatException exception)
				{
					cacheLine = 5;
					Console.WriteLine("Exceptional Error: {0} Set as default value.", exception.Message);
				}
			}	
			var envTTL = Environment.GetEnvironmentVariable("REDIS_TTL");
			if (!string.IsNullOrEmpty(envTTL))
			{
				try 
				{
					redisTTL = Convert.ToInt32(envTTL);
				}
				catch (FormatException exception)
				{
					redisTTL = 30;
					Console.WriteLine("Exceptional Error: {0} Set as default value.", exception.Message);
				}
			}

            		_logger = logger;
    		}

		private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
		{
			var ipaddr = Environment.GetEnvironmentVariable("REDIS");
			if (string.IsNullOrEmpty(ipaddr))
		       	{
				ipaddr = "127.0.0.1:6379";
			}
			var passwd = Environment.GetEnvironmentVariable("REDIS_PASSWD");
			string connectionString = ipaddr + ",password=" + passwd;

			return ConnectionMultiplexer.Connect(connectionString);
        	});

        	public static ConnectionMultiplexer Connection
        	{
            		get
            		{
               			return lazyConnection.Value;
            		}
        	}

		public void WriteCache(EmployeeEntity entity)
		{
			string json = JsonConvert.SerializeObject(entity);
			cache.StringSet(entity.EmployeeID.ToString(), json);
			cache.KeyExpire(entity.EmployeeID.ToString(), new TimeSpan(0,0,redisTTL));
		}

		public void BurstWriteCacheSync(EmployeeEntity entity, int Num)
		{
			int Size = (int)collection.CountDocuments(x=>true);
			for (int i=entity.EmployeeID; (i < entity.EmployeeID+Num) && (i <= Size); i++)
			{
				EmployeeEntity burstEntity = collection.Find(x => x.EmployeeID == i).FirstOrDefault();
				string json = JsonConvert.SerializeObject(burstEntity);
				cache.StringSet(burstEntity.EmployeeID.ToString(), json);
				cache.KeyExpire(burstEntity.EmployeeID.ToString(), new TimeSpan(0,0,redisTTL));
			}
		}

		public void BurstWriteCacheAsync(EmployeeEntity entity, int Num)
		{
			var transaction = cache.CreateTransaction();
			var burstList = collection.Find(x => x.EmployeeID >= entity.EmployeeID 
					                  && x.EmployeeID < entity.EmployeeID+Num).ToList();
			foreach (EmployeeEntity item in burstList)
			{
				string json = JsonConvert.SerializeObject(item);
				transaction.StringSetAsync(item.EmployeeID.ToString(), json);
				transaction.KeyExpireAsync(item.EmployeeID.ToString(), new TimeSpan(0,0,redisTTL));
			}
			transaction.ExecuteAsync();
		}

		public void RemoveCache(EmployeeEntity entity)
		{
			cache.KeyDelete(entity.EmployeeID.ToString());
		}

		public void UploadFile(IFormFile postedFile, EmployeeEntity emp)
		{
		        if(postedFile != null)
                        {
                                string fileName = Path.GetFileName(postedFile.FileName);
                                //string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                                string uploads = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/uploads");
                                string filePath = Path.Combine(uploads, fileName);
			        if (!Directory.Exists(uploads))
				{
					Directory.CreateDirectory(uploads);
				}
                                postedFile.CopyTo(new FileStream(filePath, FileMode.Create));

				// Add in your code System.IO.File.OpenRead instead of File.OpenRead with MVC.
                                using (FileStream fs = System.IO.File.OpenRead(filePath))
                                {
                                        byte[] bs = new byte[fs.Length];
                                        fs.Read(bs, 0, bs.Length);
                                        emp.Image = bs;
                                }
                        }
		}

		public IActionResult Index()
		{
			int Size = (int)collection.CountDocuments(x=>true);
			ViewBag.Size = Size.ToString();
			var model = collection.Find(a=>true).SortBy(a=>a.EmployeeID).Limit(20).ToList();
			return View(model);
		}

		[HttpGet]
		public IActionResult Search()
		{
			return View(key);
		}

		[HttpPost]
		public IActionResult Search(EmployeeEntity emp)
		{
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

			string Jemp = cache.StringGet(emp.EmployeeID.ToString());

			if (string.IsNullOrEmpty(Jemp)) {
				if (collection.CountDocuments(e => e.EmployeeID == emp.EmployeeID) > 0)
				{
					EmployeeEntity empFind = collection.Find(e => e.EmployeeID == emp.EmployeeID).FirstOrDefault();
					//WriteCache(empFind);
					//BurstWriteCacheSync(empFind,cacheLine);
					BurstWriteCacheAsync(empFind,cacheLine);
					Jemp = cache.StringGet(empFind.EmployeeID.ToString());
					ViewBag.Message = "RedisCache Miss and Data is from MongoDB";
					ViewBag.Color = "blue";
				}
				else
			       	{
					Jemp = "{\"Id\":\"\",\"EmployeeID\":" + emp.EmployeeID + " ,\"FirstName\":\"\",\"LastName\":\"\"}";
				}
			}
			else
			{
				ViewBag.Message = "RedisCache Hit";
				ViewBag.Color = "red";
			}

			key = JsonConvert.DeserializeObject<EmployeeEntity>(Jemp);

			sw.Stop();
			ViewBag.Time = sw.ElapsedMilliseconds.ToString();

			return View(key);
		}

		[HttpGet]
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Insert(IFormFile postedFile, EmployeeEntity emp)
		{
			UploadFile(postedFile, emp);
			collection.InsertOne(emp);

			TempData["Message"] = "Employee added successfully!";

			//WriteCache(emp);
			//BurstWriteCacheSync(emp,cacheLine);
			BurstWriteCacheAsync(emp,cacheLine);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(string id)
		{
			EmployeeEntity emp = collection.Find(e => e.Id == id).FirstOrDefault();

			return View(emp);
		}

		[HttpPost]
		public IActionResult Update(IFormFile postedFile, EmployeeEntity emp)
		{
			UploadFile(postedFile, emp);

			var filter = Builders<EmployeeEntity>.Filter.Eq("Id", emp.Id);
			var updateDef = Builders<EmployeeEntity>.Update.Set("FirstName", emp.FirstName)
								       .Set("LastName", emp.LastName)
								       .Set("Image", emp.Image);
			var result = collection.UpdateOne(filter, updateDef);

			if (result.IsAcknowledged)
			{
				TempData["Message"] = "Employee updated successfully!";
			}
			else
			{
				TempData["Message"] = "Error while updating Employee!";
			}

			//WriteCache(emp);
			//BurstWriteCacheSync(emp,cacheLine);
			BurstWriteCacheAsync(emp,cacheLine);

			return RedirectToAction("Index");
		}

		public IActionResult ConfirmDelete(string id)
		{
			EmployeeEntity emp = collection.Find(e => e.Id == id).FirstOrDefault();
			return View(emp);
		}

		[HttpPost]
		public IActionResult Delete(EmployeeEntity emp)
		{
			RemoveCache(emp);
			var result = collection.DeleteOne<EmployeeEntity> (e => e.Id == emp.Id);
			if (result.IsAcknowledged)
			{
				TempData["Message"] = "Employee deleted successfully!";
			}
			else
			{
				TempData["Message"] = "Error while deleting Employee!";
			}

			return RedirectToAction("Index");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
