using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateKeypress_GUI
{
    public partial class Form1 : Form
    {
        public bool Stop = false;

        public Form1 ()
        {
            InitializeComponent ();
            Text += ProductVersion;
        }

        private void StartButton_Click (object sender, EventArgs e)
        {
            if (TextBox.Text.Length == 0)
            {
                return;
            }
            
            Stop = false;
            StopButton.Enabled = true;
            disableAll ();
            Program.Start (
                this, Convert.ToInt32 (TimeBeforeStart.Value),
                Convert.ToInt32 (DelayMS.Value),
                TextBox.Lines, returnExclamation.Checked,
                returnPeriod.Checked, returnR.Checked,
                returnQuestion.Checked, InfiniteLoop.Checked);
            stop ();
            
            enableAll ();
        }

        private void StopButton_Click (object sender, EventArgs e)
        {
            stop ();
        }

        void stop ()
        {
            Stop = true;
            StopButton.Enabled = false;
            enableAll ();
        }

        void disableAll ()
        {
            StartButton.Enabled = false;
            DelayMS.Enabled = false;
            returnExclamation.Enabled = false;
            returnPeriod.Enabled = false;
            returnQuestion.Enabled = false;
            returnR.Enabled = false;
            TextBox.Enabled = false;
            InfiniteLoop.Enabled = false;
            TimeBeforeStart.Enabled = false;
        }

        void enableAll ()
        {
            StartButton.Enabled = true;
            DelayMS.Enabled = true;
            returnExclamation.Enabled = true;
            returnPeriod.Enabled = true;
            returnQuestion.Enabled = true;
            returnR.Enabled = true;
            TextBox.Enabled = true;
            InfiniteLoop.Enabled = true;
            TimeBeforeStart.Enabled = true;
        }

        private void linkLabel1_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start ("https://github.com/lionkor/simulatekeypress_gui/releases/");
        }
    }
}
