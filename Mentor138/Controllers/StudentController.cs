using Mentor138.Abstractions.Services;
using Mentor138.DTOs.StudentDtos;
using Mentor138.Implementations.Service;
using Microsoft.AspNetCore.Mvc;

namespace Mentor138.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
           _service = service;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllStudents()
        { 
           var data=await _service.GetAllStudents();
           return StatusCode(data.StatusCode,data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id) 
        {
            var data = await _service.GetById(id);
            return StatusCode(data.StatusCode,data);
        }
        [HttpGet("GetAllStudentBySchoolId")]
        public async Task<IActionResult> GetAllStudentBySchoolId(int id) 
        {
            var data = await _service.GetAllStudentBySchoolId(id);
            return StatusCode(data.StatusCode,data);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Add(StudentCreateDto model)
        { 
            var data=await _service.AddStudent(model);
            return StatusCode(data.StatusCode,data);
        }
        [HttpPut("ChangeStudent")]
        public async Task<IActionResult> Change(int SchoolId, int NewSchoolId) 
        {
            var data = await _service.ChangeSchool(SchoolId,NewSchoolId);   
            return StatusCode(data.StatusCode,data);    
        }
        [HttpPut("ChangeSchools")]
        public async Task<IActionResult> ChangeStudents(ChangeSchoolDto model)
        {
            var data = await _service.ChangeSchool(model);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto mode) 
        {
            var data=await _service.UpdateStudent(id, mode);
            return StatusCode(data.StatusCode,data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.DeleteStudent(id);
            return StatusCode(data.StatusCode, data);
        }
    }
}
