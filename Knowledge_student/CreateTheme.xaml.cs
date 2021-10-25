using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CreateTheme.xaml
    /// </summary>
    public partial class CreateTheme : Page
    {
        public static class ThemesRecord
        {
            public static Themes themesRecord;
        }
        public CreateTheme()
        {
            InitializeComponent();
        }

        private void BTChechDis(object sender, RoutedEventArgs e)
        {

            Uri checkDis = new Uri("Table_dis.xaml", UriKind.Relative);
            this.NavigationService.Navigate(checkDis);
        }

        private void btnCreateTheme(object sender, RoutedEventArgs e)
        {
            string Dis_Number = textBoxNumberDiscipline.Text.Trim().ToLower();
            string Nametheme = textBoxNameThemes.Text.Trim();


            if (!Regex.IsMatch(Dis_Number, @"[\d0-9]"))
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
            if (!Regex.IsMatch(Nametheme, @"[\dа-я]"))
            {

                textBoxNameThemes.ToolTip = "Некорректно введено название темы.";
                var backgroundColor = new BrushConverter();
                textBoxNameThemes.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNameThemes.Background = Brushes.Transparent;
                textBoxNameThemes.ToolTip = null;

                Themes addThemes = null;
                using (var context = new Knowledge_controlEntities())
                {
                    string lor = Dis_Number.ToString();
                    int r = Convert.ToInt32(lor);
                    addThemes = context.Themes.Where(check => check.Number_discipline == r).FirstOrDefault();
                    if (addThemes == null)
                    {
                        var themes = new Themes()
                        {
                            Number_discipline = r,
                            Name_theme = Nametheme,

                        };
                        context.Themes.Add(themes);
                        context.SaveChanges();

                        ThemesRecord.themesRecord = context.Themes.Where(x => x.Name_theme == Nametheme).Select(x => x).FirstOrDefault();


                    }


                    else

                        MessageBox.Show("Эта тема уже существует");

                }

            }
        }
    }
}
