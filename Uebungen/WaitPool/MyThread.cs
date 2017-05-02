using System;
using System.Threading;

namespace WaitPool {

    class MyThread {

        private Object synch;

        public MyThread(Object synch) {
            this.synch = synch;
        }

        public void Run() {
            Console.WriteLine("warten...");
            lock (synch) {
                Monitor.Wait(this);
            }
            Console.WriteLine("...aufgewacht");
        }
    }
}
