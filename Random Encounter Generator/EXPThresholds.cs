using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Encounter_Generator
{
    public static class EXPThresholds
    {
        
        private static readonly Dictionary<int, Dictionary<string, int>> thresholds = new Dictionary<int, Dictionary<string, int>>
        {
            {1, new Dictionary<string, int> {{"Easy", 25*3}, { "Medium", 50 * 3 }, {"Hard", 75 * 3 }, {"Deadly", 100 * 3 } } },
            {2, new Dictionary<string, int> {{"Easy", 50*3}, { "Medium", 100 * 3 }, {"Hard", 150 * 3 }, {"Deadly", 200 * 3 } } },
            {3, new Dictionary<string, int> {{"Easy", 75 * 3 }, { "Medium", 150 * 3 }, {"Hard", 225 * 3 }, {"Deadly", 400 * 3 } } },
            {4, new Dictionary<string, int> {{"Easy", 125 * 3 }, { "Medium", 250 * 3 }, {"Hard", 375 * 3 }, {"Deadly", 500 * 3 } } },
            {5, new Dictionary<string, int> {{"Easy", 250 * 3 }, { "Medium", 500 * 3 }, {"Hard", 750 * 3 }, {"Deadly", 1100 * 3 } } },
            {6, new Dictionary<string, int> {{"Easy", 300 * 3 }, { "Medium", 600 * 3 }, {"Hard", 900 * 3 }, {"Deadly", 1400 * 3 } } },
            {7, new Dictionary<string, int> {{"Easy", 350 * 3 }, { "Medium", 750 * 3 }, {"Hard", 1100 * 3 }, {"Deadly", 1700 * 3 } } },
            {8, new Dictionary<string, int> {{"Easy", 450 * 3 }, { "Medium", 900 * 3 }, {"Hard", 1400 * 3 }, {"Deadly", 2100 * 3 } } },
            {9, new Dictionary<string, int> {{"Easy", 550 * 3 }, { "Medium", 1100 * 3 }, {"Hard", 1600 * 3 }, {"Deadly", 2400 * 3 } } },
            {10, new Dictionary<string, int> {{"Easy", 600 * 3 }, { "Medium", 1200 * 3 }, {"Hard", 1900 * 3 }, {"Deadly", 2800 * 3 } } },
            {11, new Dictionary<string, int> {{"Easy", 800 * 3 }, { "Medium", 1600 * 3 }, {"Hard", 2400 * 3 }, {"Deadly", 3600 * 3 } } },
            {12, new Dictionary<string, int> {{"Easy", 1000 * 3 }, { "Medium", 2000 * 3 }, {"Hard", 3000 * 3 }, {"Deadly", 4500 * 3 } } },
            {13, new Dictionary<string, int> {{"Easy", 1100 * 3 }, { "Medium", 2200 * 3 }, {"Hard", 3400 * 3 }, {"Deadly", 5100 * 3 } } },
            {14, new Dictionary<string, int> {{"Easy", 1250 * 3 }, { "Medium", 2500 * 3 }, {"Hard", 3800 * 3 }, {"Deadly", 5700 * 3 } } },
            {15, new Dictionary<string, int> {{ "Easy", 1400 * 4 }, { "Medium", 2800 * 4 }, { "Hard", 4300 * 4 }, {"Deadly", 6400 * 4 } } },
            {16, new Dictionary<string, int> {{ "Easy", 1600 * 5 }, { "Medium", 3200 * 5 }, {"Hard", 4800 * 5 }, {"Deadly", 7200 * 5 } } },
            {17, new Dictionary<string, int> {{"Easy", 2000 * 6 }, { "Medium", 3900 * 6 }, {"Hard", 5900 * 6 }, {"Deadly", 8800 * 6 } } },
            {18, new Dictionary<string, int> {{"Easy", 2100 * 8 }, { "Medium", 4200 * 8 }, {"Hard", 6300 * 8 }, {"Deadly", 9500 * 8 } } },
            {19, new Dictionary<string, int> {{"Easy", 2400 * 10 }, { "Medium", 4900 * 10 }, {"Hard", 7300 * 10 }, {"Deadly", 10900 * 10 } } },
            {20, new Dictionary<string, int> {{"Easy", 2800 * 13 }, { "Medium", 5700 * 13 }, {"Hard", 8500 * 13 }, {"Deadly", 12700 * 13 } } }
        };

        public static int getThreshold(int level, string difficulty)
        {
            if(thresholds.ContainsKey(level) && thresholds[level].ContainsKey(difficulty)){
                return thresholds[level][difficulty];
            }
            throw new ArgumentException("Invalid level or difficulty");
        }

        public static readonly Dictionary<int, double> minCR = new Dictionary<int, double>
        {
            {1, 0.125}, {2, 0.25}, {3, 0.5}, {4, 1}, {5, 2 }, {6, 2}, {7, 2}, {8, 2 }, {9, 3}, {10, 3 },
            {11, 4 }, {12, 5}, {13, 6}, {14, 7 }, {15, 8 }, {16, 9 }, {17,10 }, {18, 11 }, {19, 12 }, {20, 13 }
        };

        public static readonly Dictionary<string, double> easyRarityWeights = new Dictionary<string, double>
        {
            {"Common", 65 },
            {"Uncommon", 15},
            {"Rare", 10},
            {"Ultra Rare", 9},
            {"Legendary", 1 }
        };

        public static readonly Dictionary<string, double> normalRarityWeights = new Dictionary<string, double>
        {
            {"Common", 22 },
            {"Uncommon", 40},
            {"Rare", 26},
            {"Ultra Rare", 10},
            {"Legendary", 2 }
        };

        public static readonly Dictionary<string, double> hardRarityWeights = new Dictionary<string, double>
        {
            {"Common", 15 },
            {"Uncommon", 26},
            {"Rare", 40},
            {"Ultra Rare", 16},
            {"Legendary", 3 }
        };

        public static readonly Dictionary<string, double> deadlyRarityWeights = new Dictionary<string, double>
        {
            {"Common", 5 },
            {"Uncommon", 10},
            {"Rare", 45},
            {"Ultra Rare", 35},
            {"Legendary", 5 }
        };
    }
}
