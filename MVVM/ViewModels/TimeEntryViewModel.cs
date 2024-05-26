using System.Collections.ObjectModel;
using ProjectTimeTracking.Models;
using ProjectTimeTracking.Context;

namespace ProjectTimeTracking.ViewModels
{
    public class TimeEntryViewModel: TimeEntryViewModelBase
    {
        WorkContext db = new WorkContext();
        public ObservableCollection<TimeEntry> TimeEntries;


        public TimeEntryViewModel()
        {
            TimeEntries = new ObservableCollection<TimeEntry>();
            loadData();            
        }

        public void loadData()
        {
            List<TimeEntry> timeEntries = db.TimeEntries.ToList();
            //foreach (var timeEntry in timeEntries)
            //{
            //    Console.WriteLine(timeEntry.ShortTitle);
            //}
            TimeEntries = new ObservableCollection<TimeEntry>(timeEntries);
        }
    }
}
