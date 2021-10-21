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
    /// <summary> test2
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        const int minLengthOfLogin = 5;
        const int maxLengthOfLogin = 25;
        const int minLengthOfPassword = 5;
        const int maxLengthOfPassword = 60;

        private void Button_Auth_Click_Student(object sender, RoutedEventArgs e)
        {
            //TODO: MV
            //  - выделение модели
            //  - логика валидации в модель должна уйти
            string login = textBoxLogin.Text.Trim().ToLower();
            string password = passwordBox.Password.Trim();
            if (login.Length <= minLengthOfLogin || login.Length >= maxLengthOfLogin)
            {
                textBoxLogin.ToolTip = $"Логин слишком короткий, введите больше чем {minLengthOfLogin} символов или меньше чем {maxLengthOfLogin} символов.";
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                if (password.Length <= minLengthOfPassword || password.Length >= maxLengthOfPassword)
                {
                    passwordBox.ToolTip = $"Логин слишком короткий, введите больше чем {minLengthOfLogin} символов или меньше чем {maxLengthOfLogin} символов.";
                    var backgroundColor = new BrushConverter();
                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    passwordBox.Background = Brushes.Transparent;
                    passwordBox.ToolTip = null;
                    Students authStudents = null;
                    using (var context = new Knowledge_controlEntities())
                    {
                        authStudents = context.Students.Where(check => check.Login == login && check.Password == password).FirstOrDefault();
                    }
                    if (authStudents != null)
                    {
                        using (var context = new Knowledge_controlEntities())
                        {
                            RecordOfStudents.recordOfStudents = context.Students.Where(x => x.Login == login && x.Password == password).Select(x => x).FirstOrDefault();
                        }
                        Uri StudentMenu = new Uri("StudentMenu.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(StudentMenu);
                    }
                    else
                        errorBox.Text = "Убедитесь что вы ввели правильный логин и пароль.";
                }
            }
        }



        private void Button_Auth_Click_Teacher(object sender, RoutedEventArgs e)
        {
            //TODO: MV Test code
            //  - выделение модели
            //  - логика валидации в модель должна уйти
            string login = textBoxLogin.Text.Trim().ToLower();
            string password = passwordBox.Password.Trim();
            if (login.Length <= minLengthOfLogin || login.Length >= maxLengthOfLogin)
            {
                textBoxLogin.ToolTip = $"Логин слишком короткий, введите больше чем {minLengthOfLogin} символов или меньше чем {maxLengthOfLogin} символов.";
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxLogin.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                if (password.Length <= minLengthOfPassword || password.Length >= maxLengthOfPassword)
                {
                    passwordBox.ToolTip = $"Логин слишком короткий, введите больше чем {minLengthOfLogin} символов или меньше чем {maxLengthOfLogin} символов.";
                    var backgroundColor = new BrushConverter();
                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    passwordBox.Background = Brushes.Transparent;
                    passwordBox.ToolTip = null;
                    Teachers authTeachers = null;
                    using (var context = new Knowledge_controlEntities())
                    {
                        authTeachers = context.Teachers.Where(check => check.Login == login && check.Password == password).FirstOrDefault();
                    }
                    if (authTeachers != null)
                    {
                        using (var context = new Knowledge_controlEntities())
                        {
                            RecordOfTeachers.recordOfTeachers = context.Teachers.Where(x => x.Login == login && x.Password == password).Select(x => x).FirstOrDefault();
                        }
                        Uri TeachersMenu = new Uri("TeachersMenu.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(TeachersMenu);
                    }
                    else
                        errorBox.Text = "Убедитесь что вы ввели правильный логин и пароль.";
                }
            }
        }

        private void Button_Transition_Reg_Click(object sender, RoutedEventArgs e)
        {
            Uri Registration = new Uri("Registration.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Registration);
        }
    }
}
