using System;
using System.Collections.Generic;
using System.Linq;

namespace TopTenCountryPopulations
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
    
            foreach(string region in countries.Keys)
            {
                Console.WriteLine(region);
            }

            Console.WriteLine("Which region above do you want? ");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"{country.Population}: {country.Name}");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid region");
            }
        }
    }
}