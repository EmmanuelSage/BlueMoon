using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class AddContacts
    {
        public void Start()
        {

            Console.Title = "BlueMoon - Add Contacts";

            Station.BlueMoonHeader();

            AddContactsHeader();
            
            // open file and a stream writer to write
            FileStream fs = new FileStream("Contacts.ebase", FileMode.Append, FileAccess.Write);
            StreamWriter w = new StreamWriter(fs);

            // Input Name
            Station.BorderThread(2, 20, 20, 6, 20);
            Station.writer(3, 21, "Enter Name : ");
            Station.writer(3, 22, "max letters(16)");
            string name = Station.MeteredInput(16, 3, 23);

            
            // Input Phone Number
            Station.BorderThread(24, 20, 20, 6, 20);
            Station.writer(25, 21, "Enter Phone Number");
            Station.writer(25, 22, "max letters(11)");
            string phoneNumber = Station.MeteredInputNum(11, 25, 23);


            // Input Email
            Station.BorderThread(46, 20, 28, 6, 20);
            Station.writer(47, 21, "Enter Email");
            Station.writer(47, 22, "max letters(25)");
            string email = Station.MeteredInput(25, 47, 23);


            // Input State
            Station.BorderThread(76, 20, 19, 6, 20);
            Station.writer(77, 21, "Enter State");
            Station.writer(77, 22, "max letters(10)");
            string state = Station.MeteredInput(10, 77, 23);

            // Input City
            Station.BorderThread(97, 20, 19, 6, 20);
            Station.writer(98, 21, "Enter City");
            Station.writer(98, 22, "max letters(12)");
            string city = Station.MeteredInput(12, 98, 23);



            //Input Address
            Station.BorderThread(2, 27, 30, 6, 20);
            Station.writer(3, 28, "Enter street address : ");
            Station.writer(3, 29, "max letters(28)");
            string address = Station.MeteredInput(28, 3, 30);


            // Ask user if sure to save data
            ToSaveData();




            while (true)
            {
                Console.CursorVisible = false;
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Console.SetCursorPosition(35, 28);
                    Console.WriteLine("                                            ");

                    Console.SetCursorPosition(35, 30);
                    Console.WriteLine("                                            ");

                    Console.SetCursorPosition(35, 32);
                    Console.WriteLine("                                            ");


                    Station.Blink("Saving Data.........", 3000, 35, 28);

                    string cont = name + "~" + phoneNumber + "~" + email + "~" + state + "~" + city + "~" + address;

                    w.WriteLine(cont);
                    w.Flush();
                    w.Close();
                    fs.Close();
                    fs.Dispose();
                    w.Dispose();

                    Console.SetCursorPosition(35, 28);
                    Console.Write("Data Saved.          ");
                    Console.SetCursorPosition(35, 30);
                    Console.Write("press any key to return to previous Menu");
                    Console.ReadKey(true);
                    ContactDetails cd = new ContactDetails();
                    cd.Start();

                    break;
                }
                else if (key.Key == ConsoleKey.N)
                {

                    w.Flush();
                    w.Close();
                    fs.Close();
                    Start();
                    return;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    w.Flush();
                    w.Close();
                    fs.Close();
                    ContactDetails cd = new ContactDetails();
                    cd.Start();
                    return;
                }
                else
                {
                    Console.SetCursorPosition(63, 29);
                    Console.WriteLine("Invalid Key.");
                    Thread.Sleep(200);
                    Console.SetCursorPosition(63, 29);
                    Console.WriteLine("            ");
                }
            }




        }

        private void AddContactsHeader()
        {
            int left = 37;
            int top = 14;

            Console.SetCursorPosition(left, top);
            Console.WriteLine("BLUE MOON PERSONAL ASSISTANT APPLICATION");

            top++;
            Console.SetCursorPosition(37, top);
            Console.WriteLine("Press backspace (xN) to return to previous Menu");


            top += 3;
            Console.SetCursorPosition(39, top);
            Console.WriteLine("(C). Contacts");
        }

        private void ToSaveData()
        {
            // Ask user if sure to save data
            Console.CursorVisible = false;
            Console.SetCursorPosition(35, 28);
            Console.WriteLine("Save Contact As It Is. ");

            Console.SetCursorPosition(35, 30);
            Console.WriteLine("(Y). Yes        (N). No");

            Console.SetCursorPosition(35, 32);
            Console.WriteLine("Press Backspace to return to previous Menu. ");

            Console.SetCursorPosition(80, 27);
            Console.WriteLine("          TIP         ");

            Console.SetCursorPosition(80, 28);
            Console.WriteLine("----------------------");

            Console.SetCursorPosition(80, 29);
            Console.WriteLine("If you made a mistake in the form,");

            Console.SetCursorPosition(80, 30);
            Console.WriteLine("you can Press \"Y\" and edit it, ");

            Console.SetCursorPosition(80, 31);
            Console.WriteLine("in the Edit Menu. ");
        }

    }
}
