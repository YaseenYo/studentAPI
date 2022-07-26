using System;
using MongoDB.Driver;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Services
{
	public class StudentRepository : IStudentRepository
	{
        protected readonly IMongoCollection<Student> _collection;

        public StudentRepository(ICollegeDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Student>(settings.StudentCollectionName);
        }


        public async Task<Student> GetStudentByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateStudentAsync(string id, Student Student)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, Student);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<Student> AddAsync(Student entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteStudent(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

