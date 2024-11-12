using Eduvista.Core.Repository.Abstraction;

namespace Eduvista.Entities.Entities;

public class Parent : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    // Relationship with StudentUser
    public string StudentId { get; set; }
    public Student Student { get; set; }
}
