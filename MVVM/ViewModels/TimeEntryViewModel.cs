using System.Collections.ObjectModel;
using ProjectTimeTracking.Models;
using ProjectTimeTracking.Context;
using System.Windows;
using ProjectTimeTracking.UserControls;
using System.Windows.Controls;

namespace ProjectTimeTracking.ViewModels
{
    public class TimeEntryViewModel: TimeEntryViewModelBase
    {
        WorkContext db = new WorkContext();
        private ObservableCollection<TimeEntry> timeEntries;

        public ObservableCollection<TimeEntry> TimeEntries
        {
            get => timeEntries;
            set
            {
                timeEntries = value;
                OnPropertyChanged(nameof(TimeEntries));
            }
        }

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

        public void UpdateData(int ItemId) {
            TimeEntry updatedTimeEntry = TimeEntries.Where(X => X.Id == ItemId).FirstOrDefault();
            db.TimeEntries.Update(updatedTimeEntry);
            db.SaveChanges();
            //MessageBox.Show($"{q.Description}");
        }

        public TimeEntry CreateRow()
        {
            TimeEntry row = new TimeEntry();
            row.ShortTitle = string.Empty;
            row.StartTime = TimeOnly.FromDateTime(DateTime.Now);
            row.DateWorked = DateOnly.FromDateTime(DateTime.Now);
            db.TimeEntries.Add(row);
            db.SaveChanges();

            return row;
        }

        public string CurrentRow {
            get { return "100";  }
             }

        public void HandleAddingNewItem(AddingNewItemEventArgs e)
        {
            e.NewItem = CreateRow();
        }

        public void HandleCellEditEnding(DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var binding = e.EditingElement.GetBindingExpression(TextBox.TextProperty);
                if (binding != null)
                {
                    binding.UpdateSource();
                }
            }

            var currentItem = e.Row.Item as TimeEntry;
            if (currentItem != null)
            {
                UpdateData(currentItem.Id);
            }
        }
    }
}
