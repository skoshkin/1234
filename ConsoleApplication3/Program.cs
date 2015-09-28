using System;
using static System.String;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsoleApplication1
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string s;
            Clipboard.Clear();

            //защита на тот случай если буфер пуст
            while (Clipboard.GetText() == "")
            {
                Console.WriteLine("скопируйте текст, затем выделите это окно, и нажмите любую клавишу"); 
                Console.ReadKey();
            }

            s = Clipboard.GetText();
            var words = s.Split( ' ' );
            
            //длее закоментирована строка которая должна выставлять лимит в 1000 слов и убирать пустые строки
            //но не работает. Причину найти не удалось. Оставляю как знак того что что-то все таки пытался сделать.
            //var words = s.Split(new char[] { ' ' }, 1000, StringSplitOptions.RemoveEmptyEntries);
            
            List<string> l = new List<string>();

            foreach (var word in words)
            {
                var cl = word.Replace(",", " ").Replace(".", "").Replace(";", "").Replace(":", "");

                l.Add(cl);
            }
            l.Sort(StringComparer.CurrentCultureIgnoreCase);
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
             
        }
    }
}