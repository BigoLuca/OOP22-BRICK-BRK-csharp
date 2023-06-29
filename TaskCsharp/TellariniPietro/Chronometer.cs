using System;
using System.Threading;

namespace brickbreaker.common
{
    public class Chronometer
    {
        private int time;
        private bool isRunning;
        private bool exit;
        private Thread thread;
        private readonly object lockObject;

        public Chronometer()
        {
            time = 1;
            isRunning = false;
            exit = false;
            lockObject = new object();
        }

        public int GetElapsedTime()
        {
            return time / 10;
        }

        public void StartChrono()
        {
            lock (lockObject)
            {
                if (thread == null)
                {
                    thread = new Thread(Run);
                    thread.Start();
                }
                isRunning = true;
                Monitor.Pulse(lockObject);
            }
        }

        public void PauseChrono()
        {
            lock (lockObject)
            {
                isRunning = false;
            }
        }

        public void StopChrono()
        {
            lock (lockObject)
            {
                isRunning = false;
                exit = true;
                Monitor.Pulse(lockObject);
            }
        }

        private void Run()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (exit)
                        break;

                    if (!isRunning)
                    {
                        Monitor.Wait(lockObject);
                        continue;
                    }

                    try
                    {
                        Monitor.Wait(lockObject, 1000);
                        time++;
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
        }
    }
}
