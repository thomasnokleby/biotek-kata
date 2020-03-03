using System;
using System.Collections.Generic;

namespace p4FIB
{
    public class p4FIB
    {
        public static long computeFibonacciSum(long n) 
        {
            if (n == 1) return n;
            if (n == 2) return 2;

            
            long intermediate = 1;
            long result = 2;

            for (var i = 1; i < n - 2; i++)
            {
                var tmp = result;
                result = result + intermediate;
                intermediate = tmp;
            }
            return result;
        }

        public static long computeFibWithKMultiplier(long n, long k) 
        {
            if (n == 1) return n;
            if (n == 2) return 2;


            long intermediate = 1;
            long result = 1;

            for (var i = 3; i <= n ; i++)
            {
                var tmp = result;
                result = result + intermediate*k;
                intermediate = tmp;
            }
            return result;

        }
    }
}
