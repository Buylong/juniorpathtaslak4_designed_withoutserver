using System;

namespace juniorpathtaslak4.Models
{
    public class DailyActivity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ActivityDescription { get; set; }
        public int Score { get; set; }  // Yeni eklenen özellik
    }
}
