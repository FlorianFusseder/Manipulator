using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manipulator
{
    abstract class GameEvent : SendEvent
    {

        private TimeSpan span;

        public TimeSpan Span
        {
            get { return span; }
            set { span = value; }
        }

        private TimeSpan delay;

        public TimeSpan Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public GameEvent(TimeSpan span, TimeSpan delay)
        {
            this.span = span;
            this.delay = delay;
        }

        protected const int MOUSEEVENTF_LEFTDOWN = 0x02;
        protected const int MOUSEEVENTF_LEFTUP = 0x04;

        [DllImport("user32.dll")]
        protected static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        protected static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        abstract public void Send();
    }
}
