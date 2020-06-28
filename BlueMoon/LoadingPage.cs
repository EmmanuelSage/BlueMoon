using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMoon
{
    class LoadingPage
    {
        public static void LoadPage()
        {
            //Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

            Console.CursorVisible = false;

            Console.SetCursorPosition(50, 25);

            Console.WriteLine("  Loading.....");

            // loading position row= -3 and col = +2
            Console.SetCursorPosition(47, 27);

            int leftCheck = 3;
            int topCheck = 38;
            int topLoad = 47;
            int sleepValueI3 = 500;
            int sleepValueI31 = 173;

            for (int i = 0; i < 20; i++)
            {
                // loading position row= -3 and col = +2
                Console.SetCursorPosition(topLoad, 27);
                topLoad++;
                Console.Write((char)166);

                                
                if (i == 0)
                {
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 1)
                {
                    Thread.Sleep(sleepValueI31);
                    Station.writerClearedRow(leftCheck, topCheck, "Checking app state.");
                    Thread.Sleep(sleepValueI31);
                    Station.writerClearedRow(leftCheck, topCheck, "Checking app state..");
                    Thread.Sleep(sleepValueI31);
                    Station.writerClearedRow(leftCheck, topCheck, "Checked");
                }


                else if (i == 2)
                {
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 3)
                {
                    DateTime last = Directory.GetLastAccessTime("BlueMoon.exe");
                    Station.writerClearedRow(leftCheck, topCheck, "application last access : " + last);
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 4)
                {
                    Thread.Sleep(sleepValueI3);
                }




                else if (i == 5)
                {
                    string curDir = Directory.GetCurrentDirectory();
                    Station.writerClearedRow(leftCheck, topCheck, "application current directory : " + curDir);
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 6)
                {
                    Station.writerClearedRow(leftCheck, topCheck, "Checking Schedule.ebase");
                    Thread.Sleep(sleepValueI3);
                }
                
                else if (i == 7)
                {
                    

                    if (!File.Exists("Schedule.ebase"))
                    {
                        MessageBox.Show("The Schedule file does not exist.\nIf this is first time use of application, this is normal other wise" +
                            " the Schedule file has been tampered with. \nA new Schedule file would be created for you.", "ebase file Missing",
                            MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Thread.Sleep(sleepValueI3);
                        Station.writerClearedRow(leftCheck, topCheck, "Checking Schedule.ebase : passed");
                    }
                    
                    
                }

                else if (i == 8)
                {
                    if (!File.Exists("Schedule.ebase"))
                    {                        
                        File.Create("Schedule.ebase");

                        Thread.Sleep(sleepValueI3);
                        Thread.Sleep(sleepValueI3);

                        string[] writer = { "test~2018~6~27~15~47~Niit" };

                        File.WriteAllLines("Schedule.ebase", writer);
                        Thread.Sleep(sleepValueI3);

                        Station.writerClearedRow(leftCheck, topCheck, "Checking Schedule.ebase : Created");
                    }
                    
                    Thread.Sleep(sleepValueI3);
                }

                else if (i == 9)
                {
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 10)
                {
                    
                    DateTime lastWrite = Directory.GetLastWriteTime(".");
                    Station.writerClearedRow(leftCheck, topCheck, "This directory was last written to on : " + lastWrite);
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 11)
                {
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 12)
                {
                    Station.writerClearedRow(leftCheck, topCheck, "Checking Contacts.ebase");
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 13)
                {
                    

                    if (!File.Exists("Contacts.ebase"))
                    {
                        MessageBox.Show("The Contacts file does not exist.\nIf this is first time use of application, this is normal other wise" +
                            " the Contacts file has been tampered with. \nA new Contacts file would be created for you.", "ebase file Missing",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        
                    }
                    else
                    {
                        Thread.Sleep(sleepValueI3);
                        Station.writerClearedRow(leftCheck, topCheck, "Checking Contacts.ebase : passed");
                    }
                }



                else if (i == 14)
                {
                    if (!File.Exists("Contacts.ebase"))
                    {                        
                        File.Create("Contacts.ebase");
                        Station.writerClearedRow(leftCheck, topCheck, "Checking Contacts.ebase : Created");
                    }
                    
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 15)
                {
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 16)
                {
                    Station.writerClearedRow(leftCheck, topCheck, "Checking Settings.ebase");
                    Thread.Sleep(sleepValueI3);
                }



                else if (i == 17)
                {                    
                    if (!File.Exists("Settings.ebase"))
                    {
                        MessageBox.Show("The Settings file does not exist.\nIf this is first time use of application, this is normal other wise" +
                            " the Settings file has been tampered with. \nA new Settings file would be created for you.", "ebase file Missing",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        
                    }
                    else
                    {
                        Station.SetterFile();

                        Station.writerClearedRow(leftCheck, topCheck, "Checking Settings.ebase : passed");
                    }
                }

                

                else if (i == 18)
                {
                    bool fileExists = File.Exists("Settings.ebase");

                    if (!fileExists)
                    {                       
                        
                        Station.SetterDefault();

                        Thread.Sleep(sleepValueI3);
                        Station.writerClearedRow(leftCheck, topCheck, "Checking Settings.ebase : Created");
                        Thread.Sleep(sleepValueI3);
                    }
                    Thread.Sleep(sleepValueI3);
                }


                else if (i == 19)
                {
                    Station.writerClearedRow(leftCheck, topCheck, "Loading Completed.....");
                    Thread.Sleep(sleepValueI3);
                    Station.SetColor();
                    Thread.Sleep(sleepValueI3);
                }
                
            }


            Login l = new Login();
            l.DisplayPassword();

        }



    }
}
