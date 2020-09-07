using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace TopTenCountryPopulations
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();
            reader.RemoveCommaCountries(countries);

            Console.Write("Enter no. of countries to display>  ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if(!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }

            int maxToDisplay = userInput;
            for(int i = 0; i < countries.Count; i++)
            {
                if(i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                    
                }
                Country country = countries[i];
                Console.WriteLine($"{i+1}: {country.Population}: {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}