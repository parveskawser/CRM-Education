using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            List<Students> students = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name = "Tasmim",
                    Age = 23,
                    Department = "CSE",
                    Email = "tasmim@gmail.com"
                },

                new Students
                {
                    Id = 2,
                    Name = "Marufa",
                    Age = 22,
                    Department = "CSE",
                    Email = "marufa@gmail.com"
                },

                new Students
                {
                    Id = 3,
                    Name = "Nusrat",
                    Age = 24,
                    Department = "BBA",
                    Email = "nusrat@gmail.com"
                }
            };

            return View(students);
        }

        public IActionResult Details(int id)
        {
            List<Students> students = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name = "Tasmim",
                    Age = 23,
                    Department = "CSE",
                    Email = "tasmim@gmail.com"
                },

                new Students
                {
                    Id = 2,
                    Name = "Marufa",
                    Age = 22,
                    Department = "CSE",
                    Email = "marufa@gmail.com"
                },

                new Students
                {
                    Id = 3,
                    Name = "Nusrat",
                    Age = 24,
                    Department = "BBA",
                    Email = "nusrat@gmail.com"
                }
            };

            Students student = students.FirstOrDefault(s => s.Id == id);

            return View(students);
        }
    }
}
