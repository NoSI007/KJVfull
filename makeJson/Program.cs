using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeJson
{
    internal class Program
    {
        public static kjVDataContext db = new kjVDataContext();
        static List<json4section> jsondata;
        static void Main(string[] args)
        {
            jsondata  = db.json4sections.ToList();

            //using the newly jasonize table
            // I can use this to create any table.
            List<json4section> data = new List<json4section>();
            string fname;
            int start = 0;
            int max = getMaxfrom(start);

            for(int i = 0; ;i++)
            {
                fname = String.Format("p{0}.txt", i);
                StreamWriter sw = new StreamWriter(fname);
                Console.WriteLine("start({0}) -- max({1})",start,max);
                data.AddRange(jsondata.Skip(start).Take(max));
                //
                process(data,sw);
                sw.Close();
                sw.Dispose();
                //
                if (start >= jsondata.Count-1)
                    break;
                start = max;
                max = getMaxfrom(start);
                if(max == 1 ) break;
                data.Clear();
            
            }
            
           

            

        }
        //for now this is not accurate 
        // if last line just missed 
        // next line very large..
        private static int getMaxfrom(int start)
        {
            int mx = 0;
            int ret = 0;
            if (start == jsondata.Count - 1)
                return 0;

            for(int i=start;i< jsondata.Count;i++)
            {
                mx += jsondata[i].jsont.Length;
                ret = i;
                if (mx >= 2500000)
                    break;
            }
            return ret+1;
        }

        private static void process(List<json4section> data, StreamWriter sw)
        {
            sw.WriteLine("[");
            foreach (var j in data)
            {
                sw.WriteLine(j.jsont);
                sw.Write(";");
            }
            sw.WriteLine("]");
        }
        /*
foreach(object s in q1)
   {
       ln = s.ToString().Replace("},{", "},\n{");
       sw.WriteLine(ln);
   }

*/
    }
}
