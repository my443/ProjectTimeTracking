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
        public MenuButtonStrip()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(sender.ToString());
        }

    }
}
