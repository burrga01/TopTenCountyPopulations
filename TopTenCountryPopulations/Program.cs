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

            List<Country> countries = reader.ReadAllCountries();

            var filteredCountries = countries.Where(x => !x.Name.Contains(','));//.Take(20);
            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country;
            foreach (Country country in filteredCountries2)
            {
                Console.WriteLine($"{country.Population} : {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}