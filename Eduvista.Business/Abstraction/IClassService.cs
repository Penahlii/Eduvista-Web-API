using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IClassService
{
    Task<Class> GetByIdAsync(int id);
    Task<List<Class>> GetAllAsync(Expression<Func<Class, bool>> filter = null);
    Task AddAsync(Class Class);
    Task DeleteAsync(Class Class);
    Task UpdateAsync(Class Class);
}
