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
using System.Windows.Shapes;

namespace KJVfull
{
    /// <summary>
    /// Interaction logic for Bible.xaml
    /// </summary>
    public partial class Bible : Window
    {
        public Bible()
        {
            InitializeComponent();
        }

        private void xRead_Click(object sender, RoutedEventArgs e)
        {
            MainWindow read = new MainWindow();
            this.Visibility = Visibility.Hidden;
            read.ShowDialog();
            this.Visibility= Visibility.Visible;

        }

        private void xSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchPane search = new SearchPane();
            this.Visibility = Visibility.Hidden;
            search.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
