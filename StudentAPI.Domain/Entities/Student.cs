using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentAPI.Domain.Entities
{
	[BsonIgnoreExtraElements]
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = String.Empty;

		public string Name { get; set; } = String.Empty;

		public string Usn { get; set; } = String.Empty;

		public string Img { get; set; } = String.Empty;

		public string Branch { get; set; } = String.Empty;

		public string Email { get; set; } = String.Empty;

		public long Phone { get; set; }

		public string Sslc { get; set; } = String.Empty;

		public string Puc { get; set; } = String.Empty;

		public string Cgpa { get; set; } = String.Empty;

		public string Backlog { get; set; } = String.Empty;

		public List<CompanyDrive> Applied { get; set; } = new List<CompanyDrive>();
	}
}

