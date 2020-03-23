using System;
using System.Collections.Generic;
using System.Text;

namespace p8PROT
{
    public class Class1
    {
        public static string mapFromRNAToAminoAlphabet(string rna) 
        {
            if (rna == null || string.IsNullOrEmpty(rna)) 
            {
                return "";
            }

            if (rna.Length % 3 != 0) {
                throw new Exception("DNA string length was not divisible by 3 ");
            }

            StringBuilder sb = new StringBuilder();

            for (var i=0; i < rna.Length; i += 3) 
            {
                string rnaFragment = rna.Substring(i, 3);
                var aminoLetter = RNACodonTable.RNAToAminoLetterEmptyStops[rnaFragment];
                sb.Append(aminoLetter);
            }
            
            return sb.ToString();
        }
    }
}
