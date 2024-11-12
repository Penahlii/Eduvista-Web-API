using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFStudentDA : EFEntityRepositoryBase<Student, EduvistaDbContext>, IStudentDA
{
    public EFStudentDA(EduvistaDbContext context) : base(context) { }
}
