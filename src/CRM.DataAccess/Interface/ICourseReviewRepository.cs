using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ICourseReviewRepository
    {
        Task<List<CourseReview>> GetAllAsync();
        Task<CourseReview?> GetByIdAsync(int id);
        Task AddAsync(CourseReview courseReview);
        Task UpdateAsync(CourseReview courseReview);
        Task DeleteAsync(int id);
    }
}