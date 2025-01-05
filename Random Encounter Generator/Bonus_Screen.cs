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
    public partial class Bonus_Screen : Form
    {
        public  List<Reward> selectedRewards = new List<Reward>();
        public AliasMethod lootTable = null;
        public event EventHandler bonusEnded;
        public Bonus_Screen()
        {
            InitializeComponent();
            GenerateWeights();
            getRewards();
        }

        private void GenerateWeights()
        {
            List<double> weights = new List<double>();
            for (int i = 0; i < Start.rewards.Count; i++)
            {
                switch (Start.currentDifficulty)
                {
                    case "Easy":
                        weights.Add(EXPThresholds.easyRarityWeights[Start.rewards[i].rarity]);
                        break;
                    case "Medium":
                        weights.Add(EXPThresholds.normalRarityWeights[Start.rewards[i].rarity]);
                        break;
                    case "Hard":
                        weights.Add(EXPThresholds.hardRarityWeights[Start.rewards[i].rarity]);
                        break;
                    default:
                        weights.Add(EXPThresholds.deadlyRarityWeights[Start.rewards[i].rarity]);
                        break;
                }
            }
            lootTable = new AliasMethod(weights);
        }

        public void getRewards()
        {
            int i = 0;
            while(i < 3)
            {
                int index = lootTable.Next();
                var reward = Start.rewards[index];
                if (!selectedRewards.Any(r => r.name == reward.name))
                {
                    selectedRewards.Add(Start.rewards[index]);
                    i++;
                }
            }

            Color color = Color.White;
            Desc1.MaximumSize = new Size(100, 0);
            string rarity = selectedRewards[0].rarity.ToString();
            Name1.Text = selectedRewards[0].name.ToString();
            Desc1.Text = selectedRewards[0].description.ToString();
            Rarity1.Text = rarity;
            switch (rarity)
            {
                case "Common":
                    color = Color.White;
                    break;
                case "Uncommon":
                    color = Color.Aqua;
                    break;
                case "Rare":
                    color = Color.Blue;
                    break;
                case "Ultra Rare":
                    color = Color.BlueViolet;
                    break;
                default:
                    color = Color.Gold;
                    break;
            }

            groupBox1.BackColor = color;

            Desc2.MaximumSize = new Size(100, 0);
            rarity = selectedRewards[1].rarity.ToString();
            Name2.Text = selectedRewards[1].name.ToString();
            Desc2.Text = selectedRewards[1].description.ToString();
            Rarity2.Text = rarity;
            switch (rarity)
            {
                case "Common":
                    color = Color.White;
                    break;
                case "Uncommon":
                    color = Color.Aqua;
                    break;
                case "Rare":
                    color = Color.Blue;
                    break;
                case "Ultra Rare":
                    color = Color.BlueViolet;
                    break;
                default:
                    color = Color.Gold;
                    break;
            }
            groupBox2.BackColor = color;

            Desc3.MaximumSize = new Size(100, 0);
            rarity = selectedRewards[2].rarity.ToString();
            Name3.Text = selectedRewards[2].name.ToString();
            Desc3.Text = selectedRewards[2].description.ToString();
            Rarity3.Text = rarity;
            switch (rarity)
            {
                case "Common":
                    color = Color.White;
                    break;
                case "Uncommon":
                    color = Color.Aqua;
                    break;
                case "Rare":
                    color = Color.Blue;
                    break;
                case "Ultra Rare":
                    color = Color.BlueViolet;
                    break;
                default:
                    color = Color.Gold;
                    break;
            }
            groupBox3.BackColor = color;
        }

        private void ItemButton1_Click(object sender, EventArgs e)
        {
            Start.bonus = Name1.Text;
            Close();
        }

        private void ItemButton2_Click(object sender, EventArgs e)
        {
            Start.bonus =  Name2.Text;
            Close();
        }

        private void ItemButton3_Click(object sender, EventArgs e)
        {
            Start.bonus =  Name3.Text;
            Close();
        }

    }
}
