using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class SettingsMenu
    {

        int left = 37;
        int top = 14;
        int topC;
        string textC;
        int topM;
        string textM;
        int topR;
        string textR;


        public void Start()
        {
            SettingsMenuUI();
            SettingsMenuFunction();
        }


        private void SettingsMenuUI()
        {
            Console.Title = "BlueMoon - Settings";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);
            
            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top+=2;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("=====Settings page=====");

            top += 3;
            topC = top;
            Console.SetCursorPosition(39, top);
            textC = "(C). Change Login and Display";
            Console.WriteLine(textC);

            top += 2;
            topM = top;
            Console.SetCursorPosition(39, top);
            textM = "(V). Import/Export vcf";
            Console.WriteLine(textM);

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
                SettingsLoginDetails sl = new SettingsLoginDetails();
                sl.Start();
                
            }


            else if (key.Key == ConsoleKey.V)
            {
                Station.BeepClick();
                Station.StopTimeThread();
                Station.Highlight(39, topM, textM);
                Station.StopTimeThread();
                top += 4;
                Station.BeepError();
                Console.SetCursorPosition(39, top);
                Console.WriteLine("Not yet Implemented");
                Thread.Sleep(200);
                top = 14;
                Console.Clear();
                Start();

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
