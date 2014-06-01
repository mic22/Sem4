using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizytowka
{
    class Person
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
 
        public Person(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
