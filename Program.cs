using System;
using System.Collections.Generic;
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
            string[] array, bool returnE, bool returnP, bool returnR, bool returnQ, bool loop)
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
            do
            {
                foreach (char c in text)
                {
                    Thread.Sleep (charDelay);
                    if (form.Stop)
                    {
                        return;
                    }
                    try
                    {
                        SendKeys.SendWait (c.ToString ());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine (c + " : " + e);
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
                    //if (returnR && c == '\r')
                    //{
                    //    SendKeys.SendWait ("\r");
                    //}
                }
            }
            while (loop);
        }
    }
}
