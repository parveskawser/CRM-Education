using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Facade
{
    public class InstructorFacade : IInstructorFacade
    {
        private readonly IInstructorRepository _InstructorRepository;

        public InstructorFacade(IInstructorRepository InstructorRepository)
        {
            _InstructorRepository = InstructorRepository;
        }

        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            return await _InstructorRepository.GetAllAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _InstructorRepository.GetByIdAsync(id);
        }

        public async Task AddInstructorAsync(Instructor Instructor)
        {
             
            //database final call
            await _InstructorRepository.AddAsync(Instructor);
        }

        public async Task<bool> UpdateInstructorAsync(Instructor Instructor)
        {
            var existingInstructor = await _InstructorRepository.GetByIdAsync(Instructor.Id);

            if (existingInstructor == null)
                return false;

            //if (string.IsNullOrWhiteSpace(Instructor.Title))
            //    throw new Exception("Instructor title is required.");

            //existingInstructor.Title = Instructor.Title;
            //existingInstructor.ShortDescription = Instructor.ShortDescription;
            //existingInstructor.Description = Instructor.Description;
            //existingInstructor.ThumbnailUrl = Instructor.ThumbnailUrl;
            //existingInstructor.Price = Instructor.Price;
            //existingInstructor.DiscountPrice = Instructor.DiscountPrice;
            //existingInstructor.InstructorId = Instructor.InstructorId;
            //existingInstructor.CategoryId = Instructor.CategoryId;
            //existingInstructor.Level = Instructor.Level;
            //existingInstructor.Language = Instructor.Language;
            //existingInstructor.TotalLessons = Instructor.TotalLessons;
            //existingInstructor.DurationInMinutes = Instructor.DurationInMinutes;
            //existingInstructor.IsPublished = Instructor.IsPublished;
            //existingInstructor.IsFeatured = Instructor.IsFeatured;

            await _InstructorRepository.UpdateAsync(existingInstructor);
            return true;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var Instructor = await _InstructorRepository.GetByIdAsync(id);

            if (Instructor == null)
                return false;

            await _InstructorRepository.DeleteAsync(id);
            return true;
        }
    }
}
