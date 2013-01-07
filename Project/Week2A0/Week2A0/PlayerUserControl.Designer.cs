namespace Week2A0
{
    partial class PlayerUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label healthTextLabel;
            System.Windows.Forms.Label dexerityLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.healthAmountLabel = new System.Windows.Forms.Label();
            this.dexerityAmountLabel = new System.Windows.Forms.Label();
            this.healthProgressBar = new System.Windows.Forms.ProgressBar();
            this.playerDamageTaken = new System.Windows.Forms.Label();
            this.armourAmountLabel = new System.Windows.Forms.Label();
            this.baseDamageLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            healthTextLabel = new System.Windows.Forms.Label();
            dexerityLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(18, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(35, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // healthTextLabel
            // 
            healthTextLabel.AutoSize = true;
            healthTextLabel.Location = new System.Drawing.Point(21, 106);
            healthTextLabel.Name = "healthTextLabel";
            healthTextLabel.Size = new System.Drawing.Size(38, 13);
            healthTextLabel.TabIndex = 1;
            healthTextLabel.Text = "Health";
            // 
            // dexerityLabel
            // 
            dexerityLabel.AutoSize = true;
            dexerityLabel.Location = new System.Drawing.Point(21, 192);
            dexerityLabel.Name = "dexerityLabel";
            dexerityLabel.Size = new System.Drawing.Size(45, 13);
            dexerityLabel.TabIndex = 2;
            dexerityLabel.Text = "Dexerity";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 238);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 13);
            label1.TabIndex = 8;
            label1.Text = "Armour Amount";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(21, 39);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // healthAmountLabel
            // 
            this.healthAmountLabel.AutoSize = true;
            this.healthAmountLabel.Location = new System.Drawing.Point(87, 106);
            this.healthAmountLabel.Name = "healthAmountLabel";
            this.healthAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.healthAmountLabel.TabIndex = 4;
            this.healthAmountLabel.Text = "0";
            this.healthAmountLabel.TextChanged += new System.EventHandler(this.healthAmountLabel_TextChanged);
            // 
            // dexerityAmountLabel
            // 
            this.dexerityAmountLabel.AutoSize = true;
            this.dexerityAmountLabel.Location = new System.Drawing.Point(87, 192);
            this.dexerityAmountLabel.Name = "dexerityAmountLabel";
            this.dexerityAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.dexerityAmountLabel.TabIndex = 5;
            this.dexerityAmountLabel.Text = "0";
            // 
            // healthProgressBar
            // 
            this.healthProgressBar.Location = new System.Drawing.Point(24, 137);
            this.healthProgressBar.Name = "healthProgressBar";
            this.healthProgressBar.Size = new System.Drawing.Size(203, 23);
            this.healthProgressBar.TabIndex = 6;
            // 
            // playerDamageTaken
            // 
            this.playerDamageTaken.AutoSize = true;
            this.playerDamageTaken.Location = new System.Drawing.Point(191, 105);
            this.playerDamageTaken.Name = "playerDamageTaken";
            this.playerDamageTaken.Size = new System.Drawing.Size(0, 13);
            this.playerDamageTaken.TabIndex = 7;
            // 
            // armourAmountLabel
            // 
            this.armourAmountLabel.AutoSize = true;
            this.armourAmountLabel.Location = new System.Drawing.Point(106, 238);
            this.armourAmountLabel.Name = "armourAmountLabel";
            this.armourAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.armourAmountLabel.TabIndex = 9;
            this.armourAmountLabel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 272);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 13);
            label2.TabIndex = 10;
            label2.Text = "Base Damage";
            // 
            // baseDamageLabel
            // 
            this.baseDamageLabel.AutoSize = true;
            this.baseDamageLabel.Location = new System.Drawing.Point(106, 272);
            this.baseDamageLabel.Name = "baseDamageLabel";
            this.baseDamageLabel.Size = new System.Drawing.Size(13, 13);
            this.baseDamageLabel.TabIndex = 11;
            this.baseDamageLabel.Text = "0";
            // 
            // PlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseDamageLabel);
            this.Controls.Add(label2);
            this.Controls.Add(this.armourAmountLabel);
            this.Controls.Add(label1);
            this.Controls.Add(this.playerDamageTaken);
            this.Controls.Add(this.healthProgressBar);
            this.Controls.Add(this.dexerityAmountLabel);
            this.Controls.Add(this.healthAmountLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(dexerityLabel);
            this.Controls.Add(healthTextLabel);
            this.Controls.Add(nameLabel);
            this.Name = "PlayerUserControl";
            this.Size = new System.Drawing.Size(248, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label healthAmountLabel;
        private System.Windows.Forms.Label dexerityAmountLabel;
        private System.Windows.Forms.ProgressBar healthProgressBar;
        private System.Windows.Forms.Label playerDamageTaken;
        private System.Windows.Forms.Label armourAmountLabel;
        private System.Windows.Forms.Label baseDamageLabel;

    }
}
