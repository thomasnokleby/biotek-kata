using System;

namespace p6HAMM
{
    public class Class1
    {

        public static int HammingDistance(string DNAA, string DNAB) 
        {
            int hammingDistance = 0;

            if (DNAA == null || DNAB == null || DNAA.Length != DNAB.Length) 
            {
                throw new Exception("Input data is either null or strings are different lengths");
            }
            DNAA = DNAA.ToLowerInvariant();
            DNAB = DNAB.ToLowerInvariant();

            var cArrayA = DNAA.ToCharArray();
            var cArrayB = DNAB.ToCharArray();

            for (int i = 0; i < cArrayA.Length; i++) 
            {
                if (cArrayA[i] != cArrayB[i]) {
                    hammingDistance++;
                }
            }
            return hammingDistance; 
        }
    }
}
