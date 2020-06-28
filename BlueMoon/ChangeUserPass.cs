using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueMoon
{
    class ChangeUserPass
    {
        string newUsername;

        string newPassword;
        

        public void Start()
        {
            
            ChangeUserPassUIHeader();
            DisplayCurrentUserAndOptions();
        }

        private void ChangeUserPassUIHeader()
        {
            Console.Title = "BlueMoon - Change Username and Password";

            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Change Username And password");
            
            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======   User Login Details   ======        ");

            Station.writer(39, 19, "The current username is : " + Station.username);

            Station.writerClearedRow(39, 21, "press (C) to change User Login Details");
            Station.writerClearedRow(39, 23, "press (R) to return to Login Settings Menu");
        }

        private void DisplayCurrentUserAndOptions()
        {
            //39, 17
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.C)
            {
                CheckPreviousPassword();
            }

            else if (key.Key == ConsoleKey.R)
            {
                SettingsLoginDetails sd = new SettingsLoginDetails();
                sd.Start();
            }

            else
            {
                Station.BeepError();
                Console.SetCursorPosition(39, 26);
                Console.WriteLine("Invalid Key.");
                Thread.Sleep(200);
                Console.Clear();
                Start();
            }

       }

        private void CheckPreviousPassword()
        {
            //39, 21 - 23

            Station.writerClearedRow(39, 21,"Enter previous password");
            Station.clearRow(1, 23, 118);

            Console.CursorVisible = true;

            Console.SetCursorPosition(39, 22);
            string prevPassword = Station.PassWordStar();

            if (prevPassword == Station.password)
            {
                Station.writerClearedRow(39, 24, "Enter New User Name");
                newUsername = Station.MeteredInput(12, 39, 25);

                Station.writerClearedRow(39, 27, "Enter New Password");
                Console.SetCursorPosition(39, 28);
                newPassword = Station.PassWordStar();

                Station.writerClearedRow(39, 30, "Confirm New Password");
                Console.SetCursorPosition(39, 31);
                string newPasswordConfirm = Station.PassWordStar();

                if (newPassword == newPasswordConfirm)
                {
                    Station.writerClearedRow(39, 33, "Press (Y) to save or (N) to cancel");

                    Console.CursorVisible = false;
                    ConsoleKeyInfo key1;
                    key1 = Console.ReadKey(true);

                    if (key1.Key == ConsoleKey.Y)
                    {
                        SaveToSettingsFile();
                        SettingsLoginDetails sld = new SettingsLoginDetails();
                        sld.Start();
                        
                    }

                    else if (key1.Key == ConsoleKey.N)
                    {
                        Station.writerClearedRow(39, 35, "Change Login Details Canceled");
                        Station.writerClearedRow(39, 36, "Press any key to exit");
                        Console.ReadKey(true);

                        SettingsLoginDetails sld = new SettingsLoginDetails();
                        sld.Start();
                    }
                    else
                    {
                        Station.BeepError();
                        Console.SetCursorPosition(39, 36);
                        Console.WriteLine("Invalid Key.");
                        Thread.Sleep(200);
                        Station.clearRow(39, 36, 15);
                    }
                }
                else
                {
                    Console.CursorVisible = false;
                    Station.writerClearedRow(39, 34, "The Passwords Do not Match");
                    Station.writerClearedRow(39, 35, "press anykey to try again");
                    Console.ReadKey(true);
                    Start();
                }



            }
            else
            {
                Console.CursorVisible = false;
                Station.writerClearedRow(39, 24, "The Password is Incorrect");
                Station.writerClearedRow(39, 25, "press anykey to try again");
                Console.ReadKey(true);
                Start();
            }






        }

        private void SaveToSettingsFile()
        {
            // decrypt settings
            Station.writerClearedRow(39, 35, "Verifying Data Source");
            string curPath = Directory.GetCurrentDirectory();
            string path = curPath + "\\Settings.ebase";
            string tempPath = curPath + "\\temp.txt";

            Encryption.Decrypt(path);

            string[] EbRows = File.ReadAllLines(path);

            //
            EbRows[0] = newUsername;
            EbRows[1] = newPassword;
            

            File.WriteAllLines(tempPath, EbRows);

            File.Delete("Settings.ebase");
            Station.writerClearedRow(39, 35, "Saving data ..");
            Station.Blink("Saving data ....", 5000, 39, 35);
            File.Move("temp.txt", "Settings.ebase");

            Station.Blink("Saving data ......", 2000, 39, 35);

            Encryption.Encrypt(path);            
            Station.writerClearedRow(39, 35, "Saved");
            Thread.Sleep(2000);
        }
    }
}
