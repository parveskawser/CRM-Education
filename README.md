# Online Course Management System

An ASP.NET Core web application for managing institutions, courses, students, instructors, enrolments, live classes, assessments, and payments from one platform.

## Technology Stack

- ASP.NET Core
- C#
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- HTML, CSS, JavaScript, and Bootstrap

## Core Features

### Institution and Administration

- Multi-institution SaaS-ready architecture
- Secure administrator login and role-based access control
- Institution profile, branding, and settings management
- User account creation, activation, and permission management
- Dashboard with course, student, revenue, and activity summaries
- Email, SMS, and in-app notification settings

### Course Management

- Create, edit, publish, unpublish, and archive courses
- Course categories, levels, thumbnails, descriptions, and pricing
- Course outline with sections, lessons, and learning materials
- Video lessons, downloadable files, and recorded-class support
- Course reviews and ratings moderation
- Coupon and promotional campaign management

### Student Portal

- Student registration, login, and profile management
- Browse courses and enrol online
- My Courses dashboard with lesson progress tracking
- Class routine, learning materials, and recorded classes
- Quiz and assessment participation
- Certificate download after course completion
- Payment history and invoice download
- Wishlist and instructor messaging
- AI chatbot support and student follow options

### Instructor Portal

- Instructor onboarding and profile approval
- Create and manage assigned courses
- Upload course content and learning resources
- Schedule live and recorded classes
- Create exam questions, quizzes, and assessments
- Review student progress and result statistics
- Course feedback and review visibility
- Instructor payment and earnings information

### Academic Management

- Student enrolment and course-batch assignment
- Attendance tracking for physical and live classes
- Live class links and schedules
- Quiz, assignment, and assessment setup
- Automatic or manual result publication
- Progress reports and completion status
- Certificate eligibility and issuance controls

### Payments and Finance

- Course fee collection and payment status tracking
- Online payment gateway integration support
- Invoice and receipt generation
- Coupon, discount, and promotional pricing rules
- Instructor payment calculation and processing
- Revenue and transaction reports

### Shared Features

- Change-password and password-reset workflow
- Email, SMS, and application notifications
- Responsive public home page and course catalogue
- Search, filters, and course detail pages
- Audit-friendly activity and transaction records

## Suggested Project Structure

```text
OnlineCourseManagement/
├── src/
│   ├── OnlineCourseManagement.Web           # MVC/Web UI
│   ├── OnlineCourseManagement.Application   # Business logic and DTOs
│   ├── OnlineCourseManagement.Domain        # Entities and interfaces
│   └── OnlineCourseManagement.Infrastructure # EF Core, SQL Server, services
├── tests/
│   └── OnlineCourseManagement.Tests
└── README.md
```

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- SQL Server or SQL Server Express
- Visual Studio 2022, Visual Studio Code, or Rider

### Run locally

```bash
git clone <repository-url>
cd OnlineCourseManagement
dotnet restore
dotnet build
dotnet run --project src/OnlineCourseManagement.Web
```

Configure the SQL Server connection string in `appsettings.json`, then create and apply Entity Framework Core migrations before using the application.

## Security Notes

- Use ASP.NET Core Identity for authentication and password hashing.
- Enforce role-based authorization for Admin, Instructor, and Student areas.
- Store payment credentials and production connection strings in secure configuration, not source code.
- Validate file uploads and protect all sensitive student and payment data.

## License

Add the preferred license for this project before public distribution.
