using Microsoft.EntityFrameworkCore;
using ProjectTimeTracking.Models;

namespace ProjectTimeTracking.Context
{
    public class WorkContext: DbContext
    {
        public DbSet<Project> Projects{ get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        public string DbPath { get; }

        public WorkContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "blogging.db");
            DbPath = @"C:\temp\time_tracking.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
