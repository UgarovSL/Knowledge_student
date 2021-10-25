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
    /// Логика взаимодействия для CreateTheme.xaml
    /// </summary>
    public partial class CreateTheme : Page
    {
        public CreateTheme()
        {
            InitializeComponent();
        }

        private void BTChechDis(object sender, RoutedEventArgs e)
        {

            Uri checkDis = new Uri("Table_dis.xaml", UriKind.Relative);
            this.NavigationService.Navigate(checkDis);
        }
    }
}
