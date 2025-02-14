using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Encounter_Generator
{
    public partial class Start : Form
    {
        // global variables & DS
        public static List<Monster> monsters = new List<Monster>();
        public static int waves = 1;
        public static List<string> Biomes = new List<string>();
        public static int dayCounter = 0;
        public static List<Reward> rewards = new List<Reward>();
        public static string currentDifficulty = "Easy";
        public static string bonus = string.Empty;
        public static List<Monster> objects = new List<Monster>();

        public Start()
        {
            InitializeComponent();
            //monsters = new List<Monster>();
            monsters = GetMonsters();
            rewards = GetRewards();
            objects = GetObjects();
            label2.Text = waves.ToString();
            Random rand = new Random();
            dayCounter = rand.Next(0, 2);

        }


        /// <summary>
        /// begins new encounter & opens new form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encounter_Button(object sender, EventArgs e)
        {
            Encounter encounter = new Encounter();
            encounter.EncounterEnded += Encounter_EncounterEnded;
            encounter.Show();
            encounter.BringToFront();
        }

        /// <summary>
        /// increases waves when encounter is ended correctly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encounter_EncounterEnded(object sender, EventArgs e)
        {
            waves++;
            label2.Text = waves.ToString();

        }

        private void Rewards_Ended(object sender, EventArgs e)
        {
            // currently wont update
            currentBonus.Text = "Current Bonus: " + bonus;
        }

        /// <summary>
        /// gets monsters from csv file
        /// </summary>
        /// <returns></returns>
        private List<Monster> GetMonsters()
        {
            const string referenceString = "Name,CR,EXP,Biome1,Biome2,Biome3,Link";
            // replace with folder name w/ documents
            string filename = "";
            Biomes.Clear();
            List<Monster> temp = new List<Monster>();
            using (StreamReader sr = new StreamReader(filename))
            {
                
                string line = sr.ReadLine();
                //Console.WriteLine("Header" + line);
                if(line == referenceString)
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine("Reading" + line);
                        Monster monster = new Monster(line);

                        temp.Add(monster);
                        foreach(var biome in monster.biomes)
                        {
                            if (!Biomes.Contains(biome))
                            {
                                Biomes.Add(biome);
                            }
                        }
                    }
                }
            }

            temp.Sort((x, y) => x.CR.CompareTo(y.CR));
            return temp;
        }

        /// <summary>
        /// buttons for increases & decreasing wave count manually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncreaseWaves(object sender, EventArgs e)
        {
            waves++;
            label2.Text = waves.ToString();
        }

        private void DecreaseWaveButton(object sender, EventArgs e)
        {
            waves--;
            label2.Text = waves.ToString();
        }
        private List<Reward> GetRewards()
        {
            List<Reward> temp = new List<Reward>();
            const string referenceString = "Name,Description,Rarity";
            // file path
            string filename = "";
            using (StreamReader sr = new StreamReader(filename))
            {

                string line = sr.ReadLine();
                //Console.WriteLine("Header" + line);
                if (line == referenceString)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine("Reading" + line);
                        Reward reward = new Reward(line);
                        temp.Add(reward);
                    }
                }
                return temp;
            }
        }
        private List<Monster> GetObjects()
        {
            List<Monster> temp = new List<Monster>();
            const string referenceString = "Name,CR,EXP,Biome1,Biome2,Biome3,Link";
            // filepath
            string filename = "";
            using (StreamReader sr = new StreamReader(filename))
            {

                string line = sr.ReadLine();
                //Console.WriteLine("Header" + line);
                if (line == referenceString)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine("Reading" + line);
                        Monster obj = new Monster(line);
                        temp.Add(obj);
                    }
                }
                return temp;
            }
        }
    }
}
