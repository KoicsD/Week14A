using System;
using System.Collections;

namespace DictionaryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 3
            Hashtable numberLookup = new Hashtable();

            numberLookup["0"] = "Zero";
            numberLookup["1"] = "One";
            numberLookup["2"]= "Two";
            numberLookup["3"] = "Three";
            numberLookup["4"] = "Four";
            numberLookup["5"] = "Five";
            numberLookup["6"] = "Six";
            numberLookup["7"] = "Seven";
            numberLookup["8"] = "Eight";
            numberLookup["9"] = "Nine";

            string ourNumbers = "450-780-132"; // Viva PA-DÖ-DÖ for ever

            foreach (char c in ourNumbers)
            {
                string digit = c.ToString();
                if (numberLookup.ContainsKey(digit))
                    Console.WriteLine(numberLookup[digit]);
            }
        }
    }
}
