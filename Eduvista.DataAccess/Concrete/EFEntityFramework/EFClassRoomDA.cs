using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFClassRoomDA : EFEntityRepositoryBase<ClassRoom, EduvistaDbContext>, IClassRoomDA
{
    public EFClassRoomDA(EduvistaDbContext context) : base(context) { }
}
