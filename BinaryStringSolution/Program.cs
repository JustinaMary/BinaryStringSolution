using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryStringSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryString = "";
            Console.WriteLine("Please enter the binary string!");
            binaryString = Console.ReadLine();
            if (!string.IsNullOrEmpty(binaryString))
            {
                var result = IsGoodBinaryString(binaryString);
                Console.WriteLine(result);
            }
        }

        static string IsGoodBinaryString(string binaryString)
        {
            char[] a = { '0', '1' };
            var b = binaryString.Distinct().ToArray().OrderBy(t=>t).ToArray();
            // checking whether the string is valid binary string or not
            if (b.SequenceEqual(a) || b.SequenceEqual(new char[] { '0' }))
            {
                // getting the counts of 1s and 0s from the given binary string
                int oneCount = binaryString.Count(f => (f == '1'));
                int zeroCount = binaryString.Count(f => (f == '0'));

                // if the count of both 1s and 0s equals
                if (zeroCount == oneCount)
                {
                    // getting the list of prefixes from the given binary string
                    var prefixes = Enumerable.Range(1, binaryString.Length)
                         .Select(p => binaryString.Substring(0, p));

                    foreach (var item in prefixes)
                    {
                        int prefixOnes = item.Count(f => (f == '1'));
                        int prefixZeros = item.Count(f => (f == '0'));
                        // if count of 1 whould be less than 0
                        if (prefixOnes < prefixZeros)
                        {
                            return "It's a not good binary string";
                        }
                    }
                    // if the given string satisfies both the required condition
                    return "It's a good binary string";
                }
                else
                {
                    return "It's not a good binary string";
                }
            }
            else
            {
                return "It's not a valid binary string";
            }
        }
    }
}
