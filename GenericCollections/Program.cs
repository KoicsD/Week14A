using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 5
            Dictionary<int, string> countryLookup = new Dictionary<int, string>();

            countryLookup[36] = "Hungary";
            countryLookup[49] = "Germany";
            countryLookup[44] = "United Kingdom";
            countryLookup[33] = "France";
            countryLookup[31] = "Netherlands";
            countryLookup[55] = "Brazil";

            Console.WriteLine("Code 36 stands for {0}", countryLookup[36]);

            foreach (KeyValuePair<int, string> item in countryLookup)
            {
                int code = item.Key;
                string country = item.Value;
                Console.WriteLine("Code {0} stands for {1}", code, country);
            }
        }
    }
}
