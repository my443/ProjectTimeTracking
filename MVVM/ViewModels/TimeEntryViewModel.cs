using System.Collections.ObjectModel;
using ProjectTimeTracking.Models;
using ProjectTimeTracking.Context;
using System.Windows;

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
            TimeEntries = new ObservableCollection<TimeEntry>(timeEntries);
        }

        public void updateData(int ItemId) {
            TimeEntry updatedTimeEntry = TimeEntries.Where(X => X.Id == ItemId).FirstOrDefault();
            db.TimeEntries.Update(updatedTimeEntry);
            db.SaveChanges();
            //MessageBox.Show($"{q.Description}");
        }
    }
}
