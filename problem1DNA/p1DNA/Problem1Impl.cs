using System;

namespace p1DNA
{
    public class Problem1Impl
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem1DNA\p1DNA.tests\DNA.txt");
            var result  = Problem1Impl.countACGT(text);
            Console.WriteLine(result.ACount + " " + result.CCount + " " + result.GCount + " " + result.TCount);
            Console.WriteLine("Hello World :) (v2.0)");
        }

        public static DNACount countACGT(string DNAString) 
        {
            if (DNAString == null || string.IsNullOrWhiteSpace(DNAString)) 
            {
                throw new Exception("DNA String to count was empty");
            }
            var result = new DNACount();

            var count = new DNACount();
            foreach( var c in DNAString)
            {
                switch (c.ToString().ToLower()) 
                {
                    case "a" :  result.ACount++;    
                    break;
                    case "t" :  result.TCount++;    
                    break;
                    case "c" :  result.CCount++;    
                    break;
                    case "g" :  result.GCount++;    
                    break;
                }
            }
            return result;
        }


        public class DNACount 
        {
            public long ACount { get; set;}
            public long CCount { get; set;}
            public long GCount { get; set;}
            public long TCount { get; set;}
        }
    }
}



