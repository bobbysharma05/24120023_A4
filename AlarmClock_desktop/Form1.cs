using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace AlarmClock_desktop
{
    public partial class Form1 : Form
    {
        private DateTime targetTime;
        private bool isRunning = false;
        private System.Windows.Forms.Timer colorTimer;
        private Random random = new Random();

        public delegate void AlarmEventHandler(object source, EventArgs args);
        public event AlarmEventHandler RaiseAlarm;

        public Form1()
        {
            InitializeComponent();
            RaiseAlarm += Ring_Alarm;

            colorTimer = new System.Windows.Forms.Timer();
            colorTimer.Interval = 1000;
            colorTimer.Tick += ColorTimer_Tick;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           if (isRunning)
           {
                return;
           }

            string timeInput = txtTargetTime.Text;

            try
            {
                targetTime = DateTime.ParseExact(timeInput, "HH:mm:ss", null);

                isRunning = true;
                btnStart.Enabled = false;
                txtTargetTime.Enabled = false;

                colorTimer.Start();

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += TimeMonitoring_DoWork;
                worker.RunWorkerCompleted += TimeMonitoring_Completed;
                worker.RunWorkerAsync();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid time format. format => HH:MM:SS ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            this.BackColor = GetRandomColor();
            UpdateCurrentTimeDisplay();
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(150, 256), random.Next(150, 256), random.Next(150, 256));
        }

        private void TimeMonitoring_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isRunning)
            {
                DateTime currTime = DateTime.Now;

                if(currTime.Hour == targetTime.Hour && currTime.Minute == targetTime.Minute && currTime.Second == targetTime.Second)
                {
                    isRunning = false;
                    this.Invoke(new Action(() => { OnRaiseAlarm(); }));
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private void TimeMonitoring_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = true;
            txtTargetTime.Enabled = true;
        }

        private void UpdateCurrentTimeDisplay()
        {
            this.lblCurrentTime.Text = "Current Time: " + DateTime.Now.ToString("HH:mm:ss");
        }

        protected virtual void OnRaiseAlarm()
        {
            colorTimer.Stop();
            if(RaiseAlarm != null)
            {
                RaiseAlarm(this, EventArgs.Empty);
            }
        }
        public void Ring_Alarm(object source, EventArgs e)
        {
            MessageBox.Show("ALARM! Time ho gya bhai", "Alarm Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }   
}
