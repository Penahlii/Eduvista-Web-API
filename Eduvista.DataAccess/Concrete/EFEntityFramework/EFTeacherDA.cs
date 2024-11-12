using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFTeacherDA : EFEntityRepositoryBase<Teacher, EduvistaDbContext>, ITeacherDA
{
    public EFTeacherDA(EduvistaDbContext context) : base(context) { }
}
