using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Manipulator
{
    class MouseClick: GameEvent
    {

        private Tuple<int, int> cords;

        public Tuple<int, int> Cords
        {
            get { return cords; }
            set { cords = value; }
        }

        public MouseClick(Tuple<int, int> cords, TimeSpan span, TimeSpan delay)
            :base(span, delay)
        {
            this.cords = cords;
        }

        public MouseClick(Tuple<int, int> cords, int s, int m = 0, int h = 0, int ds = 0, int dm = 0, int dh = 0)
            :this(cords, new TimeSpan(h, m, s), new TimeSpan(dh, dm, ds))
        {

        }

        public override void Send()
        {
            SetCursorPos(cords.Item1, cords.Item2);
            mouse_event(MOUSEEVENTF_LEFTDOWN, cords.Item1, cords.Item2, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, cords.Item1, cords.Item2, 0, 0);
            //Console.WriteLine(string.Format("Clicked on Coords x:{0}, y:{1} at {2}", cords.Item1, cords.Item2));
            //Writer.Write(string.Format("Clicked on Coords x:{0}, y:{1} at {2}", cords.Item1, cords.Item2, DateTime.Now.ToLongTimeString()));
        }
    }
}
