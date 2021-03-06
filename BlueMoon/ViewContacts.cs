﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueMoon
{
    class ViewContacts
    {

        public void Start()
        {

            Console.Title = "BlueMoon - View Contacts";


            Console.Clear();
            AsciiClass ac = new AsciiClass();
            ac.BlueMoon(3);


            Console.SetCursorPosition(37, 13);
            Console.WriteLine("==========PERSONAL ASSISTANT APPLICATION==========");


            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to View Contacts....");
            Console.ReadKey(true);



            Console.SetCursorPosition(39, 17);
            Console.WriteLine("       ======Contact Details======");



            string curPath = Directory.GetCurrentDirectory();

            string path = curPath + "\\Contacts.ebase";


            string[] EbRows = File.ReadAllLines(path);

            string[] fieldName = { "Name", "Phone Number", "Email", "State", "City", "Address" };

            int topDisplay = 20;
            int leftDisplay = 0;
            int countingLeft = 1;
            int displaySet = 0;


            Console.MoveBufferArea(0, 38, 40, 2, 1, 2);

            // Go over each row
            int initial = EbRows.Length - 1;

            for (int q = initial; q >= 0; q--)
            {

                // split rows into column
                string[] EbCol = EbRows[q].Split('~');

                //determine left or right based on even or odd
                countingLeft++;

                // set left to right or left 
                if (countingLeft % 2 == 0)
                {
                    leftDisplay = 5;
                }
                else
                {
                    leftDisplay = 62;
                    topDisplay = displaySet;
                }

                // set display set to top display to determine height
                displaySet = topDisplay;

                for (int i = 0; i < EbCol.Length; i++)
                {

                    Console.SetCursorPosition(leftDisplay, topDisplay);
                    Console.WriteLine("{0,-12} : {1}", fieldName[i], EbCol[i]);
                    topDisplay++;
                }



                topDisplay += 2;
            }


            // draw main border
            int count = displaySet;
            Station.BorderThread(2, 18, 115, count, 10);
            Console.CursorVisible = false;

            // draw book border
            int leftB = 60;
            int topB = 18;
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(leftB, topB);
                Console.Write("|");
                topB++;
            }

            // readkey to exit
            Console.SetCursorPosition(37, 15);
            Console.WriteLine("Press any Key to Return to previous Menu....");
            Console.ReadKey(true);

            // Goto Contact details Menu
            ContactDetails cd = new ContactDetails();
            cd.Start();
        }



    }
}
