using System.Windows;
using System.Windows.Controls;
using ProjectTimeTracking.UserControls;
using ProjectTimeTracking.ViewModels;

namespace ProjectTimeTracking.UserControls
{
    /// <summary>
    /// Interaction logic for MenuButtonStrip.xaml
    /// </summary>
    public partial class MenuButtonStrip : UserControl
    {
        public TimeEntryViewModel timeEntryViewModel;
        public MenuButtonStrip()
        {
            InitializeComponent();
            DataContextChanged += TimeEntryGrid_DataContextChanged;
        }

        private void TimeEntryGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            timeEntryViewModel = DataContext as TimeEntryViewModel;
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            timeEntryViewModel.DeleteSelectingItem();
        }

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            timeEntryViewModel.HandleAddingNewItemFromAddButton(e);
        }
    }
}
