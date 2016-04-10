using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;


namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Excersise 4
            ListDictionary dictionary = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));

            dictionary["Estados Unidos"] = "United States of America";
            dictionary["Canadá"] = "Canada";
            dictionary["España"] = "Spain";

            Console.WriteLine(dictionary["España"]);
            Console.WriteLine(dictionary["Canadá"]);
        }
    }
}
