using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class EditContacts
    {


        public void Start()
        {
            Console.Title = "BlueMoon - Edit Contacts";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to Edit Contacts....");
            Console.ReadKey(true);



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======   Contact Details   ======        ");




            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Contacts.ebase";

            string tempPath = curPath + "\\temp.txt";

            string[] EbRows = File.ReadAllLines(path);

           

            Console.SetCursorPosition(39, 19);
            Console.WriteLine("enter the name of the contact to Edit");
            Console.SetCursorPosition(39, 20);
            string name = Station.MeteredInput(12, 39, 20);

            name = name.ToLower();

            bool editer = true;
            bool found = false;

            string[] fieldName = { "Name", "Phone Number", "Email", "State", "City", "Address" };

            List<string> newData = new List<string>();

            while (editer)
            {
                found = false;
                newData = new List<string>();

                for (int i = 0; i < EbRows.Length; i++)
                {
                    string[] EbCol = EbRows[i].Split('~');

                    #region editer loop

                    for (int j = 0; j < EbCol.Length; j++)
                    {
                        if (editer)
                        {
                            string EbColtemp = EbCol[0].ToLower();

                            if (name == EbColtemp || EbColtemp.Contains(name))
                            {
                                found = true;
                                Console.SetCursorPosition(39, 22);
                                Console.WriteLine("=======Contact==============");

                                EditContactsClear();

                                Console.SetCursorPosition(39, 24);
                                Console.WriteLine("{0,-12} : {1}", fieldName[0], EbCol[0]);

                                Console.SetCursorPosition(39, 25);
                                Console.WriteLine("{0,-12} : {1}", fieldName[1], EbCol[1]);

                                Console.SetCursorPosition(39, 26);
                                Console.WriteLine("{0,-12} : {1}", fieldName[2], EbCol[2]);

                                Console.SetCursorPosition(39, 27);
                                Console.WriteLine("{0,-12} : {1}", fieldName[3], EbCol[3]);

                                Console.SetCursorPosition(39, 28);
                                Console.WriteLine("{0,-12} : {1}", fieldName[4], EbCol[4]);

                                Console.SetCursorPosition(39, 29);
                                Console.WriteLine("{0,-12} : {1}", fieldName[5], EbCol[5]);



                                Console.SetCursorPosition(15, 31);
                                Console.WriteLine("(E). edit contact  --  (Backspace) to return  --  (N) to Next Search  --  (any key) to start again");


                                Console.CursorVisible = false;
                                ConsoleKeyInfo key;
                                key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.E)
                                {

                                    Station.clearRow(15, 31, 105);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Name :            ");
                                    Console.SetCursorPosition(39, 33);
                                    string newName = Console.ReadLine();

                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);

                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Phone Number :         ");
                                    Console.SetCursorPosition(39, 33);
                                    string phoneNumber = Station.MeteredInputNum(11, 39, 33);


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Email :      ");
                                    Console.SetCursorPosition(39, 33);
                                    string email = Console.ReadLine();


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter State : ");
                                    Console.SetCursorPosition(39, 33);
                                    string state = Console.ReadLine();


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter City :    ");
                                    Console.SetCursorPosition(39, 33);
                                    string city = Console.ReadLine();


                                    Station.clearRow(39, 32, 30);
                                    Station.clearRow(39, 33, 30);


                                    Console.SetCursorPosition(39, 32);
                                    Console.WriteLine("Enter Street Address :          ");
                                    Console.SetCursorPosition(39, 33);
                                    string address = Console.ReadLine();


                                    EbRows[i] = newName + "~"  +  phoneNumber + "~" + email + "~" + state + "~" + city + "~" + address;


                                    editer = false;

                                }
                                else if (key.Key == ConsoleKey.Backspace)
                                {
                                    ContactDetails cd1 = new ContactDetails();
                                    cd1.Start();
                                }
                                else if (key.Key == ConsoleKey.N)
                                {
                                    break;
                                }
                                else
                                {
                                EditContacts edc = new EditContacts();
                                edc.Start();
                                }

                                

                            }

                        }
                    }

                    #endregion

                    newData.Add(EbRows[i]);

                }

                if (!found)
                {
                    Console.SetCursorPosition(48, 27);
                    Console.Write("Contact Not Found");
                    Thread.Sleep(500);
                    Start();
                }
            }

            
            string[] newDataarr = newData.ToArray();

            
            File.WriteAllLines(tempPath, newDataarr);

            File.Delete("Contacts.ebase");
            Station.Blink("Editing Contact Information.............", 5000, 39, 35);
            File.Move("temp.txt", "Contacts.ebase");

            ContactDetails cd = new ContactDetails();
            cd.Start();

        }


        
        private void EditContactsClear()
        {
            Console.SetCursorPosition(39, 24);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 25);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 26);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 27);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 28);
            Console.WriteLine("                                     ");

            Console.SetCursorPosition(39, 29);
            Console.WriteLine("                                     ");
        }

       
    }
}
