using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(x => x.Price)
                      .HasPrecision(18, 2);

                entity.Property(x => x.DiscountPrice)
                      .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Course>()
         .ToTable("Course");

            modelBuilder.Entity<Instructor>()
                .ToTable("Instructor");


            modelBuilder.Entity<Course>().HasData(
    new Course
    {
        Id = 1,
        Title = "ASP.NET Core MVC Fundamentals",
        ShortDescription = "Build modern web applications with ASP.NET Core MVC.",
        Description = "Learn MVC architecture, routing, controllers, views, Razor syntax and CRUD operations.",
        ThumbnailUrl = "/images/courses/aspnet-core-mvc.jpg",
        Price = 5000,
        DiscountPrice = 3500,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 30,
        DurationInMinutes = 720,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 2,
        Title = "C# Programming from Zero to Hero",
        ShortDescription = "Learn C# programming step by step.",
        Description = "Variables, conditions, loops, OOP, collections, LINQ and practical projects.",
        ThumbnailUrl = "/images/courses/csharp.jpg",
        Price = 4000,
        DiscountPrice = 2800,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 40,
        DurationInMinutes = 900,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 3,
        Title = "SQL Server Database Design",
        ShortDescription = "Learn SQL Server database design and queries.",
        Description = "Database normalization, table design, joins, stored procedures and performance basics.",
        ThumbnailUrl = "/images/courses/sql-server.jpg",
        Price = 4500,
        DiscountPrice = 3000,
        InstructorId = 2,
        CategoryId = 2,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 32,
        DurationInMinutes = 780,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 4,
        Title = "Entity Framework Core Mastery",
        ShortDescription = "Database access with EF Core.",
        Description = "Code First, migrations, relationships, LINQ queries and repository pattern.",
        ThumbnailUrl = "/images/courses/ef-core.jpg",
        Price = 5000,
        DiscountPrice = 3800,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Intermediate",
        Language = "Bangla",
        TotalLessons = 28,
        DurationInMinutes = 680,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 5,
        Title = "Web API with ASP.NET Core",
        ShortDescription = "Create RESTful APIs using ASP.NET Core.",
        Description = "Build secure APIs with JWT authentication, CRUD, Swagger and SQL Server.",
        ThumbnailUrl = "/images/courses/web-api.jpg",
        Price = 5500,
        DiscountPrice = 4200,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Intermediate",
        Language = "Bangla",
        TotalLessons = 35,
        DurationInMinutes = 840,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 6,
        Title = "React JS for Beginners",
        ShortDescription = "Create interactive frontend applications using React.",
        Description = "Components, props, state, hooks, API integration and project development.",
        ThumbnailUrl = "/images/courses/react.jpg",
        Price = 4500,
        DiscountPrice = 3200,
        InstructorId = 3,
        CategoryId = 3,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 34,
        DurationInMinutes = 800,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 7,
        Title = "JavaScript Essentials",
        ShortDescription = "Learn modern JavaScript fundamentals.",
        Description = "ES6, DOM manipulation, events, async JavaScript and API calls.",
        ThumbnailUrl = "/images/courses/javascript.jpg",
        Price = 3500,
        DiscountPrice = 2500,
        InstructorId = 3,
        CategoryId = 3,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 25,
        DurationInMinutes = 600,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 8,
        Title = "HTML, CSS and Bootstrap",
        ShortDescription = "Design responsive websites from scratch.",
        Description = "HTML structure, CSS styling, Flexbox, Grid and Bootstrap components.",
        ThumbnailUrl = "/images/courses/html-css.jpg",
        Price = 3000,
        DiscountPrice = 2000,
        InstructorId = 3,
        CategoryId = 3,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 30,
        DurationInMinutes = 700,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 9,
        Title = "Full Stack ASP.NET Core MVC",
        ShortDescription = "Build a complete production-ready web application.",
        Description = "Clean Architecture, MVC, EF Core, authentication, payment and deployment.",
        ThumbnailUrl = "/images/courses/full-stack-dotnet.jpg",
        Price = 12000,
        DiscountPrice = 8500,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Advanced",
        Language = "Bangla",
        TotalLessons = 80,
        DurationInMinutes = 3600,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 10,
        Title = "Flutter Mobile App Development",
        ShortDescription = "Create Android and iOS apps using Flutter.",
        Description = "Dart, widgets, navigation, Firebase, REST API and complete mobile apps.",
        ThumbnailUrl = "/images/courses/flutter.jpg",
        Price = 7000,
        DiscountPrice = 5500,
        InstructorId = 4,
        CategoryId = 4,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 50,
        DurationInMinutes = 1400,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 11,
        Title = "Python Programming Basics",
        ShortDescription = "Start programming with Python.",
        Description = "Python syntax, functions, OOP, file handling and practical exercises.",
        ThumbnailUrl = "/images/courses/python.jpg",
        Price = 4000,
        DiscountPrice = 2800,
        InstructorId = 2,
        CategoryId = 1,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 36,
        DurationInMinutes = 850,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 12,
        Title = "Digital Marketing Fundamentals",
        ShortDescription = "Learn online marketing for business growth.",
        Description = "SEO, Facebook marketing, Google Ads, content strategy and analytics.",
        ThumbnailUrl = "/images/courses/digital-marketing.jpg",
        Price = 5000,
        DiscountPrice = 3500,
        InstructorId = 5,
        CategoryId = 5,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 38,
        DurationInMinutes = 950,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 13,
        Title = "UI UX Design with Figma",
        ShortDescription = "Design user-friendly web and mobile interfaces.",
        Description = "Wireframes, prototypes, color systems, typography and Figma workflow.",
        ThumbnailUrl = "/images/courses/figma-uiux.jpg",
        Price = 5500,
        DiscountPrice = 4000,
        InstructorId = 5,
        CategoryId = 6,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 32,
        DurationInMinutes = 780,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 14,
        Title = "Advanced SQL Server",
        ShortDescription = "Improve database query and optimization skills.",
        Description = "Indexing, query optimization, views, triggers and advanced stored procedures.",
        ThumbnailUrl = "/images/courses/advanced-sql.jpg",
        Price = 6000,
        DiscountPrice = 4500,
        InstructorId = 2,
        CategoryId = 2,
        Level = "Advanced",
        Language = "Bangla",
        TotalLessons = 30,
        DurationInMinutes = 850,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 15,
        Title = "Clean Architecture in .NET",
        ShortDescription = "Apply Clean Architecture to .NET projects.",
        Description = "Domain driven design basics, layers, CQRS, dependency injection and best practices.",
        ThumbnailUrl = "/images/courses/clean-architecture.jpg",
        Price = 6500,
        DiscountPrice = 5000,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Advanced",
        Language = "Bangla",
        TotalLessons = 26,
        DurationInMinutes = 720,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 16,
        Title = "E-Commerce Website Development",
        ShortDescription = "Build a complete e-commerce website.",
        Description = "Product management, cart, checkout, order management and payment gateway integration.",
        ThumbnailUrl = "/images/courses/ecommerce.jpg",
        Price = 8000,
        DiscountPrice = 6000,
        InstructorId = 1,
        CategoryId = 1,
        Level = "Intermediate",
        Language = "Bangla",
        TotalLessons = 45,
        DurationInMinutes = 1500,
        IsPublished = true,
        IsFeatured = true
    },
    new Course
    {
        Id = 17,
        Title = "Git and GitHub for Developers",
        ShortDescription = "Manage source code professionally with Git.",
        Description = "Repositories, branching, pull requests, merge conflict resolution and team workflow.",
        ThumbnailUrl = "/images/courses/git-github.jpg",
        Price = 2500,
        DiscountPrice = 1500,
        InstructorId = 2,
        CategoryId = 1,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 18,
        DurationInMinutes = 360,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 18,
        Title = "Laravel PHP Development",
        ShortDescription = "Build web applications with Laravel.",
        Description = "Routing, Blade, migrations, Eloquent ORM, authentication and CRUD development.",
        ThumbnailUrl = "/images/courses/laravel.jpg",
        Price = 5500,
        DiscountPrice = 4000,
        InstructorId = 4,
        CategoryId = 1,
        Level = "Intermediate",
        Language = "Bangla",
        TotalLessons = 42,
        DurationInMinutes = 1100,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 19,
        Title = "Freelancing Career Guide",
        ShortDescription = "Start your professional freelancing journey.",
        Description = "Profile setup, client communication, proposal writing, portfolio and job strategy.",
        ThumbnailUrl = "/images/courses/freelancing.jpg",
        Price = 3000,
        DiscountPrice = 1800,
        InstructorId = 5,
        CategoryId = 5,
        Level = "Beginner",
        Language = "Bangla",
        TotalLessons = 20,
        DurationInMinutes = 420,
        IsPublished = true,
        IsFeatured = false
    },
    new Course
    {
        Id = 20,
        Title = "Azure Cloud Fundamentals",
        ShortDescription = "Learn Microsoft Azure cloud fundamentals.",
        Description = "Azure services, App Service, database deployment, storage and cloud security basics.",
        ThumbnailUrl = "/images/courses/azure.jpg",
        Price = 6500,
        DiscountPrice = 4800,
        InstructorId = 2,
        CategoryId = 1,
        Level = "Intermediate",
        Language = "English",
        TotalLessons = 28,
        DurationInMinutes = 760,
        IsPublished = true,
        IsFeatured = true
    }
);
        }
    }
}
