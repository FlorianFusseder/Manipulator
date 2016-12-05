using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manipulator
{
    class Game
    {
        protected string gameName;

        public string GameName
        {
            get { return gameName; }
            set { gameName = value; }
        }

        private List<GameEvent> gameEvents;

        public List<GameEvent> GameEvents
        {
            get { return gameEvents; }
            set { gameEvents = value; }
        }

        private IntPtr gamePtr;

        public IntPtr GamePtr
        {
            get { return gamePtr; }
            set { gamePtr = value; }
        }


        public Game(string gameName)
            :this(gameName, new List<GameEvent>())
        {
        }

        public Game(string gameName, List<GameEvent> gameEvents)
        {
            this.gameName = gameName;
            this.gameEvents = gameEvents;
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public bool CanSend()
        {
            gamePtr = FindWindow(null, gameName);
            

            if (gamePtr == IntPtr.Zero)
            {
                MessageBox.Show(gameName + " is not running.");
                return false;
            }

            SetForegroundWindow(gamePtr);
            return true;
        }

        public void AddEvent(GameEvent e)
        {
            gameEvents.Add(e);
        }

        public void Start()
        {
            if (gameEvents.Count > 0)
                foreach (var item in gameEvents)
                {
                    System.Threading.Timer timer = new System.Threading.Timer(delegate { CanSend(); item.Send();  }, null, item.Delay, item.Span);
                }
            else
                MessageBox.Show("Keine Events registriert");

            Console.ReadLine();
        }
    }
}
