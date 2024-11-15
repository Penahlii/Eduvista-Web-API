using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFStudentDA : EFEntityRepositoryBase<Student, EduvistaDbContext>, IStudentDA
{
    public EFStudentDA(EduvistaDbContext context) : base(context) { }

    public async Task<Student> GetByUser(string id)
    {
        return await GetDbSet().FirstOrDefaultAsync(s => s.User.Id == id);
    }
}
