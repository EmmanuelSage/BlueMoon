using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class Login
    {

        public void DisplayPassword()
        {
            Console.ForegroundColor = Station.consoleColMain;

            Console.Clear();

            Border(5,42,35,30);

            int left = 50;
            int top = 10;

            Console.SetCursorPosition(left, top);
            Console.WriteLine("   Login Page   ");

            top++;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("---------------");


            top+=2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Enter your Username");

            top ++;
            Console.SetCursorPosition(left, top);
            string username = Station.MeteredInput(12,left,top);

            top+=2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Enter your Password");

            string password = "";

            if (Station.passHide == "A")
            {
                top++;
                Console.SetCursorPosition(left, top);
                password = Station.PassWordStar();

            }
            else if(Station.passHide == "I")
            {
                top++;
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = ConsoleColor.Black;
                password = Station.MeteredInput(12,left,top);
                Console.ForegroundColor = Station.consoleColMain;
            }


            if (username == Station.username && password == Station.password)
            {
                Station.loggedIn = true;
                Console.SetCursorPosition(left, top + 5);
                Console.WriteLine("you have Logged in");
                Console.CursorVisible = false;

                Console.SetCursorPosition(left, top + 3);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);

                MainMenu mm = new MainMenu();
                mm.Start();

            }
            else
            {
                Console.SetCursorPosition(left, top + 5);
                Console.WriteLine("Login incorrect");

                top+=2;
                Console.SetCursorPosition(left, top + 5);
                Console.WriteLine("Press any key");

                top ++;
                Console.SetCursorPosition(left, top + 5);
                Console.WriteLine("to try again");
                Console.CursorVisible = false;
                Console.ReadKey(true);
                DisplayPassword();

                
            }
        }
        


        private void Border(int left, int top, int width, int height)
        {
            int Sc = top;
            int Sr = left;

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



    }
}
