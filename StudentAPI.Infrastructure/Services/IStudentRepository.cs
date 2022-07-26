using System;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Services
{
	public interface IStudentRepository
	{
		Task<Student> GetStudentByIdAsync(string id);
		Task UpdateStudentAsync(string id, Student Student);
		Task<Student> AddAsync(Student entity);
		Task<IEnumerable<Student>> GetAll();
		Task DeleteStudent(string id);
	}
}

