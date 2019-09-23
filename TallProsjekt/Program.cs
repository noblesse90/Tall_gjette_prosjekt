using System;
using System.Linq;

namespace TallProsjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lage et instans av klassen gjettTall
            var gjettTall = new gjettTall();

            // sette ny verdi for MaksTall
            gjettTall.MaksTall = 100;

            // Spørre brukeren om å tenke på et tall
            gjettTall.InformerBruker();

            //Finn tallet brukeren tenker på
            gjettTall.FinnTall();

            // Vis hvor mange antall gjetninger det tok for å finne tallet
            gjettTall.VisResultat();
        }
    }
}
