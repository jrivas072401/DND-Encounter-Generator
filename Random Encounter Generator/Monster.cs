using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Encounter_Generator
{
    public class Monster
    {
        public string Name { get; set; }

        public double CR {  get; set; }

        public string[] biomes { get; set; }

        public int exp {  get; set; }

        public string link { get; set; }

        public int gold { get; set; }
        public Monster(string data)
        {
            char[] separators = new char[] { ',' };
            string[] subs = data.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Name = subs[0];
            double temp;
            bool success = double.TryParse(subs[1], out temp);
            if (success) CR = temp;

            int temp2;
            success = int.TryParse(subs[2], out temp2);
            if (success ) exp = temp2;

            biomes = new string[3];
            for (int i = 3, j = 0; i < subs.Length-1; i++, j++)
            {
                if (subs[i] == null)
                    break;
                biomes[j] = subs[i];
            }

            link = subs[subs.Length-1];

            gold = Convert.ToInt32(CR * 50);
        }

        

    }
}
