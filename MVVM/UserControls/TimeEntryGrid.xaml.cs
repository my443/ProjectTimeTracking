﻿using ProjectTimeTracking.Models;
using ProjectTimeTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public TimeEntryViewModel timeEntryViewModel;
        
        public TimeEntryGrid()
        {
            InitializeComponent();
            DataContextChanged += TimeEntryGrid_DataContextChanged;
            //timeEntryViewModel = new TimeEntryViewModel();
            //TimeEntryDataGrid.ItemsSource = timeEntryViewModel.TimeEntries;
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
        //private void TimeEntriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if (e.EditAction == DataGridEditAction.Commit)
        //    {
        //        // Force update to ensure property change notification
        //        var binding = e.EditingElement.GetBindingExpression(TextBox.TextProperty);
        //        if (binding != null)
        //        {
        //            binding.UpdateSource();
        //        }
        //    }

        //    var currentItem = TimeEntryDataGrid.SelectedItem as TimeEntry;
            
        //    //Models.TimeEntry currentRowIndex = (Models.TimeEntry)TimeEntriesDataGrid.SelectedItem;
        //    timeEntryViewModel.updateData(currentItem.Id);
        //    //MessageBox.Show($"{currentRowIndex.Description}");
        //}

        //private void TimeEntriesDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        //{
        //    //timeEntryViewModel.createRow();
        //    e.NewItem = timeEntryViewModel.createRow();

        //}

        //private void TimeEntriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if (e.EditAction == DataGridEditAction.Commit)
        //    {
        //        TimeEntriesDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
        //        Models.TimeEntry currentRowIndex = (Models.TimeEntry)TimeEntriesDataGrid.SelectedItem;
        //        MessageBox.Show($"{currentRowIndex.Description}");
        //    }

        //}

    }
}
