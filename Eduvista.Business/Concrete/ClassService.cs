using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class ClassService : IClassService
{
    private readonly IClassDA _classDA;

    public ClassService(IClassDA classDA)
    {
        _classDA = classDA;
    }

    public async Task AddAsync(Class Class)
    {
        await _classDA.Add(Class);
    }

    public async Task DeleteAsync(Class Class)
    {
        await _classDA.Delete(Class);
    }

    public async Task<List<Class>> GetAllAsync(Expression<Func<Class, bool>> filter = null)
    {
        return await _classDA.GetList(filter);
    }

    public async Task<Class> GetByIdAsync(int id)
    {
        return await _classDA.Get(c => c.Id == id);
    }

    public async Task UpdateAsync(Class Class)
    {
        await _classDA.Update(Class);
    }
}
