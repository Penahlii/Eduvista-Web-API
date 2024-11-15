using Eduvista.Core.Repository.DataAccess;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Abstraction;

public interface IStudentDA : IEntityRepository<Student>
{
    Task<Student> GetByUser(string id);
}
