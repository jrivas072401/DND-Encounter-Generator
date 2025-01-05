using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Encounter_Generator
{
    public class AliasTable
    {

        public int[] Alias {  get; set; }
        public double[] Probability { get; set; }

        public AliasTable(int size)
        {
            Alias = new int[size];
            Probability = new double[size];
        } 

    }
}
