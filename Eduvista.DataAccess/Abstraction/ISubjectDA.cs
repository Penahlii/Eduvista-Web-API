using Eduvista.Core.Repository.DataAccess;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Abstraction;

public interface ISubjectDA : IEntityRepository<Subject>
{
    Task<bool> SubjectExistsAsync(string subjectName);
    Task<Subject> GetByName(string subjectName);
}
