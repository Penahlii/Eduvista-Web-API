using Eduvista.Core.Repository.Abstraction;

namespace Eduvista.Entities.Entities;

public class ClassRoom : IEntity
{
    public int Id { get; set; }
    public string RoomNo { get; set; }
    public int Capacity { get; set; }
    public bool Status { get; set; }

    // Relationship with ClassRoutine
    public ICollection<ClassRoutine> ClassRoutines { get; set; } = new List<ClassRoutine>();
}
