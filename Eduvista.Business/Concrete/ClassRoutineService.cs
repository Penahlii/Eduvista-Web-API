using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class ClassRoutineService : IClassRoutineService
{
    private readonly IClassRoutineDA _classRoutineDA;

    public ClassRoutineService(IClassRoutineDA classRoutineDA)
    {
        _classRoutineDA = classRoutineDA;
    }

    public async Task AddAsync(ClassRoutine classRoutine)
    {
        await _classRoutineDA.Add(classRoutine);
    }

    public async Task DeleteAsync(ClassRoutine classRoutine)
    {
        await _classRoutineDA.Delete(classRoutine);
    }

    public async Task<List<ClassRoutine>> GetAllAsync(Expression<Func<ClassRoutine, bool>> filter = null)
    {
        return await _classRoutineDA.GetList(filter);
    }

    public async Task<ClassRoutine> GetByIdAsync(int id)
    {
        return await _classRoutineDA.Get(cr =>  cr.Id == id);
    }

    public async Task UpdateAsync(ClassRoutine classRoutine)
    {
        await _classRoutineDA.Update(classRoutine);
    }
}
