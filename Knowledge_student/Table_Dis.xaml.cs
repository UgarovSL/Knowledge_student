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
    /// Логика взаимодействия для Table_Dis.xaml
    /// </summary>
    public partial class Table_Dis : Page
    {
        public Table_Dis()
        {
            InitializeComponent();
            DGDis.ItemsSource = Knowledge_controlEntities.GetContext().Disciplines.ToList();
        }

        private void CB(object sender, RoutedEventArgs e)
        {
            Uri createTheme = new Uri("CreateTheme.xaml", UriKind.Relative);
            this.NavigationService.Navigate(createTheme);
        }
    }
}
