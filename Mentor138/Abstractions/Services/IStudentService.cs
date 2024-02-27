using Mentor138.DTOs.StudentDtos;
using Mentor138.Entities;
using Mentor138.Models;

namespace Mentor138.Abstractions.Services
{
    public interface IStudentService
    {
        public Task<GenericResponseModel<List<StudentGetDto>>>GetAllStudents();
        public Task<GenericResponseModel<StudentGetDto>> GetById(int id);
        public Task<GenericResponseModel<List<StudentGetDto>>> GetAllStudentBySchoolId(int id);
        public Task<GenericResponseModel<StudentCreateDto>> AddStudent(StudentCreateDto model);
        public Task<GenericResponseModel<bool>> UpdateStudent(int id,StudentUpdateDto model);
        public Task<GenericResponseModel<bool>> DeleteStudent(int id);
        public Task<GenericResponseModel<bool>> ChangeSchool(ChangeSchoolDto model);
        public Task<GenericResponseModel<bool>> ChangeSchool(int SchoolId,int NewSchoolId);

    }
}

