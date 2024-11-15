using Eduvista.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Eduvista.WebAPI.DTOs;

public class RegisterStudentDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Sector { get; set; }
    public string CurrentAddress { get; set; }
    public string ContactNumber { get; set; }
}
