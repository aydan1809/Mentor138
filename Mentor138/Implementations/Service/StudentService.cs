using AutoMapper;
using Mentor138.Abstractions.IUnitOfWorks;
using Mentor138.Abstractions.Services;
using Mentor138.Contexts;
using Mentor138.DTOs.StudentDtos;
using Mentor138.Entities;
using Mentor138.Mappers;
using Mentor138.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mentor138.Implementations.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(AppDbContext context, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        async Task<GenericResponseModel<List<StudentGetDto>>> IStudentService.GetAllStudents()
        {
            GenericResponseModel<List<StudentGetDto>> response = new GenericResponseModel<List<StudentGetDto>>() { Data = null, StatusCode = 500 };
            List<Student> data = await _context.Students.Include(x => x.School).ToListAsync();
            if (data != null && data.Count > 0)
            {
                var student = _mapper.Map<List<StudentGetDto>>(data);
                response.Data = student;
                response.StatusCode = 200;

            }
            else
            {
                response.Data = null;
                response.StatusCode = 500;
            }
            return response;
        }

        async Task<GenericResponseModel<List<StudentGetDto>>> IStudentService.GetAllStudentBySchoolId(int id)
        {
            GenericResponseModel<List<StudentGetDto>> response = new GenericResponseModel<List<StudentGetDto>>() { Data = null, StatusCode = 500 };
          List<Student> data = await _context.Students.Include(x => x.School).Where(x => x.SchoolId == id).ToListAsync();
            if (data.Count > 0)
            {
                var student = _mapper.Map<List<StudentGetDto>>(data);
                response.Data = student;
                response.StatusCode = 200;

            }
            else
            {
                response.Data = null;
                response.StatusCode = 404;

            }
            return response;
        }

        async Task<GenericResponseModel<StudentGetDto>> IStudentService.GetById(int id)
        {
            GenericResponseModel<StudentGetDto> response = new GenericResponseModel<StudentGetDto>() { Data = null, StatusCode = 500 };
            var data = await _context.Students.Include(x => x.School).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                var student = _mapper.Map<StudentGetDto>(data);
                response.Data = student;
                response.StatusCode = 200;
            }
            else
            {
                response.Data = null;
                response.StatusCode = 404;

            }
            return response;
        }

        async Task<GenericResponseModel<StudentCreateDto>> IStudentService.AddStudent(StudentCreateDto model)
        {
            GenericResponseModel<StudentCreateDto> response = new GenericResponseModel<StudentCreateDto>() { Data = null, StatusCode = 404 };
            if (model == null)
            {
                return response;
            }
            var student = new Student();
            student.Name = model.Name;
            student.SchoolId = model.SchoolId;
            //_context.Students.Add(student);
            //var rowAffect = await _context.SaveChangesAsync();
             await _unitOfWork.GetRespository<Student>().Add(student);
            var rowAffect=await _unitOfWork.SaveAsync();
            if (rowAffect > 0)
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

        async Task<GenericResponseModel<bool>> IStudentService.ChangeSchool(ChangeSchoolDto model)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            if (model == null)
            {
                return response;
            }
            var school = _context.Schools.FirstOrDefault(x => x.Id == model.NewSchoolId);
            if (school == null)
            {
                response.StatusCode = 400;
                return response;
            }
            var data = _context.Students.FirstOrDefault(x => x.Id == model.StudentId);

            if (data == null)
            {
                response.StatusCode = 400;
                return response;
            }
            data.SchoolId = model.NewSchoolId;
            _context.Students.Update(data);
            var rowAffect = await _context.SaveChangesAsync();


            if (rowAffect > 0)
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

        async Task<GenericResponseModel<bool>> IStudentService.ChangeSchool(int SchoolId, int NewSchoolId)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            if (SchoolId < 0 && NewSchoolId < 0)
            {
                return response;
            }
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.Id == SchoolId);
            if (school == null)
            {
                response.StatusCode = 400;
                return response;
            }
            var data = await _context.Students.FirstOrDefaultAsync(x => x.Id == NewSchoolId);

            if (data == null)
            {
                response.StatusCode = 400;
                return response;
            }
            data.SchoolId = NewSchoolId;
            _context.Students.Update(data);
            var rowAffect = await _context.SaveChangesAsync();


            if (rowAffect > 0)
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

        async Task<GenericResponseModel<bool>> IStudentService.DeleteStudent(int id)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            var data = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return response;
            }
            _context.Students.Remove(data);
            var rowAffect = await _context.SaveChangesAsync();
            if (rowAffect > 0)
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

      
        async Task<GenericResponseModel<bool>> IStudentService.UpdateStudent(int id, StudentUpdateDto model)
        {
           GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data=false, StatusCode=404 };
            
            var student= await _context.Students.FirstOrDefaultAsync(x => x.Id==id);   
            if (student== null) 
            {
                return response;
            }
            student.Name = model.Name;
            _context.Students.Update(student);
            var rowAffect = await _context.SaveChangesAsync();
            if (rowAffect > 0)
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
