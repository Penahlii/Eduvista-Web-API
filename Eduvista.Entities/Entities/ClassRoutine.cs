using Eduvista.Core.Repository.Abstraction;

namespace Eduvista.Entities.Entities;

public class ClassRoutine : IEntity
{
    public int Id { get; set; }
    public string Section { get; set; }
    public string Day { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Status { get; set; }

    // Relationships

    public string TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; }
}
