using System;
using System.Collections.Generic;

namespace p9SUBS
{
    public class Class1
    {
        public static List<int> findAllOccurencesOfSubstring(string data, string subStringToFind) 
        {
            bool done = false;
            List<int> results = new List<int>();
            int startIndex = 0;

            while (!done) 
            {
                var index = data.IndexOf(subStringToFind, startIndex);
                if (index == -1)
                {
                    done = true;
                }
                else 
                {
                    startIndex = index + 1;
                    results.Add(index+1); //Go from 0 based to 1 based
                    if (startIndex >= data.Length) 
                    {
                        done = true;
                    }
                }
            }
            return results;
        }
    }
}
