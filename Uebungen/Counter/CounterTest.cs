using System;
using System.Threading;

namespace Counter {

    class CounterTest {

        private String id;
        private Counter counter;
        

        public CounterTest(String id, Counter counter) {
            this.id = id;
            this.counter = counter;
        }
        void Go() {
            while (true) {
                Thread.Sleep(100);
                // bei lock(this) geht es nicht, da drei verschiedene Threads sind
                //lock(counter) // warum ist dies keine gute Idee? Funktioniert nur solange NextNumber von hier aufgerufen wird
                {
                    System.Console.WriteLine(id + counter.NextNumber());
                }
                
            }
        }
        static void Main() {
            Counter counter = new Counter();
            CounterTest ct1 = new CounterTest("T1: ", counter);
            CounterTest ct2 = new CounterTest("T2: ", counter);
            CounterTest ct3 = new CounterTest("T3: ", counter);
            new Thread(ct1.Go).Start();
            new Thread(ct2.Go).Start();
            new Thread(ct3.Go).Start();
        }
    }
}
