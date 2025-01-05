using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Encounter_Generator
{
    public class Reward
    {
        public string name {  get; set; }
        public string description { get; set; }

        public string rarity { get; set; }

        public Reward(string data)
        {
            char[] separators = new char[] { ',' };
            string[] subs = data.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            name = subs[0];

            description = subs[1];

            rarity = subs[2];
        }
    }
}
