using Eduvista.Entities.Entities;
using Eduvista.Entities.Enums;

namespace Eduvista.WebAPI.DTOs.ClassControllerDTOs;

public class ClassDTO
{
    public string Name { get; set; }
    public Section Section { get; set; }
    public int NoOfStudents { get; set; }
    public int NoOfSubjects { get; set; }
    public bool Status { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
