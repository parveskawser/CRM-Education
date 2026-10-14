using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Facade
{
    public class CourseFacade : ICourseFacade
    {
        private readonly ICourseRepository _courseRepository;

        public CourseFacade(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task AddCourseAsync(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Title))
                throw new Exception("Course title is required.");

            if (course.Price < 0)
                throw new Exception("Course price cannot be negative.");

            if (course.DiscountPrice.HasValue && course.DiscountPrice > course.Price)
                throw new Exception("Discount price cannot be greater than regular price.");

            //database final call
            await _courseRepository.AddAsync(course);
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(course.Id);

            if (existingCourse == null)
                return false;

            if (string.IsNullOrWhiteSpace(course.Title))
                throw new Exception("Course title is required.");

            existingCourse.Title = course.Title;
            existingCourse.ShortDescription = course.ShortDescription;
            existingCourse.Description = course.Description;
            existingCourse.ThumbnailUrl = course.ThumbnailUrl;
            existingCourse.Price = course.Price;
            existingCourse.DiscountPrice = course.DiscountPrice;
            existingCourse.InstructorId = course.InstructorId;
            existingCourse.CategoryId = course.CategoryId;
            existingCourse.Level = course.Level;
            existingCourse.Language = course.Language;
            existingCourse.TotalLessons = course.TotalLessons;
            existingCourse.DurationInMinutes = course.DurationInMinutes;
            existingCourse.IsPublished = course.IsPublished;
            existingCourse.IsFeatured = course.IsFeatured;

            await _courseRepository.UpdateAsync(existingCourse);
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return false;

            await _courseRepository.DeleteAsync(id);
            return true;
        }
    }
}
