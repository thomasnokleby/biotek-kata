using System;

namespace p2RNA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static string TranscribeDNAtoRNA(string DNA)
        {
            return DNA.Replace('t','u').Replace('T','U');
        }
    }
}
