using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFClassRoutineDA : EFEntityRepositoryBase<ClassRoutine, EduvistaDbContext>, IClassRoutineDA
{
    public EFClassRoutineDA(EduvistaDbContext context) : base(context) { }
}
