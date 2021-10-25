﻿using System;
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

namespace Knowledge_student
{
    /// <summary>
    /// Логика взаимодействия для StudentMenu.xaml
    /// </summary>
    public partial class StudentMenu : Page
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        private void BTNGoTest(object sender, RoutedEventArgs e)
        {
            Uri tableTests = new Uri("Table_test.xaml", UriKind.Relative);
            this.NavigationService.Navigate(tableTests);
        }
    }
}
