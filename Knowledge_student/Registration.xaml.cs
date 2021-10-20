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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    /// RecordOfStudents



    public static class RecordOfStudents
    {
        public static Students recordOfStudents;
    }

    public static class RecordOfTeachers
    {
        public static Teachers recordOfTeachers;
    }


    public partial class Registration : Page
    {

        private void Button_Back_Page_Click(object sender, RoutedEventArgs e)
        {
            Uri Auth = new Uri("Auth.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Auth);
        }

        private void Button_Register_Students(object sender, RoutedEventArgs e)
        {
            Uri RegisterStudents = new Uri("RegisterStudents.xaml", UriKind.Relative);
            this.NavigationService.Navigate(RegisterStudents);
        }

        private void Button_Register_Teachers(object sender, RoutedEventArgs e)
        {
            Uri RegisterTeachers = new Uri("RegisterTeachers.xaml", UriKind.Relative);
            this.NavigationService.Navigate(RegisterTeachers);
        }
      
    }
}
