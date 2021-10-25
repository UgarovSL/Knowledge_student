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

namespace Knowledge_student
{
    /// <summary>
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    public partial class CreateTest : Page
    {
        public CreateTest()
        {
            InitializeComponent();
        }

        private void CDis(object sender, RoutedEventArgs e)
        {
            Uri tableDis = new Uri("Table_Dis.xaml", UriKind.Relative);
            this.NavigationService.Navigate(tableDis);
        }

        private void CTheme(object sender, RoutedEventArgs e)
        {
            Uri tableTheme = new Uri("Table_Theme.xaml", UriKind.Relative);
            this.NavigationService.Navigate(tableTheme);
        }

        private void btnTeatcher_Click(object sender, RoutedEventArgs e)
        {
            Uri tableTeatcher = new Uri("Table_Teatcher.xaml", UriKind.Relative);
            this.NavigationService.Navigate(tableTeatcher);
        }
    }
}
