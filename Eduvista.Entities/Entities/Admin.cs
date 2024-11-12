using Eduvista.Core.Repository.Abstraction;

namespace Eduvista.Entities.Entities;

public class Admin : IEntity
{
    public int Id { get; set; }
    public DateTime DateOfJoining { get; set; }
    public CustomIdentityUser? User { get; set; }
}
