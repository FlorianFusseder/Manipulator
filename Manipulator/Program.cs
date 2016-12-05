using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulator
{
    class Program
    {

        static void Main(string[] args)
        {
            var tc = new Game("Time Clickers");

            //tc.AddEvent(new KeyStroke("1", 0, 2, 0));
            //tc.AddEvent(new KeyStroke("2", 0, 4, 0));
            //tc.AddEvent(new KeyStroke("3", 0, 12, 0));
            //tc.AddEvent(new KeyStroke("4", 0, 36, 0));
            //tc.AddEvent(new KeyStroke("5", 0, 36, 0));
            //tc.AddEvent(new KeyStroke("6", 0, 36, 0));
            //tc.AddEvent(new KeyStroke("7", 30, 26, 7, 45));
            //tc.AddEvent(new KeyStroke("8", 0, 12, 1));
            //tc.AddEvent(new KeyStroke("9", 0, 12, 1));
            //tc.AddEvent(new KeyStroke("0", 1, 12, 1, 5));
            //tc.AddEvent(new KeyStroke(" ", 45, 12, 1, 45));

            //tc.AddEvent(new KeyStroke("g", 10, 0, 0, 2));
            //tc.AddEvent(new KeyStroke("f", 10, 0, 0, 4));
            //tc.AddEvent(new KeyStroke("d", 10, 0, 0, 6));
            //tc.AddEvent(new KeyStroke("s", 10, 0, 0, 8));
            //tc.AddEvent(new KeyStroke("a", 10, 0, 0, 10));

            tc.AddEvent(new MouseClick(new Tuple<int, int>(-500, 50), 5, 0));


            tc.Start();

            Console.WriteLine("Press any Button to End");
            Console.ReadLine();
        }
    }
}
