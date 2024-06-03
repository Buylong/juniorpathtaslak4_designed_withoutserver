using juniorpathtaslak4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace juniorpathtaslak4.Repositories
{
    public class ChildRepository
    {
        private static List<Child> _children = new List<Child>
        {
            new Child { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(2015, 5, 1), DailyActivities = GenerateSampleData("Swimming", 10) },
            new Child { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(2016, 3, 15), DailyActivities = GenerateSampleData("Reading", 10) }
        };

        public List<Child> GetAll()
        {
            return _children;
        }

        public Child GetById(int id)
        {
            return _children.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Child child)
        {
            child.Id = _children.Count > 0 ? _children.Max(c => c.Id) + 1 : 1;
            _children.Add(child);
        }

        public void Update(Child child)
        {
            var existingChild = GetById(child.Id);
            if (existingChild != null)
            {
                existingChild.Name = child.Name;
                existingChild.DateOfBirth = child.DateOfBirth;
                existingChild.DailyActivities = child.DailyActivities;
            }
        }

        public void Delete(int id)
        {
            var child = GetById(id);
            if (child != null)
            {
                _children.Remove(child);
            }
        }

        public void AddDailyActivity(int childId, DailyActivity activity)
        {
            var child = GetById(childId);
            if (child != null)
            {
                activity.Id = child.DailyActivities.Count > 0 ? child.DailyActivities.Max(a => a.Id) + 1 : 1;
                child.DailyActivities.Add(activity);
            }
        }

        private static List<DailyActivity> GenerateSampleData(string activityName, int weeks)
        {
            var random = new Random();
            var activities = new List<DailyActivity>();
            for (int i = 0; i < weeks; i++)
            {
                activities.Add(new DailyActivity
                {
                    Id = i + 1,
                    Date = DateTime.Today.AddDays(-7 * (weeks - i)),
                    ActivityDescription = $"{activityName} - Week {i + 1}",
                    Score = random.Next(50, 101) // 50 ile 100 arasında rastgele puan
                });
            }
            return activities;
        }
    }
}
