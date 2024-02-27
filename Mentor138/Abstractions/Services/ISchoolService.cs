using Mentor138.DTOs.SchoolDtos;
using Mentor138.DTOs.StudentDtos;
using Mentor138.Models;

namespace Mentor138.Abstractions.Services
{
    public interface ISchoolService
    {
        public Task<GenericResponseModel<List<SchoolGetDto>>> GetAllSchool();
        public Task<GenericResponseModel<SchoolGetDto>> GetSchoolById(int id);
        public Task<GenericResponseModel<SchoolCreateDto>> AddSchool(SchoolCreateDto model);
        public Task<GenericResponseModel<bool>> UpdateSchool( SchoolUpdateDto model);
        public Task<GenericResponseModel<bool>> DeleteSchool(int id);
    }
}

