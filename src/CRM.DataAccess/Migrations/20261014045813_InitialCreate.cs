using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalLessons = table.Column<int>(type: "int", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPrice", "DurationInMinutes", "InstructorId", "IsFeatured", "IsPublished", "Language", "Level", "Price", "ShortDescription", "ThumbnailUrl", "Title", "TotalLessons" },
                values: new object[,]
                {
                    { 1, 1, "Learn MVC architecture, routing, controllers, views, Razor syntax and CRUD operations.", 3500m, 720, 1, true, true, "Bangla", "Beginner", 5000m, "Build modern web applications with ASP.NET Core MVC.", "/images/courses/aspnet-core-mvc.jpg", "ASP.NET Core MVC Fundamentals", 30 },
                    { 2, 1, "Variables, conditions, loops, OOP, collections, LINQ and practical projects.", 2800m, 900, 1, true, true, "Bangla", "Beginner", 4000m, "Learn C# programming step by step.", "/images/courses/csharp.jpg", "C# Programming from Zero to Hero", 40 },
                    { 3, 2, "Database normalization, table design, joins, stored procedures and performance basics.", 3000m, 780, 2, false, true, "Bangla", "Beginner", 4500m, "Learn SQL Server database design and queries.", "/images/courses/sql-server.jpg", "SQL Server Database Design", 32 },
                    { 4, 1, "Code First, migrations, relationships, LINQ queries and repository pattern.", 3800m, 680, 1, true, true, "Bangla", "Intermediate", 5000m, "Database access with EF Core.", "/images/courses/ef-core.jpg", "Entity Framework Core Mastery", 28 },
                    { 5, 1, "Build secure APIs with JWT authentication, CRUD, Swagger and SQL Server.", 4200m, 840, 1, true, true, "Bangla", "Intermediate", 5500m, "Create RESTful APIs using ASP.NET Core.", "/images/courses/web-api.jpg", "Web API with ASP.NET Core", 35 },
                    { 6, 3, "Components, props, state, hooks, API integration and project development.", 3200m, 800, 3, false, true, "Bangla", "Beginner", 4500m, "Create interactive frontend applications using React.", "/images/courses/react.jpg", "React JS for Beginners", 34 },
                    { 7, 3, "ES6, DOM manipulation, events, async JavaScript and API calls.", 2500m, 600, 3, false, true, "Bangla", "Beginner", 3500m, "Learn modern JavaScript fundamentals.", "/images/courses/javascript.jpg", "JavaScript Essentials", 25 },
                    { 8, 3, "HTML structure, CSS styling, Flexbox, Grid and Bootstrap components.", 2000m, 700, 3, false, true, "Bangla", "Beginner", 3000m, "Design responsive websites from scratch.", "/images/courses/html-css.jpg", "HTML, CSS and Bootstrap", 30 },
                    { 9, 1, "Clean Architecture, MVC, EF Core, authentication, payment and deployment.", 8500m, 3600, 1, true, true, "Bangla", "Advanced", 12000m, "Build a complete production-ready web application.", "/images/courses/full-stack-dotnet.jpg", "Full Stack ASP.NET Core MVC", 80 },
                    { 10, 4, "Dart, widgets, navigation, Firebase, REST API and complete mobile apps.", 5500m, 1400, 4, true, true, "Bangla", "Beginner", 7000m, "Create Android and iOS apps using Flutter.", "/images/courses/flutter.jpg", "Flutter Mobile App Development", 50 },
                    { 11, 1, "Python syntax, functions, OOP, file handling and practical exercises.", 2800m, 850, 2, false, true, "Bangla", "Beginner", 4000m, "Start programming with Python.", "/images/courses/python.jpg", "Python Programming Basics", 36 },
                    { 12, 5, "SEO, Facebook marketing, Google Ads, content strategy and analytics.", 3500m, 950, 5, true, true, "Bangla", "Beginner", 5000m, "Learn online marketing for business growth.", "/images/courses/digital-marketing.jpg", "Digital Marketing Fundamentals", 38 },
                    { 13, 6, "Wireframes, prototypes, color systems, typography and Figma workflow.", 4000m, 780, 5, false, true, "Bangla", "Beginner", 5500m, "Design user-friendly web and mobile interfaces.", "/images/courses/figma-uiux.jpg", "UI UX Design with Figma", 32 },
                    { 14, 2, "Indexing, query optimization, views, triggers and advanced stored procedures.", 4500m, 850, 2, false, true, "Bangla", "Advanced", 6000m, "Improve database query and optimization skills.", "/images/courses/advanced-sql.jpg", "Advanced SQL Server", 30 },
                    { 15, 1, "Domain driven design basics, layers, CQRS, dependency injection and best practices.", 5000m, 720, 1, true, true, "Bangla", "Advanced", 6500m, "Apply Clean Architecture to .NET projects.", "/images/courses/clean-architecture.jpg", "Clean Architecture in .NET", 26 },
                    { 16, 1, "Product management, cart, checkout, order management and payment gateway integration.", 6000m, 1500, 1, true, true, "Bangla", "Intermediate", 8000m, "Build a complete e-commerce website.", "/images/courses/ecommerce.jpg", "E-Commerce Website Development", 45 },
                    { 17, 1, "Repositories, branching, pull requests, merge conflict resolution and team workflow.", 1500m, 360, 2, false, true, "Bangla", "Beginner", 2500m, "Manage source code professionally with Git.", "/images/courses/git-github.jpg", "Git and GitHub for Developers", 18 },
                    { 18, 1, "Routing, Blade, migrations, Eloquent ORM, authentication and CRUD development.", 4000m, 1100, 4, false, true, "Bangla", "Intermediate", 5500m, "Build web applications with Laravel.", "/images/courses/laravel.jpg", "Laravel PHP Development", 42 },
                    { 19, 5, "Profile setup, client communication, proposal writing, portfolio and job strategy.", 1800m, 420, 5, false, true, "Bangla", "Beginner", 3000m, "Start your professional freelancing journey.", "/images/courses/freelancing.jpg", "Freelancing Career Guide", 20 },
                    { 20, 1, "Azure services, App Service, database deployment, storage and cloud security basics.", 4800m, 760, 2, true, true, "English", "Intermediate", 6500m, "Learn Microsoft Azure cloud fundamentals.", "/images/courses/azure.jpg", "Azure Cloud Fundamentals", 28 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
