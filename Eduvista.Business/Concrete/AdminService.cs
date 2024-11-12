using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class AdminService : IAdminService
{
    private readonly IAdminDA _adminDA;

    public AdminService(IAdminDA adminDA)
    {
        _adminDA = adminDA;
    }

    public async Task AddAsync(Admin admin)
    {
        await _adminDA.Add(admin);
    }

    public async Task DeleteAsync(Admin admin)
    {
        await _adminDA.Delete(admin);
    }

    public async Task<List<Admin>> GetAllAsync(Expression<Func<Admin, bool>> filter = null)
    {
        return await _adminDA.GetList(filter);
    }

    public async Task<Admin> GetByIdAsync(int id)
    {
        return await _adminDA.Get(a => a.Id == id);
    }

    public async Task UpdateAsync(Admin admin)
    {
        await _adminDA.Update(admin);
    }
}
