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
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    /// 
    public static class RecordOfTests
    {
        public static Tests recordOfTests;
    }
    public partial class CreateTest : Page
    {
        const int minLengthName = 1;
        const int maxLenghtName = 50;
        const int maxMaxPoint = 4;

        const int minLenghtOfGroup = 5;
        const int maxLenghtOfGroup = 8;
        public CreateTest()
        {
            InitializeComponent();
        }

        private void CDis(object sender, RoutedEventArgs e)
        {
            Uri tableDis = new Uri("TableDis.xaml", UriKind.Relative);
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

        private void btnCreateTests(object sender, RoutedEventArgs e)
        {
            string disNumber = textBoxNumberDiscipline.Text.Trim().ToLower();
            string numberTheme = textBoxNumberTheme.Text.Trim();
            string nameTests = textBoxNameTest.Text.Trim();
            string maxPoint = textBoxMaxPoint.Text.Trim().ToLower();
            string nameGroup = textBoxNameGroup.Text.Trim().ToLower();

            if (!Regex.IsMatch(disNumber, @"[\d0-9]"))
            {

                textBoxNumberDiscipline.ToolTip = "Некорректно введен номер дисциплины.";
                var backgroundColor = new BrushConverter();
                textBoxNumberDiscipline.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNumberDiscipline.Background = Brushes.Transparent;
                textBoxNumberDiscipline.ToolTip = null;


                if (!Regex.IsMatch(numberTheme, @"[\d0-9]"))
                {

                    textBoxNumberTheme.ToolTip = "Некорректно введен номер темы.";
                    var backgroundColor = new BrushConverter();
                    textBoxNumberTheme.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    textBoxNumberTheme.Background = Brushes.Transparent;
                    textBoxNumberTheme.ToolTip = null;

                    if (nameTests.Length >= maxLenghtName || nameTests.Length <= minLengthName || !Regex.IsMatch(nameTests, @"[\dа-я]"))
                    {

                        textBoxNameTest.ToolTip = "Некорректно введено название теста.";
                        var backgroundColor = new BrushConverter();
                        textBoxNameTest.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                    }
                    else
                    {
                        textBoxNameTest.Background = Brushes.Transparent;
                        textBoxNameTest.ToolTip = null;


                        if (maxPoint.Length >= maxMaxPoint || !Regex.IsMatch(maxPoint, @"[\d0-9]"))
                        {

                            textBoxMaxPoint.ToolTip = "Некорректно введено кол-во баллов.";
                            var backgroundColor = new BrushConverter();
                            textBoxMaxPoint.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                        }
                        else
                        {
                            textBoxMaxPoint.Background = Brushes.Transparent;
                            textBoxMaxPoint.ToolTip = null;

                            if (nameGroup.Length >= maxLenghtOfGroup || nameGroup.Length <= minLenghtOfGroup || !Regex.IsMatch(nameGroup, @"[\dа-я]"))
                            {

                                textBoxNameGroup.ToolTip = "Некорректно введен номер группы.";
                                var backgroundColor = new BrushConverter();
                                textBoxNameGroup.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                textBoxNameGroup.Background = Brushes.Transparent;
                                textBoxNameGroup.ToolTip = null;
                                Tests addTests = null;
                                using (var context = new Knowledge_controlEntities())
                                {


                                    int intDisNumber = Convert.ToInt32(disNumber);
                                    int intNumberTheme = Convert.ToInt32(numberTheme);

                                    int intMaxPoint = Convert.ToInt32(maxPoint);



                                    if (context.Disciplines.Where(x => x.Number_discipline == intDisNumber).Select(x => x).Count() > 0)
                                    {
                                        if (context.Themes.Where(x => x.Number_theme == intNumberTheme).Select(x => x).Count() > 0)
                                        {
                                            if (context.Students.Where(x => x.Name_group == nameGroup).Select(x => x).Count() > 0)
                                            {



                                                addTests = context.Tests.Where(check => check.Name_test == nameTests).FirstOrDefault();

                                                if (addTests == null)
                                                {
                                                    var tests = new Tests()
                                                    {
                                                        Number_discipline = intDisNumber,
                                                        Number_theme = intNumberTheme,
                                                        Name_test = nameTests,
                                                        Max_point = intMaxPoint,
                                                        Number_teacher = context.Teachers.Where(x => x.Login == RecordOfTeachers.recordOfTeachers.Login).Select(x => x.Number_teacher).FirstOrDefault(),
                                                        Name_group = nameGroup 

                                                    };
                                                    context.Tests.Add(tests);
                                                    context.SaveChanges();


                                                    RecordOfTests.recordOfTests = context.Tests.Where(x => x.Name_test == nameTests).Select(x => x).FirstOrDefault();


                                                }


                                                else

                                                    MessageBox.Show("Этот тест уже существует");
                                            }
                                            else MessageBox.Show("Такой группы не существует");

                                        }
                                        else
                                            MessageBox.Show("Такой дисциплины не сущетсвует");
                                    }
                                    else
                                        MessageBox.Show("Такой темы не сущетсвует");

                                }
                            }
                        }
                    }
                }
            }



        }
    }
}
