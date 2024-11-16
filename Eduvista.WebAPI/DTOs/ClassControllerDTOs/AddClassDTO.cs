using Eduvista.Entities.Enums;

namespace Eduvista.WebAPI.DTOs.ClassControllerDTOs;

public class AddClassDTO
{
    public string Name { get; set; }
    public Section Section { get; set; }
    public int NoOfStudents { get; set; }
    public int NoOfSubjects { get; set; }
    public bool Status { get; set; }
}
