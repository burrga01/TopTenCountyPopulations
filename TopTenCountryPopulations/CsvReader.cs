using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace TopTenCountryPopulations
{
    class CsvReader
    {
        private string _csvFilePath;
        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }


        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();
            using (var reader = File.OpenText(_csvFilePath))
            {
                //call read line onece to get rid of header file
                reader.ReadLine();
                string csvLine;
                while ((csvLine = reader.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country);
                }
            }

            return countries;
        }
        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name;
            string code;
            string region;
            string popText;

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + "," + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }
    }
}
