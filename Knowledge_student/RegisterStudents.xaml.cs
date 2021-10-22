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
using System.Text.RegularExpressions;

namespace Knowledge_student
{
    /// <summary>
    /// Логика взаимодействия для RegisterStudents.xaml
    /// </summary>
    public partial class RegisterStudents : Page
    {
        public RegisterStudents()
        {
            InitializeComponent();
            List<char> Genders = new List<char>() { 'м', 'ж' };
            comboBoxGender.ItemsSource = Genders;
        }

        const int minLengthOfLogin = 5;
        const int maxLengthOfLogin = 25;

        const int minLengthOfPassword = 5;
        const int maxLengthOfPassword = 60;

        const int minLenghtOfName = 2;
        const int maxLenghtOfName = 50;



        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string lastNameOfStudent = textBoxLastName.Text.Trim();
            string nameOfStudent = textBoxName.Text.Trim();
            string patronymicOfStudent = textBoxPatronymic.Text.Trim();
            string groupOfStudent = textBoxGroup.Text.Trim().ToLower();
            int groupNum;

            string loginOfStudent = textBoxLogin.Text.Trim().ToLower();
            string passwordOfStudent = passwordBox.Password.Trim();
            string passwordOfStudentRepeat = passwordBoxCheck.Password.Trim();


            if (lastNameOfStudent.Length <= minLenghtOfName || lastNameOfStudent.Length >= maxLenghtOfName || !Regex.IsMatch(lastNameOfStudent, @"[\dа-я]"))
            {
                textBoxLastName.ToolTip = $"Фамилия не должна быть меньше {minLengthOfLogin} символов или больше {maxLengthOfLogin} символов.";
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxName.Background = Brushes.Transparent;
                textBoxName.ToolTip = null;

                if (nameOfStudent.Length <= minLenghtOfName || nameOfStudent.Length >= maxLenghtOfName || !Regex.IsMatch(nameOfStudent, @"[\dа-я]"))
                {
                    textBoxName.ToolTip = $"Имя не должно быть меньше {minLengthOfLogin} символов или больше {maxLengthOfLogin} символов.";
                    var backgroundColor = new BrushConverter();
                    textBoxName.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    textBoxName.Background = Brushes.Transparent;
                    textBoxName.ToolTip = null;


                    if (patronymicOfStudent.Length <= minLenghtOfName || patronymicOfStudent.Length >= maxLenghtOfName || !Regex.IsMatch(patronymicOfStudent, @"[\dа-я]"))
                    {
                        textBoxPatronymic.ToolTip = $"Отчество не должно быть меньше {minLengthOfLogin} символов или больше {maxLengthOfLogin} символов.";
                        var backgroundColor = new BrushConverter();
                        textBoxPatronymic.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                    }
                    else
                    {
                        textBoxPatronymic.Background = Brushes.Transparent;
                        textBoxPatronymic.ToolTip = null;

                        if (comboBoxGender.SelectedIndex == -1)
                        {
                            MessageBox.Show("Вы не выбрали пол");

                        }
                        else
                        {
                            if (textBoxGroup == null)
                            {
                                textBoxGroup.ToolTip = $"The login is too short, enter more than {minLengthOfLogin} characters or more {maxLengthOfLogin} characters.";
                                var backgroundColor = new BrushConverter();
                                textBoxGroup.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                textBoxGroup.Background = Brushes.Transparent;
                                textBoxGroup.ToolTip = null;
                                Groups checkGroup = null;
                                using (var context = new Knowledge_controlEntities())
                                {
                                    checkGroup = context.Groups.Where(check => check.Name_group == groupOfStudent).FirstOrDefault();
                                }
                                if (checkGroup != null)
                                { 
                                    
                                }


                                    if (loginOfStudent.Length <= minLengthOfLogin || loginOfStudent.Length >= maxLengthOfLogin || !Regex.IsMatch(loginOfStudent, @"^[\da-z]+$"))
                            {
                                textBoxLogin.ToolTip = $"The login is too short, enter more than {minLengthOfLogin} characters or more {maxLengthOfLogin} characters.";
                                var backgroundColor = new BrushConverter();
                                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                textBoxLogin.Background = Brushes.Transparent;
                                textBoxLogin.ToolTip = null;
                                if (passwordOfStudent.Length <= minLengthOfPassword || passwordOfStudent.Length >= maxLengthOfPassword || !Regex.IsMatch(passwordOfStudent, @"^[\da-z]+$"))
                                {
                                    passwordBox.ToolTip = $"The password is too short, enter more than {minLengthOfPassword} characters or more {maxLengthOfPassword} characters.";
                                    var backgroundColor = new BrushConverter();
                                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                }
                                else
                                {
                                    passwordBox.Background = Brushes.Transparent;
                                    passwordBox.ToolTip = null;
                                    if (passwordOfStudent != passwordOfStudentRepeat)
                                    {
                                        passwordBoxCheck.ToolTip = "Passwords don't match.";
                                        var backgroundColor = new BrushConverter();
                                        passwordBoxCheck.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                    }
                                    else
                                    {
                                        passwordBoxCheck.Background = Brushes.Transparent;
                                        passwordBoxCheck.ToolTip = null;
                                        Students regStudent = null;
                                        using (var context = new Knowledge_controlEntities())
                                        {
                                            regStudent = context.Students.Where(check => check.Login == loginOfStudent).FirstOrDefault();
                                            if (regStudent == null)
                                            {
                                                var student = new Students()
                                                {
                                                    Last_name = lastNameOfStudent,
                                                    Name = nameOfStudent,
                                                    Paronymic = patronymicOfStudent,
                                                    Gender = comboBoxGender.SelectedItem.ToString(),
                                                    Number_group = , 
                                                    Login = loginOfStudent,
                                                    Password = passwordOfStudent
                                                };
                                                context.Teachers.Add(teacher);
                                                context.SaveChanges();

                                                RecordOfTeachers.recordOfTeachers = context.Teachers.Where(x => x.Login == loginOfStudent).Select(x => x).FirstOrDefault();

                                                Uri Auth = new Uri("Auth.xaml", UriKind.Relative);
                                                this.NavigationService.Navigate(Auth);
                                            }
                                            else
                                                errorBox.Text = "This login or email is already registered";
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

