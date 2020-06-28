using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class Station
    {
        private static Thread t;

        public static ConsoleColor consoleColMain = ConsoleColor.Cyan;
        public static ConsoleColor consoleColSub = ConsoleColor.DarkCyan;

        public static bool loggedIn { get; set; }

        private static string _username;
        public static string username { get { return _username; } }

        private static string _passHide;
        public static string passHide { get { return _passHide; } }

        private static string _appColor;
        public static string appcolor { get { return _appColor; } }

        private static string[] _defaultSettings = { "Admin", "pass", "A", "Cyan" };

        public static string[] defaultSettings { get { return _defaultSettings; } }

        private static string _password;
        public static string password { get { return _password; } }

        public static void SetterDefault()
        {
            
            string curPath = Directory.GetCurrentDirectory();
            string path = curPath + "\\Settings.ebase";
            string tempPath = curPath + "\\temp.txt";

            
            //
            _username = _defaultSettings[0];
            _password = _defaultSettings[1];
            _passHide = _defaultSettings[2];
            _appColor = _defaultSettings[3];

            File.WriteAllLines(tempPath, _defaultSettings);
                        
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Configuring files(Decrypting)");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Configuring files..(Encrypting)");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Configuring files (checking Login State)");
            
            File.Move("temp.txt", "Settings.ebase");

            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Loading Theme Color");

            
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Theme Loaded");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Ensuring use state.");

            Encryption.Encrypt(path);

            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Checking app state.");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Files Accessing...");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Files Configured");
        }

        public static void SetterFile()
        {
            //3,38
            
            string curPath = Directory.GetCurrentDirectory();
            string path = curPath + "\\Settings.ebase";
            string tempPath = curPath + "\\temp.txt";

            Encryption.Decrypt(path);

            string[] EbRows = File.ReadAllLines(path);

            //
            _username = EbRows[0];
            _password = EbRows[1];
            _passHide = EbRows[2];
            _appColor = EbRows[3];

            
            Encryption.Encrypt(path);

            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Configuring files...");
            Thread.Sleep(1000);
            writerClearedRow(3, 38, "Files Configured.");
        }

        public static void SetColor()
        {
            if (_appColor == "Cyan")
            {                
                consoleColMain = ConsoleColor.Cyan;
                consoleColSub = ConsoleColor.DarkCyan;
                
            }
            else if (_appColor == "Green")
            {
                consoleColMain = ConsoleColor.Green;
                consoleColSub = ConsoleColor.DarkGreen;
            }
            else if (_appColor == "Blue")
            {
                consoleColMain = ConsoleColor.Blue;
                consoleColSub = ConsoleColor.DarkBlue;
            }
            else if (_appColor == "Gray")
            {
                consoleColMain = ConsoleColor.Gray;
                consoleColSub = ConsoleColor.DarkGray;
            }
            else if (_appColor == "Magenta")
            {
                consoleColMain = ConsoleColor.Magenta;
                consoleColSub = ConsoleColor.DarkMagenta;
            }
            else if (_appColor == "Red")
            {
                consoleColMain = ConsoleColor.Red;
                consoleColSub = ConsoleColor.DarkRed;
            }
            else if (_appColor == "Yellow")
            {
                consoleColMain = ConsoleColor.Yellow;
                consoleColSub = ConsoleColor.DarkYellow;
            }
        }

        public static void Border(int top, int left, int width, int height)
        {
            int Sc = left;
            int Sr = top;

            int r = Sr;
            int c = Sc;

            int lenW = width;

            int lenH = height;

            //up c++
            for (int i = 0; i < lenW; i++)
            {
                Console.SetCursorPosition(c, r);
                Console.Write("=");
                c++;
            }

            // left r++
            for (int i = 0; i < lenH; i++)
            {
                Console.SetCursorPosition(Sc, r);
                Console.Write("|");
                r++;
            }


            //right Sr++
            for (int i = 0; i < lenH; i++)
            {
                Console.SetCursorPosition(c, Sr);
                Console.Write("|");
                Sr++;
            }

            //down Sc++
            lenW = lenW - 1;
            Sc = Sc + 1;
            r = r - 1;
            for (int i = 0; i < lenW; i++)
            {
                Console.SetCursorPosition(Sc, r);
                Console.Write("=");
                Sc++;
            }

        }

        public static void Highlight(int left, int top, string message)
        {
            Console.ForegroundColor = Station.consoleColSub;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(message);
            Thread.Sleep(300);

            Console.ForegroundColor = Station.consoleColMain; ;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(message);
            Thread.Sleep(200);
        }

        public static void BorderThread(int left, int top, int width, int height, int speed)
        {
            Console.CursorVisible = false;

            int Sc = left;
            int Sr = top;

            int r = Sr;
            int c = Sc;

            int lenW = width;

            int howFast = speed;

            int lenH = height;

            //up c++
            for (int i = 0; i < lenW; i++)
            {
                Console.SetCursorPosition(c, r);
                Thread.Sleep(howFast);
                Console.Write("=");
                c++;
            }

            // left r++
            for (int i = 0; i < lenH; i++)
            {
                Console.SetCursorPosition(Sc, r);
                Thread.Sleep(howFast);
                Console.Write("|");
                r++;
            }


            //right Sr++
            for (int i = 0; i < lenH; i++)
            {
                Console.SetCursorPosition(c, Sr);
                Thread.Sleep(howFast);
                Console.Write("|");
                Sr++;
            }

            //down Sc++
            lenW = lenW - 1;
            Sc = Sc + 1;
            r = r - 1;
            for (int i = 0; i < lenW; i++)
            {
                Console.SetCursorPosition(Sc, r);
                Thread.Sleep(howFast);
                Console.Write("=");
                Sc++;
            }

        }

        public static string MeteredInput(int passLength, int left, int top)
        {            
            ConsoleKeyInfo Key;
            string word = "";
            passLength--;
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = true;

            for (int i = 1; ; i++)
            {
                Key = Console.ReadKey();

                if (Key.Key == ConsoleKey.Backspace)
                {   

                    if (Console.CursorLeft == left - 1)
                    {
                        Console.CursorLeft = (left - 1) + 1;
                        continue;
                    }
                        if (word.Length >= 1)
                        {

                            int oldLength = word.Length;

                            word = word.Substring(0, oldLength - 1);

                            Console.SetCursorPosition(left, top);
                            Console.Write(word + new String(' ', oldLength - word.Length));
                            Console.SetCursorPosition(left + word.Length, top);

                        }
                        continue;
                    //word = "!@#$%^&*()";
                    //break;
                 

                }
                               

                if (word.Length > passLength)
                {
                    Console.Write("\b \b");
                    

                }
                if (Key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (Key.Key != ConsoleKey.Enter && Key.Key != ConsoleKey.Backspace && !(word.Length > passLength))
                {
                    //Console.Write(Key.KeyChar);
                    word += Key.KeyChar;
                }
            }
            Console.CursorVisible = false;
            return word;
        }

        public static void Blink(string text, int duration, int left, int top)
        {
            int timerduration = duration / 10;



            //200
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColSub;
            Console.Write(text);
            Thread.Sleep(timerduration);

            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = Station.consoleColMain;;
            Console.Write(text);
            Thread.Sleep(timerduration);

            //400
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColSub;
            Console.Write(text);
            Thread.Sleep(timerduration);

            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColMain;
            Console.Write(text);
            Thread.Sleep(timerduration);

            //400
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColSub;
            Console.Write(text);
            Thread.Sleep(timerduration);

            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColMain;
            Console.Write(text);
            Thread.Sleep(timerduration);

            //400
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColSub;
            Console.Write(text);
            Thread.Sleep(timerduration);

            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColMain;
            Console.Write(text);
            Thread.Sleep(timerduration);

            //400
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColSub;
            Console.Write(text);
            Thread.Sleep(timerduration);

            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = consoleColMain;
            Console.Write(text);
            //Thread.Sleep(timerduration);




        }

        public static void clearRow(int left, int top, int lengther, int colspan = 0)
        {
            string lent = "";

            colspan++;

            for (int j = 0; j < colspan; j++)
            {
                for (int i = 0; i < lengther; i++)
                {
                    lent += " ";
                }

                Console.SetCursorPosition(left, top);
                Console.Write(lent);

                top++;
            }
            

            
        }

        public static void BlueMoonHeader()
        {
            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);
        }

        public static void writer(int left, int top, string text)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }

        public static void writerClearedRow(int left, int top, string text)
        {
            int len = 120 - left;
            Console.SetCursorPosition(left, top);
            clearRow(left, top, len);

            Console.SetCursorPosition(left, top);
            Console.Write(text);
        }

        public static string PassWordStar()
        {
            //string we =  Console.Read();                                                
            ConsoleKeyInfo Key;
            string pass = "";
            //Console.WriteLine("enter password");


            while (true)
            {

                Key = Console.ReadKey(true);

                if (Key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (Key.Key != ConsoleKey.Backspace)
                {
                    pass += Key.KeyChar;
                    Console.Write("*");
                }

                else if (Key.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");
                }



            }

            Console.Write("\n");

            //Console.WriteLine();
            //Console.WriteLine("the password you entered is : {0}", pass);

            pass.Trim(' ');

            return pass;

            //Console.ReadKey();

        }
        
        public static string MeteredInputNum(int passLength, int left, int top)
        {
            string _val = "";
            ConsoleKeyInfo key;

            Console.CursorVisible = true;
            Console.SetCursorPosition(left, top);

            do
            {
                if (_val.Length > passLength)
                {
                    Console.Write("\b \b");
                    _val = _val.Substring(0, (_val.Length - 1));
                }

                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }

                

            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);

            Console.CursorVisible = false;
            return _val;

        }

        private static void UpdateTime()
        {

            while (true)
            {
                bool cusVisible = Console.CursorVisible;
                int cusPosLeft = Console.CursorLeft;
                int cusPosTop = Console.CursorTop;

                if (cusVisible)
                {
                    Console.CursorVisible = false;
                }


                Console.ForegroundColor = consoleColMain;

                Console.SetCursorPosition(90, 2);
                Console.Write("          ");

                Console.SetCursorPosition(92, 2);
                Console.Write(DateTime.Now);

                Console.SetCursorPosition(90, 2);
                Console.Write("          ");

                //Console.MoveBufferArea(90, 1, 18, 2, 90, 1);

                Console.SetCursorPosition(cusPosLeft, cusPosTop);
                Console.CursorVisible = cusVisible;

                Thread.Sleep(1000);
            }

        }

        public static void StartTimeThread()
        {
            t = new Thread(new ThreadStart(UpdateTime));
            t.IsBackground = true;
            t.Start();
        }

        public static void StopTimeThread()
        {
            t.Abort();
        }

        public static void BeepRemind()
        {
            //Console.Beep(262, 300);
            Console.Beep(330, 300);
        }

        public static void BeepClick()
        {
            Console.Beep(262, 300);
        }

        public static void BeepError()
        {
            Console.Beep(494, 300);
            Console.Beep(494, 300);
        }





    }
}
