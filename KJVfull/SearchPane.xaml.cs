using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for SearPane.xaml
    /// </summary>
    public partial class SearchPane : Window
    {
        public SearchPane()
        {
            InitializeComponent();
        }

        private void xFind_Click(object sender, RoutedEventArgs e)
        {
            Find4kw();
        }

        private void Find4kw()
        {
            string kw = xKeywords.Text.Trim();

            if (string.IsNullOrWhiteSpace(kw))
                return;
            try
            {
                Process.Start(SearchDataSrc.Find(kw));

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
