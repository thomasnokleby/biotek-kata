using System;
using System.Collections.Generic;
using System.Text;

namespace p5GC
{
    public static class Class1
    {

        public static LabeledDNASequence getHighestGCContent(List<LabeledDNASequence> labeledDNAs) 
        {
            double highestThusfar = double.MinValue;
            LabeledDNASequence highestSeq = null;

            foreach (var DNASeq in labeledDNAs)
            {
                var score = findGCContent(DNASeq);
                if (score > highestThusfar) 
                {
                    highestThusfar = score;
                    highestSeq = DNASeq;
                }
            }
            return highestSeq;
        }

        public static double findGCContent(LabeledDNASequence lds)
        {
            return findGCContent(lds.DNASequence);
        }

        public static double findGCContent(string DNA)
        {
            if (DNA == null || string.IsNullOrWhiteSpace(DNA))
            {
                throw new Exception("Can not find GC Content of null/empty string");
            }
            DNA = DNA.Trim();
            DNA = DNA.ToLower();

            var DNAArray = DNA.ToCharArray();
            int DNALength = DNAArray.Length;
            
            int GCCharCount = 0;
            foreach (char c in DNAArray)
            {
                if (c == 'g' || c == 'c')
                {
                    GCCharCount++;
                }
            }
            return (double)((double)GCCharCount / (double)DNALength)*100d;
        }

        public static List<LabeledDNASequence> loadFASTA(string fileIncludingPath)
        {
            string text = System.IO.File.ReadAllText(fileIncludingPath);
            List<LabeledDNASequence> result = new List<LabeledDNASequence>();
            bool done = false;
            int charpointer = 0;
            while (!done)
            {
                //find >
                //rest of line to CRLF is the label
                int labelStart = text.IndexOf('>', charpointer);
                if (labelStart == -1) {
                    done = true;
                    continue;
                }

                int labelEnd = text.IndexOf("\r\n", labelStart, StringComparison.InvariantCulture);
                string label = text.Substring(labelStart, (labelEnd - labelStart));

                //scan & accumulate to next >(NOT CRLF). This accumulated text is the DNA string
                labelEnd = labelEnd + 2; //Scan past CRLF in label
                int DNAStart = labelEnd;
                int DNAEnd = text.IndexOf('>', labelEnd);
                if (DNAEnd == -1) {
                    DNAEnd = (text.Length - 1);
                    done = true;
                }

                string DNASequence = text.Substring(DNAStart, (DNAEnd - DNAStart));
                DNASequence = stripCRLF(DNASequence);

                LabeledDNASequence seq = new LabeledDNASequence
                {
                    Label = label,
                    DNASequence = DNASequence
                };
                result.Add(seq);
                charpointer = DNAEnd;
            }
            return result;
        }

        private static string stripCRLF(string DNASequence)
        {
            var asChars = DNASequence.ToCharArray();
            StringBuilder sb = new StringBuilder();

            foreach (char c in asChars) 
            {
                if (c != '\r' && c != '\n') 
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
