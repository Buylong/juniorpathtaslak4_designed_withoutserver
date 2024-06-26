﻿// Models/Student.cs
using System.ComponentModel.DataAnnotations;

namespace juniorpathtaslak4.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
