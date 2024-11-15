using Eduvista.Business.Abstraction;
using Eduvista.Entities.Entities;
using Eduvista.WebAPI.Consts;
using Eduvista.WebAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eduvista.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    // Services

    private readonly IStudentService _studentService;
    private readonly ISubjectService _subjectService;
    private readonly ITeacherService _teacherService;

    public AuthController(UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IStudentService studentService, ISubjectService subjectService, ITeacherService teacherService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _studentService = studentService;
        _subjectService = subjectService;
        _teacherService = teacherService;
    }

    [HttpPost("RegisterStudent")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDTO model)
    {
        var user = new CustomIdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.ContactNumber,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        if (!await _roleManager.RoleExistsAsync(RoleConstants.StudentRole))
            await _roleManager.CreateAsync(new IdentityRole(RoleConstants.StudentRole));

        await _userManager.AddToRoleAsync(user, RoleConstants.StudentRole);

        var student = new Student
        {
            AdmissionNumber = user.Id, // can be modified
            AdmissionDate = DateTime.UtcNow,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            Status = true,
            Sector = model.Sector, // can be modified
            CurrentAddress = model.CurrentAddress,
            User = user,
        };

        await _studentService.AddAsync(student);

        return Ok("Student added successfully");
    }

    [HttpPost("RegisterTeacher")]
    public async Task<IActionResult> RegisterTeacher([FromBody] RegisterTeacherDTO model)
    {
        var user = new CustomIdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.ContactNumber,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        if (!await _roleManager.RoleExistsAsync(RoleConstants.TeacherRole))
            await _roleManager.CreateAsync(new IdentityRole(RoleConstants.TeacherRole));

        await _userManager.AddToRoleAsync(user, RoleConstants.TeacherRole);

        var subject = await _subjectService.GetByName(model.SubjectName);

        var teacher = new Teacher
        {
            DateOfJoining = model.DateOfJoining,
            Subject = subject,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            Address = model.Address,
            PanNumber = "",
            Status = true,
            User = user,
        };

        await _teacherService.AddAsync(teacher);

        return Ok("Teacher added successfully");
    }

    [HttpPost("TeacherSignIn")]
    public async Task<IActionResult> TeacherSignIn([FromBody] SignInTeacherDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var teacher = await _teacherService.GetByUser(user.Id);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            var token = GenerateJwtToken(authClaims);

            var response = new
            {
                token = token,
                user = new
                {
                    id = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    teacherDetails = new
                    {
                        id = teacher.Id,
                        dateOfJoining = teacher.DateOfJoining,
                        subject = teacher.Subject,
                        gender = teacher.Gender,
                        dateOfBirth = teacher.DateOfBirth,
                        address = teacher.Address,
                        status = teacher.Status,
                        classRoutines = teacher.ClassRoutines.Select(cr => new
                        {
                            cr.Id,
                            cr.Section,
                            cr.Day,
                            cr.StartTime,
                            cr.EndTime,
                            cr.Status
                        }).ToList(),
                        classes = teacher.Classes.Select(cs => new
                        {
                            cs.Id,
                            cs.Name,
                            cs.Section,
                            cs.NoOfStudents,
                            cs.NoOfSubjects,
                            cs.Status,
                        }).ToList()
                    }
                }
            };

            return Ok(response);
        }

        return Unauthorized();
    }


    [HttpPost("StudentSignIn")]
    public async Task<IActionResult> StudentSignIn([FromBody] SignInStudentDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var student = await _studentService.GetByUser(user.Id);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            var token = GenerateJwtToken(authClaims);

            var response = new
            {
                token = token,
                user = new
                {
                    id = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    studentDetails = new
                    {
                        id = student.Id,
                        admissionNumber = student.AdmissionNumber,
                        admissionDate = student.AdmissionDate,
                        status = student.Status,
                        gender = student.Gender,
                        dateOfBirth = student.DateOfBirth,
                        sector = student.Sector,
                        currentAddress = student.CurrentAddress,
                        classId = student.ClassId,
                        classSelf = student.Class,
                        parents = student.Parents.Select(pr => new
                        {
                            pr.Id,
                            pr.FirstName,
                            pr.LastName,
                            pr.Email,
                            pr.PhoneNumber
                        }).ToList()
                    }
                }
            };

            return Ok(response);
        }

        return Unauthorized();
    }

    private JwtSecurityToken GenerateJwtToken(List<Claim> authClaims)
    {
        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
