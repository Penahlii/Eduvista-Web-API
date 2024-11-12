using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IParentService
{
    Task<Parent> GetByIdAsync(int id);
    Task<List<Parent>> GetAllAsync(Expression<Func<Parent, bool>> filter = null);
    Task AddAsync(Parent parent);
    Task DeleteAsync(Parent parent);
    Task UpdateAsync(Parent parent);
}
