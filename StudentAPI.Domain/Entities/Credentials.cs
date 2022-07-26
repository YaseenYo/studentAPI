using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentAPI.Domain.Entities
{
	[BsonIgnoreExtraElements]
	public class Credentials
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = String.Empty;

		public string Email { get; set; } = String.Empty;

		public string Password { get; set; } = String.Empty;

		public string StudentId { get; set; } = String.Empty;
	}
}

