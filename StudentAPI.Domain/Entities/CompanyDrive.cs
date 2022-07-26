using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class CompanyDrive
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string CompanyName { get; set; } = String.Empty;

        public float Package { get; set; }

        public string applied { get; set; } = String.Empty;

        public string LastDateToApply { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;

        public Double Eligibility { get; set; }

        public string Description { get; set; } = String.Empty;
    }
}

