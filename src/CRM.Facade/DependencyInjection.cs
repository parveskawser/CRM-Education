using CRM.DataAccess;
using CRM.DataAccess.Interface;
using CRM.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CRM.DataAccess.Implementation;
using CRM.Facade.Implementation;

namespace CRM.Facade
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCrmFacade(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseFacade, CourseFacade>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleFacade, RoleFacade>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFacade, UserFacade>();

            services.AddScoped<IStudentProfileRepository, StudentProfileRepository>();
            services.AddScoped<IStudentProfileFacade, StudentProfileFacade>();

            services.AddScoped<IInstructorProfileRepository, InstructorProfileRepository>();
            services.AddScoped<IInstructorProfileFacade, InstructorProfileFacade>();

            services.AddScoped<ICourseOutlineRepository, CourseOutlineRepository>();
            services.AddScoped<ICourseOutlineFacade, CourseOutlineFacade>();

            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleFacade, ModuleFacade>();

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonFacade, LessonFacade>();

            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<IBatchFacade, BatchFacade>();

            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IEnrollmentFacade, EnrollmentFacade>();

            services.AddScoped<ILessonProgressRepository, LessonProgressRepository>();
            services.AddScoped<ILessonProgressFacade, LessonProgressFacade>();

            services.AddScoped<ILiveClassRepository, LiveClassRepository>();
            services.AddScoped<ILiveClassFacade, LiveClassFacade>();

            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceFacade, AttendanceFacade>();

            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IAssignmentFacade, AssignmentFacade>();

            services.AddScoped<IAssignmentSubmissionRepository, AssignmentSubmissionRepository>();
            services.AddScoped<IAssignmentSubmissionFacade, AssignmentSubmissionFacade>();

            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuizFacade, QuizFacade>();

            services.AddScoped<IQuizQuestionRepository, QuizQuestionRepository>();
            services.AddScoped<IQuizQuestionFacade, QuizQuestionFacade>();

            services.AddScoped<IQuizAttemptRepository, QuizAttemptRepository>();
            services.AddScoped<IQuizAttemptFacade, QuizAttemptFacade>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountFacade, AccountFacade>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentFacade, PaymentFacade>();

            services.AddScoped<ITransactionReportRepository, TransactionReportRepository>();
            services.AddScoped<ITransactionReportFacade, TransactionReportFacade>();

            services.AddScoped<ICourseReviewRepository, CourseReviewRepository>();
            services.AddScoped<ICourseReviewFacade, CourseReviewFacade>();

            services.AddScoped<IAiCourseQueryRepository, AiCourseQueryRepository>();
            services.AddScoped<IAiCourseQueryFacade, AiCourseQueryFacade>();


            return services;
        }
    }
}