using Eduvista.Core.Repository.Abstraction;
using Microsoft.AspNetCore.Identity;

namespace Eduvista.Entities.Entities;

public class CustomIdentityUser : IdentityUser, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
