﻿using System.Collections.ObjectModel;
using System.Windows;
using ProjectTimeTracking.UserControls;
using ProjectTimeTracking.ViewModels;

namespace ProjectTimeTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TimeEntryViewModel();
        }



    }
}