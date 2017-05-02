using System;
using System.Threading;

namespace Latch {

    class RaceHorse {

        private ISynch startSignal;
        private int nr;

        public RaceHorse(int nr, ISynch startSignal) {
            this.nr = nr;
            this.startSignal = startSignal;
        }
        public void Run() {
            Console.WriteLine("Rennpferd " + nr + " geht in die Startbox.");
            startSignal.Acquire();
            Console.WriteLine("Rennpferd " + nr + " l�uft los.");
            Thread.Sleep(new Random().Next(3000));
            Console.WriteLine("Rennpferd " + nr + " ist im Ziel.");
        }
    }
}
