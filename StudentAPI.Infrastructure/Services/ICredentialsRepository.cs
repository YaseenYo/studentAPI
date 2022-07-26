using System;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Services
{
	public interface ICredentialsRepository
	{
		Task<Credentials> GetCredentialsByIdAsync(string id);
		Task UpdateCredentialsAsync(string id, Credentials Credentials);
		Task<Credentials> AddAsync(Credentials entity);
		Task<IEnumerable<Credentials>> GetAll();
		Task DeleteCredentials(string id);
	}
}

