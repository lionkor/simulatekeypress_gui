using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateKeypress_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new Form1 ());
        }

        public static void Start (Form1 form, int startDelay, int charDelay,
            string[] array, bool returnE, bool returnP, bool returnR,
            bool returnQ, bool loop, bool misspell)
        {
            Thread.Sleep (startDelay);
            string text = "";
            foreach (string line in array)
            {
                if (returnR)
                {
                    text += line + '\r';
                }
                else
                {
                    text += line;
                }
            }

            while (text.Contains ("..") || text.Contains ("!!") || text.Contains ("??"))
            {
                text = text.Replace ("..", ".");
                text = text.Replace ("!!", "!");
                text = text.Replace ("??", "?");
            }
            foreach (char c in text)
            {
                Thread.Sleep (charDelay);
                if (form.Stop)
                {
                    break;
                }
                try
                {
                    if (misspell)
                    {
                        string send = c.ToString ();
                        if (new Random ().Next (0, 50) == 25)
                        {
                            send = "abcdefghijklmnopqrstuvwxyz"
                                .ToCharArray ()[new Random (Convert.ToInt32
                                    (Process.GetCurrentProcess ().TotalProcessorTime.Ticks))
                                .Next (0, 26)].ToString ();
                        }
                        SendKeys.SendWait (send);
                    }
                    else
                    {
                        SendKeys.SendWait (c.ToString ());
                    }
                }
                catch (Exception e)
                {
                    // oof
                }
                if (returnP && c == '.')
                {
                    SendKeys.SendWait ("\r");
                }
                if (returnQ && c == '?')
                {
                    SendKeys.SendWait ("\r");
                }
                if (returnE && c == '!')
                {
                    SendKeys.SendWait ("\r");
                }
                if (form.Stop)
                {
                    break;
                }
            }
        }
    }
}
