using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class ContactDetails
    {

        public void Start()
        {
            Console.Title = "BlueMoon - Contacts Application";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);

            int left = 37;
            int top = 14;

            Console.SetCursorPosition(left, top);
            Console.WriteLine("PERSONAL ASSISTANT APPLICATION");

            top++;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("Contact Details Page.");

            top += 3;
            int topA = top;
            Console.SetCursorPosition(39, top);
            String textA = "(A). Add contacts";
            Console.WriteLine(textA);

            top += 2;
            int topE = top;
            Console.SetCursorPosition(39, top);
            string textE = "(E). Edit Contacts";
            Console.WriteLine(textE);

            top += 2;
            int topV = top;
            Console.SetCursorPosition(39, top);
            string textV = "(V). View Contacts ";
            Console.WriteLine(textV);

            top += 2;
            int topS = top;
            Console.SetCursorPosition(39, top);
            string textS = "(S). Search Contacts ";
            Console.WriteLine(textS);

            top += 2;
            int topD = top;
            Console.SetCursorPosition(39, top);
            string textD = "(D). Delete Contacts ";
            Console.WriteLine(textD);

            top += 2;
            int topR = top;
            Console.SetCursorPosition(39, top);
            string textR = "(R). Return to Main Page ";
            Console.WriteLine(textR);


            Station.StartTimeThread();

            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.A)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topA, textA);
                AddContacts ad = new AddContacts();
                ad.Start();
            }
            else if (key.Key == ConsoleKey.E)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topE, textE);
                EditContacts ec = new EditContacts();
                ec.Start();
            }
            else if (key.Key == ConsoleKey.V)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topV, textV);
                ViewContacts vc = new ViewContacts();
                vc.Start();
            }
            else if (key.Key == ConsoleKey.S)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topS, textS);
                SearchContacts sc = new SearchContacts();
                sc.Start();
            }
            else if (key.Key == ConsoleKey.D)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topD, textD);
                DeleteContacts dc = new DeleteContacts();
                dc.Start();
            }
            else if (key.Key == ConsoleKey.R)
            {
                Station.StopTimeThread();
                Station.BeepClick();
                Station.Highlight(39, topR, textR);
                PersonalAssistant pa = new PersonalAssistant();
                pa.Start();
            }
            else
            {
                Station.StopTimeThread();
                top += 4;
                Station.BeepError();
                Console.SetCursorPosition(39, top);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                Console.Clear();
                Start();
            }



        }



    }
}
