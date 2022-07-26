using System;
namespace StudentAPI.Infrastructure
{
	public interface ICollegeDbSettings
	{
        string StudentCollectionName { get; set; }
        string CredentialsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

