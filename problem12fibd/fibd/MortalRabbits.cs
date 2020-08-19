using System;
using System.Collections.Generic;
using System.Numerics;

namespace fibd
{
    public class MortalRabbits
    {
        public int simulateRabbits(int monthsOfSimulations, int rabbitLivesThisManyMonths) 
        {
            List<RabbitPair> poulation = new List<RabbitPair>();

            //Initial population:
            var rabbit = new RabbitPair
            {
                ageInMonths = 0
            };

            poulation.Add(rabbit);

            for (int i = 1; i < monthsOfSimulations; i++)
            {
                List<RabbitPair> children = new List<RabbitPair>();
                List<RabbitPair> dead = new List<RabbitPair>();

                foreach (var rab in poulation) 
                {
                    //Advance age
                    rab.ageInMonths++;

                    //Children?
                    if (rab.ageInMonths > 1) 
                    {
                        children.Add(new RabbitPair
                        {
                            ageInMonths = 0
                        });
                    }

                    //Die?
                    if (rab.ageInMonths == rabbitLivesThisManyMonths) 
                    {
                        dead.Add(rab);
                    }
                }

                foreach (var pair in dead) 
                {
                    poulation.Remove(pair);
                }

                foreach (var pair in children) 
                {
                    poulation.Add(pair);
                }
            }
            return poulation.Count;
        }

        private class RabbitPair 
        {
            public int ageInMonths;
        }


        public ulong simulateRabbitsOptimized(int monthsOfSimulation, int rabbitLivesThisManyMonths) 
        {
            var population = new ulong[rabbitLivesThisManyMonths];
            population[0] = 1; //Initial

            for (int simMonth = 0; simMonth < (monthsOfSimulation-1); simMonth++) 
            {
                ulong childrenCount = 0;

                //Do each of the generations
                ulong tmpStoreBetweenGenerations = 0;
                for (int generation = 0; generation < population.Length; generation++) 
                {
                    if (generation == 0)
                    {
                        tmpStoreBetweenGenerations = population[generation];
                    } else 
                    {
                        ulong prevGen = tmpStoreBetweenGenerations;
                        childrenCount += population[generation]; //Each pair is of childbearing age
                        tmpStoreBetweenGenerations = population[generation];
                        population[generation] = prevGen; //They age a month
                    }
                }
                population[0] = childrenCount;
            }

            ulong finalCount = 0;
            for (var index = 0; index < population.Length; index++) 
            {
                finalCount += population[index];
            }
            return finalCount;
        }

        public BigInteger simulateRabbitsOptimizedBigNum(int monthsOfSimulation, int rabbitLivesThisManyMonths)
        {
            var population = new BigInteger[rabbitLivesThisManyMonths];
            population[0] = 1;//Initial

            for (int simMonth = 0; simMonth < (monthsOfSimulation - 1); simMonth++)
            {
                BigInteger childrenCount = 0;

                //Do each of the generations
                BigInteger tmpStoreBetweenGenerations = 0;
                for (int generation = 0; generation < population.Length; generation++)
                {
                    if (generation == 0)
                    {
                        tmpStoreBetweenGenerations = population[generation];
                    }
                    else
                    {
                        BigInteger prevGen = tmpStoreBetweenGenerations;
                        childrenCount += population[generation]; //Each pair is of childbearing age
                        tmpStoreBetweenGenerations = population[generation];
                        population[generation] = prevGen; //They age a month
                    }
                }
                population[0] = childrenCount;
            }

            BigInteger finalCount = 0;
            for (var index = 0; index < population.Length; index++)
            {
                finalCount += population[index];
            }
            return finalCount;
        }
    }
}
