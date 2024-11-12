using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IAdminService
{
    Task<Admin> GetByIdAsync(int id);
    Task<List<Admin>> GetAllAsync(Expression<Func<Admin, bool>> filter = null);
    Task AddAsync(Admin admin);
    Task DeleteAsync(Admin admin);
    Task UpdateAsync(Admin admin);
}
