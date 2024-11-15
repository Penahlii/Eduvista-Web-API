using Eduvista.Core.Repository.Abstraction;

namespace Eduvista.Entities.Entities;

public class Subject : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
