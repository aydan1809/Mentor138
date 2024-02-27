using AutoMapper;
using Mentor138.Abstractions.IRepositories;
using Mentor138.Abstractions.IRepositories.IEntitiesRepositories;
using Mentor138.Abstractions.IUnitOfWorks;
using Mentor138.Abstractions.Services;
using Mentor138.Contexts;
using Mentor138.DTOs.SchoolDtos;
using Mentor138.DTOs.StudentDtos;
using Mentor138.Entities;
using Mentor138.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mentor138.Implementations.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepositories<School> schoolRepo;
        public SchoolService(AppDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; //bu yuxarda olmalidir, yoxsa null olur deye repolar gelmir
            _context = context;
            _mapper = mapper;
            schoolRepo = _unitOfWork.GetRespository<School>();
        }

        public async Task<GenericResponseModel<List<SchoolGetDto>>> GetAllSchool()
        {
            GenericResponseModel<List<SchoolGetDto>> response = new GenericResponseModel<List<SchoolGetDto>>() { Data = null, StatusCode = 500 };
            // List<School> data = await _context.Schools.Include(x => x.Students).ToListAsync();
            List<School> data = await schoolRepo.GetAll().ToListAsync();
            if (data != null)
            {
                var school = _mapper.Map<List<SchoolGetDto>>(data);
                response.Data = school;
                response.StatusCode = 200;
            }
            else
            {
                response.Data = null;
                response.StatusCode = 500;
            }
            return response;
        }


        public async Task<GenericResponseModel<SchoolGetDto>> GetSchoolById(int id)
        {
            GenericResponseModel<SchoolGetDto> response = new GenericResponseModel<SchoolGetDto>();
            {
                response.Data = null;
                response.StatusCode = 500;
            }
            //var data=await _context.Schools.FirstOrDefaultAsync(X => X.Id == id);
            var data = await schoolRepo.GetById(id);
            if (data != null)
            {
                var school = _mapper.Map<SchoolGetDto>(data);
                response.Data = school;
                response.StatusCode = 200;
            }
            else
            {
                response.Data = null;
                response.StatusCode = 500;
            }
            return response;
        }
        public async Task<GenericResponseModel<SchoolCreateDto>> AddSchool(SchoolCreateDto model)
        {
            GenericResponseModel<SchoolCreateDto> response = new GenericResponseModel<SchoolCreateDto>() { Data = null, StatusCode = 404 };
            if (model == null)
            {
                return response;
            }
            var school = new School();
            school.SchoolName = model.SchoolName;
            school.Number = model.Number;
            //_context.Schools.Add(school);
            //var Affect = await _context.SaveChangesAsync();
            await schoolRepo.Add(school);
            var Affect = await _unitOfWork.SaveAsync();
            if (Affect > 0)
            {
                response.Data = model;
                response.StatusCode = 200;
            }
            else
            {
                return response;
            }
            return response;
        }
        public async Task<GenericResponseModel<bool>> DeleteSchool(int id)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            // var data=await _context.Schools.FirstOrDefaultAsync(x => x.Id == id);
            var data = await schoolRepo.GetById(id);
            if (data == null)
            {
                return response;
            }
            //_context.Schools.Remove(data);
            //var Affect=await _context.SaveChangesAsync();
             schoolRepo.Delete(data);
            var Affect = await _unitOfWork.SaveAsync();
            if (Affect > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateSchool(SchoolUpdateDto model)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            //var school = await _context.Schools.FirstOrDefaultAsync(x => x.Id == id);
            var school = await schoolRepo.GetById(model.Id);
            if (school == null)
            {
                return response;
            }
            school.SchoolName = model.SchoolName;
            school.Number = model.Number;
            // _context.Schools.Update(school);
            // var Affect=await _context.SaveChangesAsync();
            schoolRepo.Update(school);
            var Affect = await _unitOfWork.SaveAsync();
            if (Affect > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }
            else
            {
                return response;
            }
            return response;
        }
    }
}
