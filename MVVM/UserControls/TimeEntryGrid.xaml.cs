using ProjectTimeTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTimeTracking.UserControls
{
    /// <summary>
    /// Interaction logic for TimeEntryGrid.xaml
    /// </summary>
    public partial class TimeEntryGrid : UserControl
    {
        TimeEntryViewModel timeEntryViewModel;
        public TimeEntryGrid()
        {
            InitializeComponent();
            timeEntryViewModel = new TimeEntryViewModel();
            TimeEntriesDataGrid.ItemsSource = timeEntryViewModel.TimeEntries;
        }

        private void TimeEntriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit) { 
                Models.TimeEntry currentRowIndex = (Models.TimeEntry)TimeEntriesDataGrid.SelectedItem;
                MessageBox.Show($"{currentRowIndex.Description}");
            }
        }

        private void TimeEntriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Models.TimeEntry currentRowIndex = (Models.TimeEntry)TimeEntriesDataGrid.SelectedItem;
            //MessageBox.Show($"{currentRowIndex.Description}");
        }
    }
}
