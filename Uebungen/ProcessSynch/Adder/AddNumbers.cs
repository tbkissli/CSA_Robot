using System;
using System.IO;
using System.Threading;

namespace Adder {

    class AddNumbers {

        static void Main() {
            int summe = 0;
            Console.WriteLine("Addierer");
            using (StreamReader sr = new StreamReader("daten.txt")) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    summe += Int32.Parse(line);
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Summe := " + summe);
            Console.ReadLine();
        }
    }
}
