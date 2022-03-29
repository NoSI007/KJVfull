using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

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
            //outTxt();
        }

        private void outTxt()
        {
            string ln;
            var db = KJVData.db;

            var otr = (from ot in db.BSections orderby ot.ID select ot).Take(15000).ToList();

            StreamWriter sw = new StreamWriter("p1.txt");
            WritIt(otr, sw);
            //
            var ntr = (from ot in db.BSections orderby ot.ID select ot).Skip(15000).ToList();

            StreamWriter sw0 = new StreamWriter("p2.txt");
            WritIt(ntr, sw0);

        }

        private  void WritIt(List<BSection> otr, StreamWriter sw)
        {
            string ln;
            foreach (BSection b in otr)
            {
                ln = string.Format("{0}^{1}:{2}^{3}", b.Book, b.Chapter, b.Section, b.Text);
                sw.WriteLine(ln);
            }
            sw.Close();
            sw.Dispose();
            
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
