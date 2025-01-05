using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Encounter_Generator
{
    public class AliasMethod
    {

        // https://www.keithschwarz.com/darts-dice-coins/


        private AliasTable LootTable;
        private Random random;

        
        public AliasMethod(List<double> weights)
        {
            double[] probabilities = ConvertWeightToProbability(weights);
            int size = probabilities.Length;
            LootTable = new AliasTable(size);
            random = new Random();
            Initialize(probabilities);
            
        }

        private double[] ConvertWeightToProbability(List<double> weights)
        {
            double total = weights.Sum();
            double[] probabilities = weights.Select(weight => weight / total).ToArray();
            return probabilities;
        }

        private void Initialize(double[] probabilities)
        {
            int size = probabilities.Length;
            double[] scaledProbabilities = new double[size];
            int[] small = new int[size];
            int[] large = new int[size];
            int smallIndex = 0;
            int largeIndex = 0;

            // scale probabilities by size
            for(int i = 0; i < size; i++)
            {
                scaledProbabilities[i] = probabilities[i] * size;
            }

            // split into large & small lists
            for(int i = 0; i < size; i++)
            {
                if (scaledProbabilities[i] < 1.0)
                {
                    small[smallIndex++] = i;
                }
                else
                {
                    large[largeIndex++] = i;
                }
            }

            // construct table
            while(smallIndex > 0 && largeIndex > 0)
            {
                int less = small[--smallIndex];
                int more = large[--largeIndex];

                LootTable.Probability[less] = scaledProbabilities[less];
                LootTable.Alias[less] = more;

                scaledProbabilities[more] = scaledProbabilities[more] + scaledProbabilities[less] - 1.0;

                if (scaledProbabilities[more] < 1.0)
                {
                    small[smallIndex++] = more;
                }
                else
                {
                    large[largeIndex++] = more;
                }
            }

            // fill remaining
            while(smallIndex > 0)
            {
                LootTable.Probability[small[--smallIndex]] = 1.0;
            }

            while(largeIndex > 0)
            {
                LootTable.Probability[large[--largeIndex]] = 1.0;
            }
        }

        public int Next()
        {
            int column = random.Next(LootTable.Probability.Length);
            bool coinFlip = random.NextDouble() < LootTable.Probability[column];

            return coinFlip ? column : LootTable.Alias[column];
        }
    }
}
