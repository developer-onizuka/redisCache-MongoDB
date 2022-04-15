using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Employee.Models
{
	public class EmployeeEntity
        {
		[BsonId]
                [BsonRepresentation(BsonType.ObjectId)]
                public string Id { get; set; }
                //public ObjectId Id { get; set; }
                public int EmployeeID { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
        }
}
