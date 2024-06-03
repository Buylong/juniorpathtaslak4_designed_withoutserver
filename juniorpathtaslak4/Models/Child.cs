using System;
using System.Collections.Generic;

namespace juniorpathtaslak4.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<DailyActivity> DailyActivities { get; set; } = new List<DailyActivity>();

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
    }
}
