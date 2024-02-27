using Mentor138.Abstractions.Services;
using Mentor138.DTOs.SchoolDtos;
using Mentor138.Implementations.Service;
using Mentor138.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mentor138.Controllers
{
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;
        public SchoolController(ISchoolService service)
        {
            _service = service;
        }
        [HttpGet("getAllStudent")]
        public async Task<IActionResult> GetAllStudent() 
        {
        var data=await _service.GetAllSchool();
        return StatusCode(data.StatusCode,data);
        }
        [HttpGet("getSchoolById")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var data = await _service.GetSchoolById(id);
            return StatusCode(data.StatusCode,data);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddSchool(SchoolCreateDto model)
        {
            var data = await _service.AddSchool(model);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut("updateSchool")]
        public async Task<IActionResult> UpdateSchool(SchoolUpdateDto model)
        { 
        var data=await _service.UpdateSchool(model);
        return StatusCode(data.StatusCode,data);    
        }
        [HttpDelete("deleteSchool")]
        public async Task<IActionResult> DeleteSchool(int id)
        { 
        var data=await _service.DeleteSchool(id);
        return StatusCode(data.StatusCode,data);
        }
    }
}
