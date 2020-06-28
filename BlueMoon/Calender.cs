using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueMoon
{
    class Calender
    {
        public static void JuneCal(int left, int top)
        {

            //leap years == 2020 2024 2028 2032

            //30 = sept, april june nov
            //28 = feb

            //first sunday in january is 7
            
            string mon = "Mon";
            string tue = "Tue";
            string wed = "Wed";
            string thr = "Thr";
            string fri = "Fri";
            string sat = "Sat";
            string sun = "Sun";


            

            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n",sun,mon,tue,wed,thr,fri,sat);
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", " "," "," ","","","1","2");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "3", "4", "5", "6", "7", "8", "9");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "10", "11", "12", "13", "14", "15", "16");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "17", "18", "19", "20", "21", "22", "23");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "24", "25", "26", "27", "28", "29 ", "30");
            
        }

        public static void JulyCal(int left, int top)
        {

            //leap years == 2020 2024 2028 2032

            //30 = sept, april june nov
            //28 = feb

            //first sunday in january is 7

            string mon = "Mon";
            string tue = "Tue";
            string wed = "Wed";
            string thr = "Thr";
            string fri = "Fri";
            string sat = "Sat";
            string sun = "Sun";



            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", sun, mon, tue, wed, thr, fri, sat);
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "1", "2", "3", "4", "5", "6", "7");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "8", "9", "10", "11", "12", "13", "14");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "15", "16", "17", "18", "19", "20", "21");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "22", "23", "24", "25", "26", "27", "28");
            top++;
            Console.SetCursorPosition(left, top);
            Console.Write("{0, -4}{1, -4}{2, -4}{3, -4}{4, -4}{5, -4}{6, -4}\n", "29", "30", "31", " ", " ", " ", " ");

        }



    }
}
