using System;
using System.Diagnostics;

namespace Pi_Berechnung
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Math.PI);

            double pi = 0;
            const int anzahlAufrufe = 4;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i < anzahlAufrufe + 1; i++)
            {
                pi += PI_Berechnung(i, anzahlAufrufe);
            }

            sw.Stop();

            Console.WriteLine(pi);

            Console.WriteLine("Dauer {0:N0} Millisekunden", sw.ElapsedMilliseconds);
        }

        // Nach John Machin (http://de.wikipedia.org/wiki/John_Machin)
        private static double PI_Berechnung(int startwert, int schrittweite)
        {
            const double durchlaeufe = 1_000_000_000;
            double x, y = 1 / durchlaeufe;
            double summe = 0;
            double pi;

            for (double i = startwert; i <= durchlaeufe; i += schrittweite)
            {
                x = y * (i - 0.5);
                summe += 4.0 / (1 + x * x);
            }

            pi = y * summe;

            return pi;
        }
    }
}