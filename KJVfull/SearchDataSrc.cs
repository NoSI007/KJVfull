using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJVfull
{
    public class SearchDataSrc
    {
        public static readonly KJVDataContext db = new KJVDataContext();
        private static List<BSection> found { get; set; } = new List<BSection>();
        
        public static string Find(string kw)
        {
            

            if (string.IsNullOrWhiteSpace(kw))
                return "";

            string mark = string.Format("<mark>{0}</mark>", kw);

            found = (from b in db.BSections where b.Text.Contains(kw) select b).ToList();
            foreach(var t in found )
            {
                t.Text = t.Text.Replace(kw, mark);
            }

            return Save2dsik(kw);
        }
        private static string Color(string book)
        {
            int ttt = db.Books.Where(t => t.Name == book).FirstOrDefault().ID;
            var x = (from d in db.Books where d.Name == book select d).FirstOrDefault();
            if(x == null)
                return "";
            int red = 255 - (3 * x.ID);
            string color = "#"+red.ToString("X2")+"AA"+ red.ToString("X2");

            return color;
        }
        private static int ColorIdx = 0;

        private static string Color2()
        {
            int x = ColorIdx % 7;
            ColorIdx++;
            return string.Format("sp{0}",x);
        }
        private static string Save2dsik(string kw)
        {
            string file = string.Format("search-result-for-{0}.htm", kw);
            //open output file
            StreamWriter sw = new StreamWriter(file);
            //write out html header.
            
            sw.WriteLine(KJVfull.Properties.Resources.outres);
            //Add H1 tag
            string h1 = string.Format("<h1>Results For <q>{0}</q></h1>", kw);
            sw.WriteLine(h1);
            string book = found[0].Book;
            string color = Color2();
            string span = null;
            //
            // add <p> markup and write out.
            foreach(var section in found)
            {
                if(section.Book != book)
                {
                    sw.WriteLine("<hr/>");
                    book = section.Book;
                    color = Color2();
                }
                sw.Write("<p>");
                span = string.Format("<span class=\"{0}\">{1}:</span>",color,book);
                
                sw.Write(span);
 
                sw.Write(section.Text);
                sw.WriteLine("</p>");
            }
            // add </body></html>
            sw.WriteLine("</body>"); 
            sw.WriteLine("</html>");
            //close
            sw.Close();
            sw.Dispose();
            //return the file name and path.
            FileInfo fi = new FileInfo(file);
            //send file name to caller for browser uri formatted.
            return string.Format("file:///{0}", fi.FullName);
        }
    }
}
