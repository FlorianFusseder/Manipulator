using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manipulator
{
    class KeyStroke : GameEvent
    {

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public KeyStroke(string message, TimeSpan span, TimeSpan delay)
            : base(span, delay)
        {
            this.message = message;
        }

        /// <summary>
        /// Timereinstellungen
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="s">w. sec</param>
        /// <param name="m">w. min</param>
        /// <param name="h">w. hour</param>
        /// <param name="ds">f. sec</param>
        /// <param name="dm">f. min</param>
        /// <param name="dh">f. hour</param>
        public KeyStroke(string message, int s, int m, int h, int ds = 0, int dm = 0, int dh = 0)
            : this(message, new TimeSpan(h, m, s), new TimeSpan(dh, dm, ds))
        {

        }

        public override void Send()
        {
            try
            {
                SendKeys.SendWait(message);
                if (char.IsDigit(Convert.ToChar(message)))
                    Console.WriteLine(string.Format("{0}", message));
                //Writer.Write(string.Format("Sent Key {0} at {1}", message, DateTime.Now.ToLongTimeString()));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Source + " ist null");
            }
        }

    }
}
