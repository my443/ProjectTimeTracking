using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeTracking.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public string ShortTitle { get; set; }
        public string? Description { get; set; }
        public DateOnly DateWorked {  get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; } 

        public int? MinutesWorked { get; set; }

    }
}
