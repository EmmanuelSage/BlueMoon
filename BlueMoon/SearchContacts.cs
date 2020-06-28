using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class SearchContacts
    {

        public void Start()
        {
            Console.Title = "BlueMoon - Search Contacts";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press BackSpace to go to previous menu or any key to start Search....");

            Console.CursorVisible = false;
            ConsoleKeyInfo key1;
            key1 = Console.ReadKey(true);

            if (key1.Key == ConsoleKey.Backspace)
            {
                ContactDetails cd2 = new ContactDetails();
                cd2.Start();
                return;
            }

            Console.SetCursorPosition(37, 15);
            Console.WriteLine("                                                                           ");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Search contact Menu");




            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Contacts.ebase";

            string[] EbRows = File.ReadAllLines(path);



            Console.SetCursorPosition(39, 19);
            Console.WriteLine("enter the name of the contact to search");
            Console.SetCursorPosition(39, 20);
            // Start add
            string name = Station.MeteredInput(12, 39, 20);

            
            name = name.ToLower();

            
            bool editer = true;
            bool found = false;
            // end add
            string[] fieldName = { "Name", "Phone Number", "Email", "State", "City", "Address" };

            while (editer)
            {
                //add
                found = false;

                for (int i = 0; i < EbRows.Length; i++)
                {
                    string[] EbCol = EbRows[i].Split('~');


                    for (int j = 0; j < EbCol.Length; j++)
                    {
                        //Start add 
                        if (editer)
                        {
                            string EbColtemp = EbCol[0].ToLower();

                            if (name == EbColtemp || EbColtemp.Contains(name))
                            {

                                found = true;
                                // End add make sure to complete }
                                Console.SetCursorPosition(39, 22);
                                Console.WriteLine("=======Contact Found=======");

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

                                
                                Console.SetCursorPosition(25, 31);
                                Console.WriteLine("(Backspace) to return   --   (N) to Next Search    --   (any key) to start again");

                                Console.CursorVisible = false;
                                ConsoleKeyInfo key;
                                key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.Backspace)
                                {

                                    Station.clearRow(25, 31, 90);
                                    editer = false;

                                }
                                else if (key.Key == ConsoleKey.N)
                                {
                                    break;
                                }
                                else
                                {
                                    SearchContacts scc = new SearchContacts();
                                    scc.Start();
                                }
                        }
                        }
                    }



                }

                if (!found)
                {
                    Console.SetCursorPosition(48, 27);
                    Console.Write("Contact Not Found");
                    Thread.Sleep(500);
                    Start();
                }

            }

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
