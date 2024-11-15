using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFTeacherDA : EFEntityRepositoryBase<Teacher, EduvistaDbContext>, ITeacherDA
{
    public EFTeacherDA(EduvistaDbContext context) : base(context) { }

    public async Task<Teacher> GetByUser(string id)
    {
        return await GetDbSet().SingleOrDefaultAsync(t => t.User.Id == id);
    }
}
