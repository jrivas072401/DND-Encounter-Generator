namespace Random_Encounter_Generator
{
    partial class Encounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Generate_Encounter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BiomeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EncounterTable = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.currentWave = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.Button();
            this.DifficultyBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.expLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxEXP = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.goldLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EncounterTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate_Encounter
            // 
            this.Generate_Encounter.Location = new System.Drawing.Point(240, 95);
            this.Generate_Encounter.Name = "Generate_Encounter";
            this.Generate_Encounter.Size = new System.Drawing.Size(316, 62);
            this.Generate_Encounter.TabIndex = 0;
            this.Generate_Encounter.Text = "Generate Encounter";
            this.Generate_Encounter.UseVisualStyleBackColor = true;
            this.Generate_Encounter.Click += new System.EventHandler(this.GenEnctButton);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 2;
            // 
            // BiomeBox
            // 
            this.BiomeBox.FormattingEnabled = true;
            this.BiomeBox.Location = new System.Drawing.Point(67, 95);
            this.BiomeBox.Name = "BiomeBox";
            this.BiomeBox.Size = new System.Drawing.Size(116, 24);
            this.BiomeBox.TabIndex = 5;
            this.BiomeBox.SelectedIndexChanged += new System.EventHandler(this.updateBiome);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select Biome";
            // 
            // EncounterTable
            // 
            this.EncounterTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EncounterTable.Location = new System.Drawing.Point(-2, 225);
            this.EncounterTable.Name = "EncounterTable";
            this.EncounterTable.RowHeadersWidth = 51;
            this.EncounterTable.RowTemplate.Height = 24;
            this.EncounterTable.Size = new System.Drawing.Size(804, 450);
            this.EncounterTable.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wave:";
            // 
            // currentWave
            // 
            this.currentWave.AutoSize = true;
            this.currentWave.Location = new System.Drawing.Point(289, 9);
            this.currentWave.Name = "currentWave";
            this.currentWave.Size = new System.Drawing.Size(14, 16);
            this.currentWave.TabIndex = 8;
            this.currentWave.Text = "0";
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(303, 163);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(197, 32);
            this.end.TabIndex = 9;
            this.end.Text = "End Encounter";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Button);
            // 
            // DifficultyBox
            // 
            this.DifficultyBox.FormattingEnabled = true;
            this.DifficultyBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard",
            "Deadly"});
            this.DifficultyBox.Location = new System.Drawing.Point(610, 95);
            this.DifficultyBox.Name = "DifficultyBox";
            this.DifficultyBox.Size = new System.Drawing.Size(121, 24);
            this.DifficultyBox.TabIndex = 10;
            this.DifficultyBox.SelectedIndexChanged += new System.EventHandler(this.UpdateDifficulty);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Difficulty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total EXP";
            // 
            // expLabel
            // 
            this.expLabel.AutoSize = true;
            this.expLabel.Location = new System.Drawing.Point(542, 12);
            this.expLabel.Name = "expLabel";
            this.expLabel.Size = new System.Drawing.Size(14, 16);
            this.expLabel.TabIndex = 13;
            this.expLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(636, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Max EXP";
            // 
            // MaxEXP
            // 
            this.MaxEXP.AutoSize = true;
            this.MaxEXP.Location = new System.Drawing.Point(711, 9);
            this.MaxEXP.Name = "MaxEXP";
            this.MaxEXP.Size = new System.Drawing.Size(14, 16);
            this.MaxEXP.TabIndex = 15;
            this.MaxEXP.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Gold:";
            // 
            // goldLabel
            // 
            this.goldLabel.AutoSize = true;
            this.goldLabel.Location = new System.Drawing.Point(151, 9);
            this.goldLabel.Name = "goldLabel";
            this.goldLabel.Size = new System.Drawing.Size(14, 16);
            this.goldLabel.TabIndex = 17;
            this.goldLabel.Text = "0";
            // 
            // Encounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 674);
            this.Controls.Add(this.goldLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MaxEXP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.expLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DifficultyBox);
            this.Controls.Add(this.end);
            this.Controls.Add(this.currentWave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EncounterTable);
            this.Controls.Add(this.BiomeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Generate_Encounter);
            this.Name = "Encounter";
            this.Text = "Encounter";
            ((System.ComponentModel.ISupportInitialize)(this.EncounterTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate_Encounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BiomeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView EncounterTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentWave;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.ComboBox DifficultyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label expLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label MaxEXP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label goldLabel;
    }
}