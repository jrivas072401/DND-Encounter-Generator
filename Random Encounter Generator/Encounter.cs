using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Encounter_Generator
{
    public partial class Encounter : Form
    {
        // global variables & DS for the form
        public int totalEXP = 0;
        public int EXPLimit = 0;
        public List<Monster> filteredMonsters = null;
        public List<Monster> filteredObjects = null;
        public double minCR = 0;
        public string currentDifficulty = null;
        public event EventHandler EncounterEnded;
        public int totalGold = 0;
        
        
        public Encounter()
        {
            InitializeComponent();
            currentWave.Text = Convert.ToString(Start.waves);
            getComboBoxData();
            // update day, change after 3 waves
            Start.dayCounter++;
            if(Start.dayCounter == 3)
            {
                Start.dayCounter = 0;
                if(this.BackColor == Color.RoyalBlue)
                    this.BackColor = Color.SkyBlue;
                else
                    this.BackColor = Color.RoyalBlue;
            }
        }

        private void GenEnctButton(object sender, EventArgs e)
        {
            EncounterTable.DataSource = GenerateEncounter(filteredMonsters);
            EncounterTable.Columns["link"].Visible = false;
        }

        /// <summary>
        /// Generate encounter using filtered list of monsters
        /// </summary>
        /// <param name="monsters"></param>
        /// <returns></returns>
        private List<Monster> GenerateEncounter(List<Monster> monsters)
        {
            // create new list
            List<Monster> encounter = new List<Monster>();

            // initialize RNG
            var random = new Random();

            // sort based on total EXP in descending order
            // helps prioritize higher EXP monsters
            List<Monster> sorted = monsters.OrderByDescending(m => m.exp).ToList();

            int loops = 0;
            // add to encounter list while exp total is below the limit
            while(totalEXP < EXPLimit * 0.88)
            {
                // get random monster
                Monster monster = monsters[random.Next(monsters.Count)];

                //check if monster is valid for exp limit, if so add, else continue
                if(totalEXP + monster.exp <= EXPLimit  && monster.CR >= minCR)
                {
                    encounter.Add(monster);
                    totalEXP += monster.exp;
                    totalGold += monster.gold;
                }
                else
                {
                    // break once within threshold
                    if(totalEXP >= EXPLimit * 0.94 || totalEXP + minCR > EXPLimit)
                    {
                        break;
                    }
                    if((totalEXP == 50 && currentDifficulty == "Easy" && Start.waves == 1) && (totalEXP == 100 && currentDifficulty == "Medium" && Start.waves == 1))
                    {
                        break;
                    }
                    // break if impossible to enter threshold
                    if(loops >= 15)
                        break;
                }
                loops++;
            }

            int numOfObjects = random.Next(5, 15);
            bool vehicle = false;
            bool unique = false;
            int i = 0;
            int counter = 0;
            while(i < numOfObjects)
            {
                if (filteredObjects.Count == 0)
                {
                    break;
                }

                Monster obj = filteredObjects[random.Next(filteredObjects.Count)];

                if (obj.Name.Contains("Vehicle") && vehicle == false)
                {
                    i += 3;
                    vehicle = true;
                    encounter.Add(obj);
                    filteredObjects.Remove(obj);
                }

                else if (obj.Name.Contains("Unique") && unique == false)
                {
                    i += 5;
                    unique = true;
                    encounter.Add(obj);
                }
                else if (!obj.Name.Contains("Unique") && !obj.Name.Contains("Vehicle"))  {
                    i++;
                    encounter.Add(obj);
                    filteredObjects.Remove(obj);
                }

                counter++;
                if (counter == 20)
                    break;
            }

            // update labels
            expLabel.Text = totalEXP.ToString();
            goldLabel.Text = totalGold.ToString();

            return encounter;
        }

        /// <summary>
        /// filter list based on biome, sort by CR
        /// </summary>
        /// <param name="monsters"></param>
        /// <returns></returns>
        private List<Monster> filter(List<Monster> monsters)
        {
            List<Monster> filtered = new List<Monster>();
            string biome = BiomeBox.SelectedItem.ToString();
            filtered = monsters.Where(m => m.biomes.Contains(biome)).ToList();
            //filteredObject = 
            // CR & EXP essentially the same order so this could be removed but it isnt slowing down much so whatever
            filtered.Sort((x, y) => x.CR.CompareTo(y.CR));
            return filtered;
        }

        /// <summary>
        /// choose 3 random biomes & add to combo box
        /// </summary>
        private void getComboBoxData()
        {
            // clear combobox
            BiomeBox.Items.Clear();

            // initialize RNG
            Random random = new Random();

            // new list for biomes copied from overall biomes list
            List<string> biomes = new List<string>(Start.Biomes);

            // shuffle biomes list
            for (int i = biomes.Count - 1; i > 0; i--){
                int j = random.Next(i + 1);
                var temp = biomes[i];
                biomes[i] = biomes[j];
                biomes[j] = temp;
            }

            // choose 3 random biomes, sometimes chooses only 2 need to fix
            for(int i = 0; i <= 3; i++)
            {
                if (!string.IsNullOrEmpty(biomes[i]))
                {
                    BiomeBox.Items.Add(biomes[i]);
                }
            }
        }

        /// <summary>
        /// when button is clicked, ends encounter and triggers event on main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void end_Button(object sender, EventArgs e)
        {
            totalEXP = 0;
            Start.currentDifficulty = currentDifficulty;
            EncounterEnded?.Invoke(this, EventArgs.Empty);
            Bonus_Screen bonus_Screen = new Bonus_Screen();
            bonus_Screen.Show();
            bonus_Screen.BringToFront();
            Close();
        }

        /// <summary>
        /// triggers filter to choose monsters within newly selected biome
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBiome(object sender, EventArgs e)
        {

            filteredMonsters = filter(Start.monsters);
            filteredObjects = filter(Start.objects);
        }

        /// <summary>
        /// updates difficulty by accessing dictionary with all difficulty-CR/EXP values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDifficulty(object sender, EventArgs e)
        {
            try
            {
                //sets EXP limit
                EXPLimit = EXPThresholds.getThreshold(Start.waves, DifficultyBox.SelectedItem.ToString());
                // updates current difficulty for use in generation
                currentDifficulty = DifficultyBox.SelectedItem.ToString();

                // increases limit if deadly
                if (currentDifficulty == "Deadly")
                    EXPLimit = Convert.ToInt32(EXPLimit * 1.50);

                // updates label
                MaxEXP.Text = EXPLimit.ToString();

                //sets min CR to ignore weaker monsters to prevent large enemy counts
                minCR = EXPThresholds.minCR[Start.waves];
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
