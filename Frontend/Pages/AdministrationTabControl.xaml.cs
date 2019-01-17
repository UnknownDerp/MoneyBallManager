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
using CommandQuery.DatabaseContext;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class AdministrationTabControl : UserControl
    {
        public AdministrationTabControl()
        {
            InitializeComponent();
        }


        private void ResetDatabase_buttonClick(object sender, RoutedEventArgs e)
        {
            var dbCommun = new DatabaseCommunicator();
            dbCommun.ResetDatabase();
        }
    }
}
