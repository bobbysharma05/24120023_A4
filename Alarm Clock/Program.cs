using System;
using System.Threading;

namespace AlarmClockApp 
{
    public class TimeMonitor
    {
        public delegate void AlarmEventHandler(object source, EventArgs args);
        public event AlarmEventHandler RaiseAlarm;
        private DateTime targetTime;
        private bool isRunning;

        public TimeMonitor(DateTime targetTime)
        {
            this.targetTime = targetTime;
            this.isRunning = false;
        }

        public void StartMonitoring()
        {
            isRunning = true;
            Console.WriteLine("Alarm set for: " + targetTime.ToString("HH:mm:ss"));
            Console.WriteLine("Monitoring ...");

            while(isRunning)
            {
                DateTime currTime = DateTime.Now;

                if(currTime.Hour == targetTime.Hour && currTime.Minute == targetTime.Minute && currTime.Second == targetTime.Second)
                {
                    OnRaiseAlarm();
                    isRunning = false;
                }
                Console.Write("\rCurrent Time: " + currTime.ToString("HH:mm:ss"));
                Thread.Sleep(1000);
            }    
        }

        protected virtual void OnRaiseAlarm()
        {
            if ( RaiseAlarm != null) 
            {
                RaiseAlarm(this, EventArgs.Empty);
            }
        }
    }

    public class AlarmListener
    {
        public void RingAlarm(object source, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Uth ja bhai! Time ho gya");
        }
    }

    class Program 
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Alam System -> ");

            DateTime targetTime;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter time in HH:MM:SS format: ");
                string timeInput = Console.ReadLine();

                try
                {
                    Console.WriteLine("hell");
                    targetTime = DateTime.ParseExact(timeInput, "HH:mm:ss", null);
                    Console.WriteLine("1");
                    TimeMonitor monitor = new TimeMonitor(targetTime);
                    AlarmListener listener = new AlarmListener();

                    monitor.RaiseAlarm += listener.RingAlarm;
                    monitor.StartMonitoring();
                    validInput = true;
                }
                catch
                {
                    Console.WriteLine("Invalid time format.");
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }    
    }

}