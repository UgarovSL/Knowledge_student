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
    /// Логика взаимодействия для Table_Teatcher.xaml
    /// </summary>
    public partial class Table_Teatcher : Page
    {
        public Table_Teatcher()
        {

            InitializeComponent();
            DGTeatcher.ItemsSource = Knowledge_controlEntities.GetContext().Teachers.ToList();
        }

        private void BackCreateTest(object sender, RoutedEventArgs e)
        {

            Uri createTest = new Uri("CreateTest.xaml", UriKind.Relative);
            this.NavigationService.Navigate(createTest);
        }
    }
}
