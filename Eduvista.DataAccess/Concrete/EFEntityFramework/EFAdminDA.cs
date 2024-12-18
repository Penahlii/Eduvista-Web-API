﻿using Eduvista.Core.Repository.DataAccess.EntityFramework;
using Eduvista.DataAccess.Abstraction;
using Eduvista.Entities.Data;
using Eduvista.Entities.Entities;

namespace Eduvista.DataAccess.Concrete.EFEntityFramework;

public class EFAdminDA : EFEntityRepositoryBase<Admin, EduvistaDbContext>, IAdminDA
{
    public EFAdminDA(EduvistaDbContext context) : base(context) { }
}
