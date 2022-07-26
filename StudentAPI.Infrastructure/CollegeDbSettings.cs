using System;
namespace StudentAPI.Infrastructure
{
	public class CollegeDbSettings : ICollegeDbSettings
	{
        public string StudentCollectionName { get; set; } = String.Empty;

        public string CredentialsCollectionName { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}

