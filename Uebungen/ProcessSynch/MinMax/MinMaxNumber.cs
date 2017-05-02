using System;
using System.IO;
using System.Threading;

namespace MinMax {

    class MinMaxNumber {

        static void Main() {
            int min = 0;
            int max = 0;
            Console.WriteLine("MinMax");
            using (StreamReader sr = new StreamReader("daten.txt")) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    int num = Int32.Parse(line);
                    min = min > num ? num : min;
                    max = max < num ? num : max;
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Min := " + min);
            Console.WriteLine("Max := " + max);
            Console.ReadLine();
        }
    }
}
