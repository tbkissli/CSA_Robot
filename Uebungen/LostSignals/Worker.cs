using System;
using System.Threading;

namespace LostSignals {

    class Worker {

        private ISynch signal;
        private Operator op;
        private String id;

        public Worker(ISynch signal, Operator op, String id) {
            this.signal = signal;
            this.op = op;
            this.id = id;
        }
        public void Do() {
            while (true) {
                signal.Acquire();
                Console.WriteLine(id + " released...");
                Thread.Sleep(op.Operation());
                op.Done(id);
            }
        }
    }
}
