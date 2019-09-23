using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TallProsjekt
{
    public class gjettTall
    {
        #region Public Properties
        /// <summary>
        /// Dette er det største tallet som brukeren kan gjette, mellom 0 og dette nummeret
        /// </summary>
        public int MaksTall { get; set; }

        // Holde styr på antall gjetninger
        /// <summary>
        /// Nåværende antall gjetninger som har blitt gjort
        /// </summary>
        public int AntallGjetninger { get; private set; } = 0;

        
        /// <summary>
        /// Minste tall som brukeren tenker på
        /// </summary>
        public int gjetteMin { get; private set; } = 0;
        
        /// <summary>
        /// Største tall som brukeren tenker på
        /// </summary>
        public int gjetteMaks { get; private set; }
        #endregion

        #region .ctor Konstruktør
        /// <summary>
        /// Default konstruktør
        /// </summary>
        public gjettTall()
        {
            // Sette default maks nummer
            this.MaksTall = 100;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Spør brukeren om å tenke på et tall mellom 0 og Maks tall
        /// </summary>
        public void InformerBruker()
        {
            // Spørre bruker om å tenke på ett tall mellom 0 og MaksTall
            Console.WriteLine($"Tenk på et tall mellom 0 og {MaksTall}! Trykk enter for å forsette");
            Console.ReadLine();
        }

        /// <summary>
        /// Spør brukeren en serie med spørsmål for å finne tallet de tenker på
        /// </summary>
        public void FinnTall()
        {
            // Clear variablene til default verdi før man gjennomfører funksjonen
            this.AntallGjetninger = 0;
            this.gjetteMin = 0;
            this.gjetteMaks = this.MaksTall / 2;

        
            // Mens gjettefra ikke er samme som maks
            while (this.gjetteMin != this.MaksTall)
            {
                // øk antall gjetninger med 1
                this.AntallGjetninger++;

                // Spørre bruker om tallet dems er mellom gjette området
                Console.WriteLine($"Er tallet mellom {this.gjetteMin} og {this.gjetteMaks}?");
                string svar = Console.ReadLine();

                //Har brukeren svart test
                //bool harSvar = (svar != null && svar.Length > 0);

                //Hvis brukeren svarer ja på at tallet er i gjette området
                if (svar?.ToLower().FirstOrDefault() == 'y')
                {
                    // Nummeret er mellom gjetteFra og gjetteTil
                    // Sette nytt maks nummer
                    this.MaksTall = gjetteMaks;

                    //Forandre på gjette området til å være halvparten i den nye området
                    this.gjetteMaks -= (this.gjetteMaks - this.gjetteMin) / 2;
                }
                //Nummeret er større enn gjetteMaks og mindre enn eller lik maks
                else
                {
                    //Den nye gjette minimum som er over gamle gjette maksimum
                    this.gjetteMin = this.gjetteMaks + 1;

                    // Gjett nedre tall av det nye område
                    int forskjell = this.MaksTall - this.gjetteMaks;
                    // Sette gjette maks til halvparten av forskjellen mellom gjetteMin og maks
                    // PS: Math.Ceiling vil runde opp tallet til 2 hvis differansen mellom min og maks er 3
                    this.gjetteMaks += (int)Math.Ceiling(forskjell / 2f);
                }

                //Hvis det bare er to tall igjen, gjett en av dem
                if (this.gjetteMin + 1 == this.MaksTall)
                {
                    // øk antall gjetninger med 1
                    this.AntallGjetninger++;

                    // Spørre bruker om det er det mindre tallet
                    Console.WriteLine($"Er tallet ditt {this.gjetteMin}?");
                    svar = Console.ReadLine();
                    //Hvis tallet er det mindre tallet
                    if (svar?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        //Det betyr at nummeret er det høyere tallet
                        this.gjetteMin = this.MaksTall;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Viser hvor mange gjetninger det tok for å finne nummeret brukeren tenkte på
        /// </summary>
        public void VisResultat()
        {
            // Fortelle brukeren nummeret
            Console.WriteLine($"** Tallet ditt er {gjetteMin} **");

            // Fortell brukeren hvor mange gjetninger det tok
            Console.WriteLine($"Det tok deg {this.AntallGjetninger} gjetninger!");

            Console.ReadLine();
        }
        #endregion
    }
}
