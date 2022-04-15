using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
		IDatabase cache = Connection.GetDatabase();
		private int ttl = 30;
		private EmployeeEntity key = new EmployeeEntity() {};

        	public HomeController(ILogger<HomeController> logger)
   		{
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

            		_logger = logger;
    		}

		private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
		{
			var ipaddr = Environment.GetEnvironmentVariable("REDIS");
			if (string.IsNullOrEmpty(ipaddr))
		       	{
				ipaddr = "127.0.0.1:6379";
			}
			var passwd = Environment.GetEnvironmentVariable("PASSWD");
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


		public IActionResult Index()
		{
			var model = collection.Find(a=>true).ToList();
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
			string Jemp = cache.StringGet(emp.EmployeeID.ToString());
			//Console.WriteLine(collection.CountDocuments(e => e.EmployeeID == emp.EmployeeID));
			
			if (string.IsNullOrEmpty(Jemp)) {
				if (collection.CountDocuments(e => e.EmployeeID == emp.EmployeeID) > 0)
				{
					EmployeeEntity empFind = collection.Find(e => e.EmployeeID == emp.EmployeeID).FirstOrDefault();
					Jemp = JsonConvert.SerializeObject(empFind);
					cache.StringSet(empFind.EmployeeID.ToString(), Jemp);
					cache.KeyExpire(empFind.EmployeeID.ToString(), new TimeSpan(0,0,ttl));
					Jemp = cache.StringGet(empFind.EmployeeID.ToString());
					ViewBag.Message = "RedisCache Miss and Data is from MongoDB";
					ViewBag.Color = "blue";
				}
				else
			       	{
					Jemp = "{\"Id\":\"null\",\"EmployeeID\":" + emp.EmployeeID + ",\"FirstName\":\"null\",\"LastName\":\"null\"}";
				}
			}
			else
			{
				ViewBag.Message = "RedisCache Hit";
				ViewBag.Color = "red";
			}

			key = JsonConvert.DeserializeObject<EmployeeEntity>(Jemp);
			return View(key);
		}

		[HttpGet]
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Insert(EmployeeEntity emp)
		{
			collection.InsertOne(emp);
			//Console.WriteLine("Employee added: " + emp.FirstName + " " +  emp.LastName);
			//Console.WriteLine(emp.Id);

			TempData["Message"] = "Employee added successfully!";

			string Jemp = JsonConvert.SerializeObject(emp);
			cache.StringSet(emp.EmployeeID.ToString(), Jemp);
			cache.KeyExpire(emp.EmployeeID.ToString(), new TimeSpan(0,0,ttl));

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(string id)
		{
			//ObjectId oId = new ObjectId(id);
			string oId = id;
			EmployeeEntity emp = collection.Find(e => e.Id == oId).FirstOrDefault();

			return View(emp);
		}

		[HttpPost]
		public IActionResult Update(string id,EmployeeEntity emp)
		{
			//emp.Id = new ObjectId(id);
			emp.Id = id;
			Console.WriteLine(emp.Id);
			var filter = Builders<EmployeeEntity>.Filter.Eq("Id", emp.Id);
			//var updateDef = Builders<EmployeeEntity>.Update.Set("FirstName", emp.FirstName);
			//updateDef = updateDef.Set("LastName", emp.LastName);
			var updateDef = Builders<EmployeeEntity>.Update.Set("FirstName", emp.FirstName)
								       .Set("LastName", emp.LastName);
			var result = collection.UpdateOne(filter, updateDef);

			if (result.IsAcknowledged)
			{
				TempData["Message"] = "Employee updated successfully!";
			}
			else
			{
				TempData["Message"] = "Error while updating Employee!";
			}

			string Jemp = JsonConvert.SerializeObject(emp);
			cache.StringSet(emp.EmployeeID.ToString(), Jemp);
			cache.KeyExpire(emp.EmployeeID.ToString(), new TimeSpan(0,0,ttl));

			return RedirectToAction("Index");
		}

		public IActionResult ConfirmDelete(string id)
		{
			//ObjectId oId = new ObjectId(id);
			string oId = id;
			EmployeeEntity emp = collection.Find(e => e.Id == oId).FirstOrDefault();
			return View(emp);
		}

		[HttpPost]
		public IActionResult Delete(string id)
		{
			//ObjectId oId = new ObjectId(id);
			string oId = id;
			var result = collection.DeleteOne<EmployeeEntity> (e => e.Id == oId);
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
