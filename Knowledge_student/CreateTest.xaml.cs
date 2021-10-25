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
    public partial class CreateTest : Page
    {
        const int minLengthName = 1;
        const int maxLenghtName = 50;
        const int maxMaxPoint = 4;
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

        private void btnCreateTests(object sender, RoutedEventArgs e)
        {
            string disNumber = textBoxNumberDiscipline.Text.Trim().ToLower();
            string numberTheme = textBoxNumberTheme.Text.Trim();
            string nameTests = textBoxNameTest.Text.Trim();
            string maxPoint = textBoxMaxPoint.Text.Trim().ToLower();
            string numberTeacher = textBoxNumberTeacher.Text.Trim().ToLower();

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
            }

            if ( !Regex.IsMatch(disNumber, @"[\d0-9]"))
            {

                textBoxNumberTheme.ToolTip = "Некорректно введен номер темы.";
                var backgroundColor = new BrushConverter();
                textBoxNumberTheme.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNumberTheme.Background = Brushes.Transparent;
                textBoxNumberTheme.ToolTip = null;
            }
            if (nameTests.Length >=maxLenghtName || nameTests.Length <= minLengthName || !Regex.IsMatch(nameTests, @"[\dа-я]"))
            {

                textBoxNameTest.ToolTip = "Некорректно введено название теста.";
                var backgroundColor = new BrushConverter();
                textBoxNameTest.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNameTest.Background = Brushes.Transparent;
                textBoxNameTest.ToolTip = null;
            }

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
            }
            if (!Regex.IsMatch(numberTeacher, @"[\d0-9]"))
            {

                textBoxNumberTeacher.ToolTip = "Некорректно введен номер преподавателя.";
                var backgroundColor = new BrushConverter();
                textBoxNumberTeacher.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNumberTeacher.Background = Brushes.Transparent;
                textBoxNumberTeacher.ToolTip = null;



            }
    }
