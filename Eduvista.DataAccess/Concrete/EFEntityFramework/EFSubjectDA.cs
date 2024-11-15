using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFSubjectDA : EFEntityRepositoryBase<Subject, EduvistaDbContext>, ISubjectDA
{
    public EFSubjectDA(EduvistaDbContext context) : base(context) { }

    public async Task<Subject> GetByName(string subjectName)
    {
        return await GetDbSet().SingleOrDefaultAsync(s => s.Name == subjectName);
    }

    public async Task<bool> SubjectExistsAsync(string subjectName)
    {
        return await GetDbSet().AnyAsync(s => s.Name == subjectName);
    }
}
