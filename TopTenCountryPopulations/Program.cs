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

            IList<Country> countries = reader.ReadAllCountries(); 
            //using IList<T> you can change the ReadAllCountries method to return an array or 
            //a list because they both implement IList<T>

            foreach(Country country in countries)
            {
                Console.WriteLine($"{country.Population} : {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}