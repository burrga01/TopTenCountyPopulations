using System;
using System.Collections.Generic;

namespace TopTenCountryPopulations
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = new List<Country>();

            foreach(Country country in countries)
            {
                Console.WriteLine($"{country.Population} : {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}