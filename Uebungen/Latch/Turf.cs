using System.Threading;

namespace Latch {

    class Turf {

        static void Main() {
            ISynch startBox = new Latch();
            for (int i = 1; i <= 5; i++) {
                new Thread(new RaceHorse(i, startBox).Run).Start();
            }
            Thread.Sleep(100); // Damit alle Pferde in der Startbox sind und nicht bereits schon einige gestartet sind.
            System.Console.WriteLine("Start...");
            startBox.Release();
        }
    }
}
