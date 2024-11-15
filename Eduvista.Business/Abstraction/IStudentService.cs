using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IStudentService
{
    Task<Student> GetByIdAsync(int id);
    Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null);
    Task AddAsync(Student student);
    Task DeleteAsync(Student student);
    Task UpdateAsync(Student student);
    Task<Student> GetByUser(string id);
}
