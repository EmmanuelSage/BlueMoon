using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class SettingsLoginDetails
    {
        int left = 37;
        int top = 14;
        int topC;
        string textC;
        int topP;
        string textP;
        int topT;
        string textT;
        int topR;
        string textR;


        public void Start()
        {
            SettingsMenuUI();
            SettingsMenuFunction();
        }


        private void SettingsMenuUI()
        {
            Console.Title = "BlueMoon - Settings - Login and Display";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);

            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top+=2;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("=====Login Settings page=====");

            top += 3;
            topC = top;
            Console.SetCursorPosition(39, top);
            textC = "(C). Change Username and Password";
            Console.WriteLine(textC);

            top += 2;
            topP = top;
            Console.SetCursorPosition(39, top);
            textP = "(P). Choose password hide Type";
            Console.WriteLine(textP);

            top += 2;
            topT = top;
            Console.SetCursorPosition(39, top);
            textT = "(T). Change Theme color";
            Console.WriteLine(textT);

            top += 2;
            topR = top;
            Console.SetCursorPosition(39, top);
            textR = "(R). Return to Main Menu ";
            Console.WriteLine(textR);


        }

        private void SettingsMenuFunction()
        {

            Station.StartTimeThread();

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);


            if (key.Key == ConsoleKey.C)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topC, textC);
                ChangeUserPass cup = new ChangeUserPass();
                cup.Start(); 

            }


            else if (key.Key == ConsoleKey.P)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topP, textP);
                PasswordHide ph = new PasswordHide();
                ph.Start();

            }

            else if (key.Key == ConsoleKey.T)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topT, textT);
                ThemeColor tc = new ThemeColor();
                tc.Start();

            }


            else if (key.Key == ConsoleKey.R)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topR, textR);
                MainMenu mm = new MainMenu();
                mm.Start();
            }


            else
            {
                Station.StopTimeThread();
                top += 4;
                Station.BeepError();
                Console.SetCursorPosition(39, top);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                top = 14;
                Console.Clear();
                Start();
            }


        }
    }
}
