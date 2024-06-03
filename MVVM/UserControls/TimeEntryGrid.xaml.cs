using ProjectTimeTracking.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ProjectTimeTracking.UserControls
{
    /// <summary>
    /// Interaction logic for TimeEntryGrid.xaml
    /// </summary>
    public partial class TimeEntryGrid : UserControl
    {
        public TimeEntryViewModel timeEntryViewModel;
        
        public TimeEntryGrid()
        {
            InitializeComponent();
            DataContextChanged += TimeEntryGrid_DataContextChanged;
        }

        private void TimeEntryGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            timeEntryViewModel = DataContext as TimeEntryViewModel;
        }

        private void TimeEntriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            timeEntryViewModel?.HandleCellEditEnding(e);
        }

        private void TimeEntriesDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            timeEntryViewModel?.HandleAddingNewItem(e);
        }

    }
}
