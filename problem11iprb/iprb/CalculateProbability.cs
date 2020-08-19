using System;

namespace iprb
{
    public class CalculateProbability
    {
        private const double punnet_two_dom = 1.0;

        private const double punnet_dom_hetero = 1.0;

        private const double punnet_dom_rec = 1.0;

        private const double punnet_hetero_hetero = 0.75;

        private const double punnet_hetero_hRecessive = 0.5;

        private const double punnet_rec_rec = 0;

        public double computeProbability(int k, int m, int n) 
        {
            double total = k + m + n;

            //There are 9 cases since we pick random indivuduals twice, and each of them can be 1 of 3 types.

            double probHDOM = (k / total);

            double probHetero = (m / total);

            double probHRec = (n / total);


            double probHDOM_HDOM = probHDOM * ((k - 1) / (total - 1));

            double probHDOM_Hetero = probHDOM * (m / (total - 1));

            double probHDOM_HRec = probHDOM * (n / (total - 1));


            double probHetero_HDOM = probHetero * (k / (total - 1));

            double probHetero_Hetero = probHetero * ((m - 1) / (total - 1));

            double probHetero_HRec = probHetero * (n / (total - 1));


            double probHRec_HDOM = probHRec * (k / (total - 1));

            double probHRec_Hetero = probHRec * (m / (total - 1));

            double probHRec_HRec = probHRec * ((n - 1) / (total - 1));


            //The result of a punnet square would be the chance for a dominant alelle 
            //https://en.wikipedia.org/wiki/Punnett_square

            //Given two dom , chance of dom allele = 1.0
            probHDOM_HDOM = probHDOM_HDOM * punnet_two_dom;

            //Given dom + hetero, chance of dom allele = 1.0
            probHDOM_Hetero = probHDOM_Hetero * punnet_dom_hetero;

            //Given dom + reccecive, chance of dom allele = 1.0
            probHDOM_HRec = probHDOM_HRec * punnet_dom_rec;

            //Given hetero + dom, chance of dom allele = 1.0
            probHetero_HDOM = probHetero_HDOM * punnet_dom_hetero;

            //Given hetero + hetero, chance of dom allele = 0.75
            probHetero_Hetero = probHetero_Hetero * punnet_hetero_hetero;

            //Given hetero + hRecessive , chance of dom allele = 0.5
            probHetero_HRec = probHetero_HRec * punnet_hetero_hRecessive;

            //Given HRecessive  + HDom, chance of dom allele = 1.0
            probHRec_HDOM = probHRec_HDOM * punnet_dom_rec;

            //Given HRecessive  + Hetero, chance of dom allele = 0.5
            probHRec_Hetero *= punnet_hetero_hRecessive;

            //Give HRecessive  + recessive , chance dom allele = 0;
            probHRec_HRec = probHRec_HRec * punnet_rec_rec;


            return probHDOM_HDOM + probHDOM_Hetero + probHDOM_HRec + probHetero_HDOM + probHetero_Hetero + probHetero_HRec + probHRec_HDOM + probHRec_Hetero + probHRec_HRec;
        }
    }
}
