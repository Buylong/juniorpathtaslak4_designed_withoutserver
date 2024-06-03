// Controllers/StudentController.cs
using Microsoft.AspNetCore.Mvc;
using juniorpathtaslak4.Models;
using System.Collections.Generic;


namespace juniorpathtaslak4.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "John", Age = 10 },
                new Student { Id = 2, Name = "Emma", Age = 9 },
                new Student { Id = 3, Name = "Michael", Age = 11 }
            };
            return View(students);
        }
    }
}
