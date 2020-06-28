using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "BlueMoon";

            Console.SetWindowSize(120, 40);
            Console.SetBufferSize(120, 9001);

            /* */
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(7);

            LoadingPage.LoadPage();
            
            /*
            Encryption e = new Encryption();
            e.Start();
            */

            Console.ReadKey();
        }

        

    }
}
