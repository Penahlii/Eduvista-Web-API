using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface ITeacherService
{
    Task<Teacher> GetByIdAsync(int id);
    Task<List<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> filter = null);
    Task AddAsync(Teacher teacher);
    Task DeleteAsync(Teacher teacher);
    Task UpdateAsync(Teacher teacher);
    Task<Teacher> GetByUser(string id);
}
