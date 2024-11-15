using Eduvista.Business.Abstraction;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Concrete;

public class SubjectService : ISubjectService
{
    private readonly ISubjectDA _subjectDA;

    public SubjectService(ISubjectDA subjectDA)
    {
        _subjectDA = subjectDA;
    }

    public async Task AddAsync(Subject subject)
    {
        await _subjectDA.Add(subject);
    }

    public async Task DeleteAsync(Subject subject)
    {
        await _subjectDA.Delete(subject);
    }

    public async Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> filter = null)
    {
        return await _subjectDA.GetList(filter);
    }

    public async Task<Subject> GetByIdAsync(int id)
    {
        return await _subjectDA.Get(s => s.Id == id);
    }

    public async Task<Subject> GetByName(string subjectName)
    {
        return await _subjectDA.GetByName(subjectName);
    }

    public async Task<bool> SubjectExistsAsync(string subjectName)
    {
        return await _subjectDA.SubjectExistsAsync(subjectName);
    }

    public async Task UpdateAsync(Subject subject)
    {
        await _subjectDA.Update(subject);
    }
}
