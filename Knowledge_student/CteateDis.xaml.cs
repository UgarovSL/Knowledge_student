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
    /// Логика взаимодействия для CteateDis.xaml
    /// </summary>
    /// 
    public static class RecordOfDisciplines
    {
        public static Disciplines recordOfDisciplines;
    }
    public partial class CteateDis : Page
    {
        public CteateDis()
        {
            InitializeComponent();
        }

        const int minLengthOfNameDis = 2;
        const int maxLengthOfNameDis = 60;

        private void Button_to_Create_Theme(object sender, RoutedEventArgs e)
        {

            Uri createTheme = new Uri("CreateTheme.xaml", UriKind.Relative);
            this.NavigationService.Navigate(createTheme);
        }
        private void Button_Exit_to_Menu(object sender, RoutedEventArgs e)
        {

            Uri teachersMenu = new Uri("TeachersMenu.xaml", UriKind.Relative);
            this.NavigationService.Navigate(teachersMenu);
        }

        private void Button_Create_Dis(object sender, RoutedEventArgs e)
        {
            string nameDiscipline = textBoxNameDiscipline.Text.Trim();

            if (nameDiscipline.Length <= minLengthOfNameDis || nameDiscipline.Length >= maxLengthOfNameDis || !Regex.IsMatch(nameDiscipline, @"[\dа-я]"))
            {
                textBoxNameDiscipline.ToolTip = $"Дисциплина не должна быть меньше {minLengthOfNameDis} символов или больше {maxLengthOfNameDis} символов.";
                var backgroundColor = new BrushConverter();
                textBoxNameDiscipline.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNameDiscipline.Background = Brushes.Transparent;
                textBoxNameDiscipline.ToolTip = null;
                Disciplines createDisciplines = null;
                using (var context = new Knowledge_controlEntities())
                {
                    createDisciplines = context.Disciplines.Where(check => check.Name_discipline == nameDiscipline).FirstOrDefault();
                    if (createDisciplines == null)
                    {
                        var discipline = new Disciplines()
                        {
                            Name_discipline = nameDiscipline
                        };
                        context.Disciplines.Add(discipline);
                        context.SaveChanges();

                        RecordOfDisciplines.recordOfDisciplines = context.Disciplines.Where(x => x.Name_discipline == nameDiscipline).Select(x => x).FirstOrDefault();


                    }
                    else
                        errorBox.Text = "Данная дисциплина уже существует.";
                }

            }

        }
    }


}
