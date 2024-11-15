using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class TeacherService : ITeacherService
{
    private readonly ITeacherDA _teacherDA;

    public TeacherService(ITeacherDA teacherDA)
    {
        _teacherDA = teacherDA;
    }

    public async Task AddAsync(Teacher teacher)
    {
        await _teacherDA.Add(teacher);
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        await _teacherDA.Delete(teacher);
    }

    public async Task<List<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> filter = null)
    {
        return await _teacherDA.GetList(filter);
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        return await _teacherDA.Get(t => t.Id == id);
    }

    public async Task<Teacher> GetByUser(string id)
    {
        return await _teacherDA.GetByUser(id);
    }

    public async Task UpdateAsync(Teacher teacher)
    {
        await _teacherDA.Update(teacher);
    }
}
