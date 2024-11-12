using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFClassDA : EFEntityRepositoryBase<Class, EduvistaDbContext>, IClassDA
{
    public EFClassDA(EduvistaDbContext context) : base(context) { }
}
