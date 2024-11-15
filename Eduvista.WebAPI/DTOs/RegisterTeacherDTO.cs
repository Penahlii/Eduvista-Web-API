using Eduvista.Entities.Enums;

namespace Eduvista.WebAPI.DTOs;

public class RegisterTeacherDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ClassName { get; set; }
    public string SubjectName { get; set; }
    public Gender Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateOfJoining { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }

    // Pan Number Malicious
    public bool Status { get; set; }
}
