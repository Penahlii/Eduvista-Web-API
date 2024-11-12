using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface IClassRoomService
{
    Task<ClassRoom> GetByIdAsync(int id);
    Task<List<ClassRoom>> GetAllAsync(Expression<Func<ClassRoom, bool>> filter = null);
    Task AddAsync(ClassRoom classRoom);
    Task DeleteAsync(ClassRoom classRoom);
    Task UpdateAsync(ClassRoom classRoom);
}
