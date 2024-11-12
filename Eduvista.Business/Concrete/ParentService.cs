using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class ParentService : IParentService
{
    private readonly IParentDA _parentDA;

    public ParentService(IParentDA parentDA)
    {
        _parentDA = parentDA;
    }

    public async Task AddAsync(Parent parent)
    {
        await _parentDA.Add(parent);
    }

    public async Task DeleteAsync(Parent parent)
    {
        await _parentDA.Delete(parent);
    }

    public async Task<List<Parent>> GetAllAsync(Expression<Func<Parent, bool>> filter = null)
    {
        return await _parentDA.GetList(filter);
    }

    public async Task<Parent> GetByIdAsync(int id)
    {
        return await _parentDA.Get(p => p.Id == id);
    }

    public async Task UpdateAsync(Parent parent)
    {
        await _parentDA.Update(parent);
    }
}
