using Eduvista.Entities.Entities;
using System.Linq.Expressions;

namespace Eduvista.Business.Abstraction;

public interface ISubjectService
{
    Task<Subject> GetByIdAsync(int id);
    Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> filter = null);
    Task AddAsync(Subject subject);
    Task DeleteAsync(Subject subject);
    Task UpdateAsync(Subject subject);
    Task<bool> SubjectExistsAsync(string subjectName);
    Task<Subject> GetByName(string subjectName);
}
