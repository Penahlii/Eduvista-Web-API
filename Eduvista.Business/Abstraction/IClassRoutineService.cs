using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IClassRoutineService
{
    Task<ClassRoutine> GetByIdAsync(int id);
    Task<List<ClassRoutine>> GetAllAsync(Expression<Func<ClassRoutine, bool>> filter = null);
    Task AddAsync(ClassRoutine classRoutine);
    Task DeleteAsync(ClassRoutine classRoutine);
    Task UpdateAsync(ClassRoutine classRoutine);
}
