using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KJVfull
{
    public class KJVData
    {
        public static string cas = "[0-9]+:[0-9]+";

        public static ObservableCollection<string> CBooks = new ObservableCollection<string>();
        public static string[] OldTestement { get; set; }
        public static string[] NewTestement { get; set; }

        public static readonly KJVDataContext db = new KJVDataContext();
        public static string ChosenBook { get; set; }
        private static List<BSection> ChosenBookText { get; set; } = new List<BSection>();
        public static ObservableCollection<string> HolyText = new ObservableCollection<string>();


        public static List<Matrix> BookMatrix = new List<Matrix>();
        //----
        public static int Chapter = 0;
        //
        public static int CurChapter = 0;
        public static int CurMaxSection = 0;
        //
        public static int Section = 0;
        public static int MaxBookChapter { get; set; }
        public static void init()
        {
            if (OldTestement == null || NewTestement == null)
            {
                BookTitles();
            }
        }
        public static void Load(string pBook)
        {

            ChosenBook = pBook;
            ChosenBookText = (from b in db.BSections where b.Book.Equals(pBook) select b).ToList();
            Chapter = 1;
            Section = 1;
            getValidationData4Book(pBook);
            //

        }
        public static async Task LoadAsync(bool t)
        {
            CBooks.Clear();
            if (t == false)
            {
                foreach (string s in KJVData.NewTestement)
                    CBooks.Add(s);
            }
            else
            {
                foreach (string s in KJVData.OldTestement)
                    CBooks.Add(s);
            }
            await Task.Delay(0);
        }
        private static void getValidationData4Book(string pBook)
        {
            try
            {
                BookMatrix = (from m in db.Matrices where m.Book.Equals(pBook) select m).ToList();
                MaxBookChapter = (from d in BookMatrix select d.Chapter).Max();
            }
            catch { }


        }

        private static void BookTitles()
        {
            OldTestement = (from b in db.Books where b.ID < 40 orderby b.Name select b.Name).ToArray();
            NewTestement = (from b in db.Books where b.ID >= 40 orderby b.Name select b.Name).ToArray();

            //MessageBox.Show(OldTestement.Length.ToString()+"   "+NewTestement.Length.ToString());
        }

        public static void makeTable()//Array of strings should be loaded first.
        {
            //For boot trapping the array of classes in PDATA only.
            StreamWriter sw = new StreamWriter("NewT.txt");
            foreach (string s in NewTestement)
            {
                Load(s);
                List<TSection> found = getCHandSec();

                /*
                new BookChapters {Book="Ruth",
             Chapters = {  new ChapterEnds(1,20),new ChapterEnds(2,12 ) } }
                 */

                sw.WriteLine(string.Format("new BookChapters {{Book=\"{0}\",", s));
                sw.WriteLine("Chapters = {");
                foreach (TSection t in found)
                {
                    sw.WriteLine(string.Format("{{{0},{1}}},", t.Chapter, t.Section));
                }
                sw.WriteLine("}},");
            }

            foreach (string s in OldTestement)
            {
                Load(s);
                List<TSection> found = getCHandSec();
                sw.WriteLine(string.Format("new BookChapters {{Book=\"{0}\",", s));
                sw.WriteLine("Chapters = {");
                foreach (TSection t in found)
                {
                    sw.WriteLine(string.Format("{{{0},{1}}},", t.Chapter, t.Section));
                }
                sw.WriteLine("}},");
            }
            sw.WriteLine("};");
            sw.Flush();
            sw.Close(); sw.Dispose();

        }

        public static void RequstMatrix(string text)
        {
            string chap = text.Replace(":", "");
            int tChapter;
            int.TryParse(chap, out tChapter);
            if (tChapter > MaxBookChapter)
                return;
            CurChapter = tChapter;
            CurMaxSection = 0;
            foreach (var x in BookMatrix)
            {
                if (x.Chapter == CurChapter)
                    CurMaxSection = (int)x.LastSection;
            }
        }

        public static void RequstChapter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            string[] par = text.Split(':');

            if (par.Length == 1)
            {
                int.TryParse(par[0], out Chapter);
                Section = 1;
            }
            if(par.Length == 2)
            {
                int.TryParse(par[0], out Chapter);
                int.TryParse(par[1], out Section);
            }
            
        }

        public class TSection
        {
            public int Chapter { get; set; }
            public int Section { get; set; }

        }
        private static List<TSection> getCHandSec()
        {
            List<TSection> ret = new List<TSection>();
            List<TSection> res = (from b in ChosenBookText select new TSection { Chapter = b.Chapter, Section = b.Section }).ToList();

            int max = 0;
            var chapters = from r in res group r by r.Chapter into cGroup orderby cGroup.Key select cGroup;
            foreach (var t in chapters)
            {
                max = 0;
                foreach (var x0 in t)
                {
                    if (x0.Section > max)
                        max = x0.Section;
                }
                ret.Add(new TSection { Chapter = t.Key, Section = max });
            }
            return ret;
        }

        public static void getSection()
        {
            HolyText.Clear();

            string ttt=null;

            List<BSection> fs = (from c in ChosenBookText where c.Chapter == Chapter && c.Section == Section select c).ToList();
            foreach (BSection b in fs)
            {
                HolyText.Add(b.Text);
            }


            return;
        }

        public static void getChapter()
        {
            List<string> schapter = (from c in ChosenBookText where c.Chapter == Chapter orderby c.Section select c.Text).ToList();
            HolyText.Clear();
            foreach (string s in schapter)
            {
                HolyText.Add(s);
            }

            return;
        }
        public static void NextChapter()
        {
            if (Chapter < MaxBookChapter)
            {
                Chapter++;
                getChapter();
            }

        }
        public static void PrevChapter()
        {
            if (Chapter > 1)
            {
                Chapter--;
                getChapter();
            }

        }
        public static void NextSection()
        {
            if (isValidSection())
            {
                Section++;
                getSection();
            }

        }

        private static bool isValidSection()
        {
            foreach (Matrix ce in BookMatrix)
            {
                if (ce.Chapter == Chapter)
                {
                    if (Section < ce.LastSection)
                        return true;
                }
            }
            return false;
        }

        public static void PrevSection()
        {
            if (Section > 1)
                Section--;
            getSection();
        }
    }
}
