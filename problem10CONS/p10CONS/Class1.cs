using System;
using System.Collections.Generic;
using System.Text;

namespace p10CONS
{
    public class Class1
    {
        public static ConsensusAndMatrix getConsensusFromFile(string fileWithPath) {

            string consensusString = "";

            //load the fastas into some list
            List<LabeledDNASequence> dnaList = FASTALoader.loadFASTA(fileWithPath);

            //Verify all equal length
            int someLength = dnaList[0].DNASequence.Length;
            foreach (var dna in dnaList) 
            {
                if (dna.DNASequence.Length != someLength) 
                {
                    throw new Exception($"DNA strings in data set had inequal lengths! Initial length {someLength}, other length, for dna with label {dna.Label} was {dna.DNASequence.Length}");
                }
            }

            var matrix = createProfileMatrix(dnaList);

            consensusString = createConsensusString(matrix);
        
            var retval = new ConsensusAndMatrix();
            retval.ConsensusString = consensusString;
            retval.Matrix = matrix;

            return retval ;
        }

        private static string createConsensusString(int[,] matrix) 
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(1); i++) 
            {
                sb.Append(determineConsensus(matrix, i));
            }
            return sb.ToString();
        }

        private static char determineConsensus(int[,] matrix, int columnToConsider) 
        {
            int aCount = matrix[0, columnToConsider];
            int cCount = matrix[1, columnToConsider];
            int gCount = matrix[2, columnToConsider];
            int tCount = matrix[3, columnToConsider];

            if (aCount >= cCount && aCount >= gCount && aCount >= tCount) 
            {
                return 'A';
            }
            if (cCount >= aCount && cCount >= gCount && cCount >= tCount)
            {
                return 'C';
            }
            if (gCount >= cCount && gCount >= aCount && gCount >= tCount)
            {
                return 'G';
            }
            if (tCount >= cCount && tCount >= gCount && tCount >= aCount)
            {
                return 'T';
            }
            return 'X';
        }

        private static int [,] createProfileMatrix(List<LabeledDNASequence> dnaList) 
        {
            var cols = dnaList[0].DNASequence.Length;
            var numberOfDNAs = dnaList.Count;

            int[,] profileMatrix = new int[4, cols]; //4 rows : ACGT

            for (int i = 0; i < cols; i++) 
            {
                for (int j =0; j < numberOfDNAs;j++) 
                {
                    var actualDna = dnaList[j].DNASequence.ToLowerInvariant();

                    if (actualDna[i] == 'a') 
                    {
                        profileMatrix[0, i]++;
                    }

                    if (actualDna[i] == 'c')
                    {
                        profileMatrix[1, i]++;
                    }

                    if (actualDna[i] == 'g')
                    {
                        profileMatrix[2, i]++;
                    }

                    if (actualDna[i] == 't')
                    {
                        profileMatrix[3, i]++;
                    }
                }
            }

            return profileMatrix;
        }
        
        public class ConsensusAndMatrix 
        {
            public int[,] Matrix { get; set; }
            public string ConsensusString { get; set; }

            public string MatrixToString() 
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("A:");
                for (int i = 0; i < Matrix.GetLength(1); i++) 
                {
                    sb.Append(" " + Matrix[0,i]);
                }
                sb.Append("\r\n");

                sb.Append("C:");
                for (int i = 0; i < Matrix.GetLength(1); i++)
                {
                    sb.Append(" " + Matrix[1, i]);
                }
                sb.Append("\r\n");

                sb.Append("G:");
                for (int i = 0; i < Matrix.GetLength(1); i++)
                {
                    sb.Append(" " + Matrix[2, i]);
                }
                sb.Append("\r\n");

                sb.Append("T:");
                for (int i = 0; i < Matrix.GetLength(1); i++)
                {
                    sb.Append(" " + Matrix[3, i]);
                }
                sb.Append("\r\n");
                return sb.ToString();
            }
        }
    }
}
