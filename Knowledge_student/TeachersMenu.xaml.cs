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
    /// Логика взаимодействия для TeachersMenu.xaml
    /// </summary>
    public partial class TeachersMenu : Page
    {
        public TeachersMenu()
        {
            InitializeComponent();
        }

        private void Button_For_Create_Dis(object sender, RoutedEventArgs e)
        {
            Uri CreateDis = new Uri("CteateDis.xaml", UriKind.Relative);
            this.NavigationService.Navigate(CreateDis);
        }

        private void Button_For_Create_Theme(object sender, RoutedEventArgs e)
        {
            Uri CreateTheme = new Uri("CreateTheme.xaml", UriKind.Relative);
            this.NavigationService.Navigate(CreateTheme);
        }

        private void Button_For_Create_Tests(object sender, RoutedEventArgs e)
        {
            Uri CreateTests = new Uri("CreateTest.xaml", UriKind.Relative);
            this.NavigationService.Navigate(CreateTests);
        }

    }
}
