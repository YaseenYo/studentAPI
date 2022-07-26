using System;
using MongoDB.Driver;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Services
{
	public class CredentialsRepository : ICredentialsRepository
	{
        protected readonly IMongoCollection<Credentials> _collection;

        public CredentialsRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Credentials>(settings.CredentialsCollectionName);
        }


        public async Task<Credentials> GetCredentialsByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCredentialsAsync(string id, Credentials Credentials)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, Credentials);
        }

        public async Task<IEnumerable<Credentials>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<Credentials> AddAsync(Credentials entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteCredentials(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

