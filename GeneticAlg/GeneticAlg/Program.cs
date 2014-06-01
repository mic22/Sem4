using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    static class Losuj
    {
        static public Random rand = new Random();
        static public bool Next(double probability)
        {
            return rand.NextDouble() < probability ? true : false;
        }
    }

    class Individual
    {
        private double Probability;
        public bool[] Chromosome { get; set; }
        public double Fitness { get; set; }
        public void Mutate()
        {
            Random rand = new Random();
            for (int i = 0; i < Chromosome.Length - 1; i++ )
            {
                if (rand.NextDouble() < Probability)
                    Chromosome[i] = Chromosome[i] ? false : true;
            }
        }
        public Individual(Func<Individual, double> fitness, int size = 1, double probability = 0.5, bool randomize = false)
        {
            double Probability = probability;
            Chromosome = new bool[size];

            if (randomize)
            {
                for (int i = 0; i < size; i++)
                {
                    Chromosome[i] = Losuj.Next(Probability);
                }
            }

            Fitness = fitness(this);
        }
        public double Phenotype {
            get { return Decode(); }
        }

        public void Display()
        {
            Console.Write("[");
            foreach (var item in Chromosome)
                Console.Write(item ? " 1" : " 0");
            Console.WriteLine(" ]");

            Console.WriteLine("x = {0}", Phenotype);
            Console.WriteLine("");
        }

        private double Decode()
        {
            double result = 0;
            double power = 1;
            for (int i = Chromosome.Length-1; i >= 0; i--)
			{
			    if(Chromosome[i])
                    result += power;

                power *= 2;
			}
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var osobnik = new Individual(individual => 2*individual.Phenotype+1, 5, 0.7, true);
            osobnik.Display();
            osobnik.Mutate();
            osobnik.Display();
        }
    }
}
