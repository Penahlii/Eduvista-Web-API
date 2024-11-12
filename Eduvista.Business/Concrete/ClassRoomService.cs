using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class ClassRoomService : IClassRoomService
{
    private readonly IClassRoomDA _classRoomDA;

    public ClassRoomService(IClassRoomDA classRoomDA)
    {
        _classRoomDA = classRoomDA;
    }

    public async Task AddAsync(ClassRoom classRoom)
    {
        await _classRoomDA.Add(classRoom);
    }

    public async Task DeleteAsync(ClassRoom classRoom)
    {
        await _classRoomDA.Delete(classRoom);
    }

    public async Task<List<ClassRoom>> GetAllAsync(Expression<Func<ClassRoom, bool>> filter = null)
    {
        return await _classRoomDA.GetList(filter);
    }

    public async Task<ClassRoom> GetByIdAsync(int id)
    {
        return await _classRoomDA.Get(cr => cr.Id == id);
    }

    public async Task UpdateAsync(ClassRoom classRoom)
    {
        await _classRoomDA.Update(classRoom);
    }
}
