using System;
using System.Threading;

namespace WaitPool {

    class TestWaitPool {

        static void Main() {
            Object synch = new Object();
            MyThread myThread = new MyThread(synch);
            new Thread(myThread.Run).Start();
            Thread.Sleep(1000);
            lock (myThread)
            {
                Monitor.Pulse(myThread);
            }

        }
    }
}
