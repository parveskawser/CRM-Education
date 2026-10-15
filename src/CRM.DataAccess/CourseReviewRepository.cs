using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class CourseReviewRepository : ICourseReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseReview>> GetAllAsync()
        {
            return await _dbContext.CourseReviews
                .OrderByDescending(x => x.ReviewId)
                .ToListAsync();
        }

        public async Task<CourseReview?> GetByIdAsync(int id)
        {
            return await _dbContext.CourseReviews.FindAsync(id);
        }

        public async Task AddAsync(CourseReview courseReview)
        {
            await _dbContext.CourseReviews.AddAsync(courseReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseReview courseReview)
        {
            _dbContext.CourseReviews.Update(courseReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var courseReview = await _dbContext.CourseReviews.FindAsync(id);

            if (courseReview == null)
                return;

            _dbContext.CourseReviews.Remove(courseReview);
            await _dbContext.SaveChangesAsync();
        }
    }
}