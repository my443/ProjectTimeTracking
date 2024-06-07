using System.Collections.ObjectModel;
using ProjectTimeTracking.Models;
using ProjectTimeTracking.Context;
using System.Windows.Controls;
using System.Windows;

namespace ProjectTimeTracking.ViewModels
{
    public class TimeEntryViewModel : TimeEntryViewModelBase
    {
        WorkContext db = new WorkContext();
        private ObservableCollection<TimeEntry> timeEntries;
        private TimeEntry selectedTimeEntry;
        private Visibility dataGridVisibility = Visibility.Visible;

        public ObservableCollection<TimeEntry> TimeEntries
        {
            get => timeEntries;
            set
            {
                timeEntries = value;
                OnPropertyChanged(nameof(TimeEntries));
            }
        }

        public TimeEntry SelectedTimeEntry
        {
            get => selectedTimeEntry;
            set
            {
                selectedTimeEntry = value;
                OnPropertyChanged(nameof(SelectedTimeEntry));
            }
        }

        public Visibility DataGridVisibility {
            get => dataGridVisibility;
            set
            {
                dataGridVisibility = Visibility.Hidden;
                OnPropertyChanged(nameof(DataGridVisibility));
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

        public void UpdateData(int ItemId)
        {
            TimeEntry updatedTimeEntry = TimeEntries.Where(X => X.Id == ItemId).FirstOrDefault();
            db.TimeEntries.Update(updatedTimeEntry);
            db.SaveChanges();
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

        public void HandleAddingNewItem(AddingNewItemEventArgs e)
        {
            e.NewItem = CreateRow();
        }

        public void HandleAddingNewItemFromAddButton(RoutedEventArgs e)
        {
            //var newpage = new Pages.TimeEntryPage();

            //newpage.Show();
            DataGridVisibility = Visibility.Visible;
            MessageBox.Show("new item");
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

        internal void DeleteSelectingItem()
        {
            if (selectedTimeEntry != null)
            {
                db.TimeEntries.Remove(selectedTimeEntry);
                db.SaveChanges();
                loadData();
            }
        }


    }
}
