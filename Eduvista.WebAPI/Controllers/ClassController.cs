using AutoMapper;
using Eduvista.Business.Abstraction;
using Eduvista.Entities.Entities;
using Eduvista.WebAPI.DTOs;
using Eduvista.WebAPI.DTOs.ClassControllerDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eduvista.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    // Mapper

    private readonly IMapper _mapper;

    // Services

    private readonly IClassService _classService;

    public ClassController(IClassService classService, IMapper mapper)
    {
        _classService = classService;
        _mapper = mapper;
    }

    [HttpPost("AddClass")]
    public async Task<IActionResult> AddClass([FromBody] AddClassDTO model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            return BadRequest("Class name is required.");

        try
        {
            var newClass = _mapper.Map<Class>(model);
            await _classService.AddAsync(newClass);
            return Ok("Class added successfully.");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("GetAllClasses")]
    public async Task<IActionResult> GetAllClasses()
    {
        try
        {
            var classes = await _classService.GetAllAsync();
            var response = _mapper.Map<List<ClassDTO>>(classes);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
