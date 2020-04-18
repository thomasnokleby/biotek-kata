using System;
using System.Collections.Generic;
using System.Text;

namespace p10CONS
{
    public class FASTALoader
    {
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
                if (labelStart == -1)
                {
                    done = true;
                    continue;
                }

                int labelEnd = text.IndexOf("\r\n", labelStart, StringComparison.InvariantCulture);
                string label = text.Substring(labelStart, (labelEnd - labelStart));

                //scan & accumulate to next >(NOT CRLF). This accumulated text is the DNA string
                labelEnd = labelEnd + 2; //Scan past CRLF in label
                int DNAStart = labelEnd;
                int DNAEnd = text.IndexOf('>', labelEnd);
                if (DNAEnd == -1)
                {
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
