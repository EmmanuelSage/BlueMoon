using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class AsciiClass
    {
        public void BlueMoon(int row)
        {
            DateBanner();
            DisplayUser();
            Console.SetCursorPosition(51,row);
            Console.ForegroundColor = Station.consoleColMain;
            Console.WriteLine(@"                                                                                         
                               @@@@'  @`   @   +@ :@@@@    @@,   @@:  #@@@:   #@@@:  @@.  @                    
                               @+ ,@  @`   @   +@ :@       @'@  .@@: #@  `@, #@  `@, @+@  @                    
                               @+ :@  @`   @   +@ :@       @ @  @'@: @:   @@ @:   @@ @,@` @                    
                               @@@@#  @`   @   +@ :@@@,    @ @' @ @: @.   #@ @.   #@ @:'@ @                    
                               @+  @: @`   @   +@ :@       @ :@'@ @: @,   @@ @,   @@ @: @ @                    
                               @+  @' @`   @,  @# :@       @  @@, @: @#   @: @#   @: @: :#@                    
                               @@@@@  @@@@ '@@@@  :@@@@    @  @@  @:  @@@@@   @@@@@  @:  @@                    
                                                                                                          ");
           
        }


        private void DisplayUser()
        {
            Console.SetCursorPosition(2, 38);
            Console.ForegroundColor = Station.consoleColMain; ;

            if (Station.loggedIn)
            {
                Console.WriteLine("Logged in as : {0}", Station.username);
            }
        }

        public void PAssist(int row)
        {
            Console.SetCursorPosition(51, row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"                                                                                         
                               ,%@@@@@@&(                     ./@@@#,    ./%@@@@@,  ./%@@@@@#  *%@&  ./%@@@@@#,%@@@@@@@@@@,          
                               *%@&*,/%@@,                    *%&&@&(.  .(&@/,,*(, .(&@/,,*((  *%@& .(&@%,,*(( .,,,(@&(*,,           
                               *%@&   /&@*                   .#@**%@&/  .(@@/.     .(@@/.      *%@& .(@@%.         *@&/              
                               *%@@%%&@@%.                  ,#@%  *%@&    ,(@@@@%,   ,(@@@@%(  *%@&   ,(%@@@%(     *@&/              
                               *%@@%%%(*.                  .(&@@%%%@@@,     .*(&@%,    .*(&@@, *%@&      *(&@@,    *@&/              
                               *%@&              .,,       *&@@%%%%%&@#, ..   ./&%,...   ./&@, *%@&  ..   ./&@,    *@&/              
                               *%@&             *%@&.     *&@%,     ,#@#/#@@@@@@%. ,#@@@@@@%/  *%@&.,#@@@@@@%/     *@&/              
                                                                                                           ");
            Console.ReadLine();
            Console.ReadKey();
        }

        public static void PrintAscii()
        {
            //Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

            Console.BackgroundColor = ConsoleColor.White;

            for (int i = 0; i < 256; i++)
            {

                Console.Write("{0} = {1} ",i,(char)i);

                if (i % 10 == 0)
                {
                    Console.Write("\n");
                }

            }
            
            
            
            Console.ReadKey();
        }

        private static void DateBanner()
        {
           
                Console.SetCursorPosition(100, 1);
                Console.ForegroundColor = Station.consoleColMain;

            string day = DateTime.Now.DayOfWeek.ToString();

                string monthString = DateTime.Now.Month.ToString();

                string year = DateTime.Now.Year.ToString();

                string month = null;

            switch (monthString)
            {
                case "6":
                    month = "June";
                    break;

                case "7":
                    month = "July";
                    break;

            }

                Console.Write("{0} {1} {2}.", day, month, year);

          
        }

    }
}
















/*   readjustment col
 Console.WriteLine(@"                                                                                         
           @@@@'  @`   @   +@ :@@@@    @@,   @@:  #@@@:   #@@@:  @@.  @                    
           @+ ,@  @`   @   +@ :@       @'@  .@@: #@  `@, #@  `@, @+@  @                    
           @+ :@  @`   @   +@ :@       @ @  @'@: @:   @@ @:   @@ @,@` @                    
           @@@@#  @`   @   +@ :@@@,    @ @' @ @: @.   #@ @.   #@ @:'@ @                    
           @+  @: @`   @   +@ :@       @ :@'@ @: @,   @@ @,   @@ @: @ @                    
           @+  @' @`   @,  @# :@       @  @@, @: @#   @: @#   @: @: :#@                    
           @@@@@  @@@@ '@@@@  :@@@@    @  @@  @:  @@@@@   @@@@@  @:  @@                    
                                                                                          ");
                                                                                          
    
    */


/*

   ,%@@@@@@&(                     ./@@@#,    ./%@@@@@,  ./%@@@@@#  *%@&  ./%@@@@@#,%@@@@@@@@@@,          
   *%@&*,/%@@,                    *%&&@&(.  .(&@/,,*(, .(&@/,,*((  *%@& .(&@%,,*(( .,,,(@&(*,,           
   *%@&   /&@*                   .#@**%@&/  .(@@/.     .(@@/.      *%@& .(@@%.         *@&/              
   *%@@%%&@@%.                  ,#@%  *%@&    ,(@@@@%,   ,(@@@@%(  *%@&   ,(%@@@%(     *@&/              
   *%@@%%%(*.                  .(&@@%%%@@@,     .*(&@%,    .*(&@@, *%@&      *(&@@,    *@&/              
   *%@&              .,,       *&@@%%%%%&@#, ..   ./&%,...   ./&@, *%@&  ..   ./&@,    *@&/              
   *%@&             *%@&.     *&@%,     ,#@#/#@@@@@@%. ,#@@@@@@%/  *%@&.,#@@@@@@%/     *@&/              


*/