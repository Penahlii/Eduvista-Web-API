using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFParentDA : EFEntityRepositoryBase<Parent, EduvistaDbContext>, IParentDA
{
    public EFParentDA(EduvistaDbContext context) : base(context) { }
}
