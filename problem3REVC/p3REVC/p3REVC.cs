using System;
using System.Text;

namespace p3REVC
{
    public class p3REVC
    {
        public static string ComplementDNA(string DNA)
        {
            //reverse
            var DNAReversedArray = DNA.ToCharArray();
            Array.Reverse(DNAReversedArray);

            //then complement
            return complimentDNA(new string (DNAReversedArray));
        }

        private static string complimentDNA(string DNA) {
            //a->t && t->a
            //c->g && g->c
            StringBuilder sb = new StringBuilder("", DNA.Length);

            foreach( var c in DNA)
            {
                switch (c.ToString().ToUpper()) 
                {
                    case "A" :  sb.Append('T');    
                    break;
                    case "T" :  sb.Append('A');    
                    break;
                    case "C" :  sb.Append('G');    
                    break;
                    case "G" :  sb.Append('C');    
                    break;
                }
            }
            return sb.ToString();
        }
    }
}
