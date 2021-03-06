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
    /// Логика взаимодействия для RegisterTeachers.xaml
    /// </summary>
    public partial class RegisterTeachers : Page
    {
        public RegisterTeachers()
        {
            InitializeComponent();
            List<char> Genders = new List<char>() { 'м', 'ж' };
            comboBoxGender.ItemsSource = Genders;
        }

        const int minLengthOfLogins = 5;
        const int maxLengthOfLogins = 25;

        const int minLengthOfPasswords = 5;
        const int maxLengthOfPasswords = 60;

        const int minLenghtOfNames = 2;
        const int maxLenghtOfNames = 50;



        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string lastNameOfTeacher = textBoxLastName.Text.Trim();
            string nameOfTeacher = textBoxName.Text.Trim();
            string patronymicOfTeacher = textBoxPatronymic.Text.Trim();
            

            string loginOfTeacher = textBoxLogin.Text.Trim().ToLower();
            string passwordOfTeacher = passwordBox.Password.Trim();
            string passwordOfTeacherRepeat = passwordBoxCheck.Password.Trim();


            if (lastNameOfTeacher.Length <= minLenghtOfNames || lastNameOfTeacher.Length >= maxLenghtOfNames || !Regex.IsMatch(lastNameOfTeacher, @"[\dа-я]"))
            {
                textBoxLastName.ToolTip = $"Фамилия не должна быть меньше {minLenghtOfNames} символов или больше {minLenghtOfNames} символов.";
                var backgroundColor = new BrushConverter();
                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxName.Background = Brushes.Transparent;
                textBoxName.ToolTip = null;

                if (nameOfTeacher.Length <= minLenghtOfNames || nameOfTeacher.Length >= minLenghtOfNames || !Regex.IsMatch(nameOfTeacher, @"[\dа-я]"))
                {
                    textBoxName.ToolTip = $"Имя не должно быть меньше {minLenghtOfNames} символов или больше {minLenghtOfNames} символов.";
                    var backgroundColor = new BrushConverter();
                    textBoxName.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    textBoxName.Background = Brushes.Transparent;
                    textBoxName.ToolTip = null;


                    if (patronymicOfTeacher.Length <= minLenghtOfNames || patronymicOfTeacher.Length >= minLenghtOfNames || !Regex.IsMatch(patronymicOfTeacher, @"[\dа-я]")) 
                    {
                        textBoxPatronymic.ToolTip = $"Отчество не должно быть меньше {minLenghtOfNames} символов или больше {minLenghtOfNames} символов.";
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
                            

                            if (loginOfTeacher.Length <= minLengthOfLogins || loginOfTeacher.Length >= maxLengthOfLogins || !Regex.IsMatch(loginOfTeacher, @"^[\da-z]+$"))
                            {
                                textBoxLogin.ToolTip = $"Логин не должнен быть меньше {minLengthOfLogins} символов или больше {minLengthOfLogins} символов.";
                                var backgroundColor = new BrushConverter();
                                textBoxLogin.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                textBoxLogin.Background = Brushes.Transparent;
                                textBoxLogin.ToolTip = null;
                                if (passwordOfTeacher.Length <= minLengthOfPasswords || passwordOfTeacher.Length >= maxLengthOfPasswords || !Regex.IsMatch(passwordOfTeacher, @"^[\da-z]+$"))
                                {
                                    passwordBox.ToolTip = $"Пароль не должен быть короче чем {minLengthOfPasswords} символов или больше {maxLengthOfPasswords} символов.";
                                    var backgroundColor = new BrushConverter();
                                    passwordBox.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                }
                                else
                                {
                                    passwordBox.Background = Brushes.Transparent;
                                    passwordBox.ToolTip = null;
                                    if (passwordOfTeacher != passwordOfTeacherRepeat)
                                    {
                                        passwordBoxCheck.ToolTip = "Неверный пароль.";
                                        var backgroundColor = new BrushConverter();
                                        passwordBoxCheck.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                    }
                                    else
                                    {
                                        passwordBoxCheck.Background = Brushes.Transparent;
                                        passwordBoxCheck.ToolTip = null;
                                        Teachers regTeachers = null;
                                        using (var context = new Knowledge_controlEntities())
                                        {
                                            regTeachers = context.Teachers.Where(check => check.Login == loginOfTeacher).FirstOrDefault();
                                            if (regTeachers == null)
                                            {
                                                var teacher = new Teachers()
                                                {
                                                    Last_name = lastNameOfTeacher,
                                                    Name = nameOfTeacher,
                                                    Patronymic = patronymicOfTeacher,                                                  
                                                    Gender = comboBoxGender.SelectedItem.ToString(),
                                                    Login = loginOfTeacher,
                                                    Password = passwordOfTeacher
                                                };
                                                context.Teachers.Add(teacher);
                                                context.SaveChanges();

                                                RecordOfTeachers.recordOfTeachers = context.Teachers.Where(x => x.Login == loginOfTeacher).Select(x => x).FirstOrDefault();

                                                Uri Auth = new Uri("Auth.xaml", UriKind.Relative);
                                                this.NavigationService.Navigate(Auth);
                                            }
                                            else
                                                errorBox.Text = "Данный логин уже существует.";
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
