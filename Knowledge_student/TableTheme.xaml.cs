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
    /// Логика взаимодействия для TableTheme.xaml
    /// </summary>
    public partial class TableTheme : Page
    {
        public TableTheme()
        {
            InitializeComponent();
            DGTheme.ItemsSource = Knowledge_controlEntities.GetContext().Themes.ToList();
        }
        private void CB(object sender, RoutedEventArgs e)
        {
            Uri createQue = new Uri("CreateQuestion.xaml", UriKind.Relative);
            this.NavigationService.Navigate(createQue);
        }
    }
}
