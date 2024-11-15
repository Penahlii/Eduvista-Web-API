using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class StudentService : IStudentService
{
    private readonly IStudentDA _studentDA;

    public StudentService(IStudentDA studentDA)
    {
        _studentDA = studentDA;
    }

    public async Task AddAsync(Student student)
    {
        await _studentDA.Add(student);
    }

    public async Task DeleteAsync(Student student)
    {
        await _studentDA.Delete(student);
    }

    public async Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null)
    {
        return await _studentDA.GetList(filter);
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        return await _studentDA.Get(s => s.Id == id);
    }

    public async Task<Student> GetByUser(string id)
    {
        return await _studentDA.GetByUser(id);
    }

    public async Task UpdateAsync(Student student)
    {
        await _studentDA.Update(student);
    }
}
