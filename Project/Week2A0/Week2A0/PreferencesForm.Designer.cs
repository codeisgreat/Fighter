namespace Week2A0
{
    partial class PreferencesForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.okButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.maximumHealthTextBox = new System.Windows.Forms.TextBox();
            this.minimumDexerityTextBox = new System.Windows.Forms.TextBox();
            this.maximumDexerityTextBox = new System.Windows.Forms.TextBox();
            this.maximumArmourValueTextBox = new System.Windows.Forms.TextBox();
            this.criticalHitMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.maximumBaseDamageTextbox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 13);
            label1.TabIndex = 0;
            label1.Text = "Maximum Health";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 53);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 1;
            label2.Text = "Minimum Dexerity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92, 13);
            label3.TabIndex = 5;
            label3.Text = "Maximum Dexerity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 105);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(117, 13);
            label4.TabIndex = 6;
            label4.Text = "Maximum Armour Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 131);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(98, 13);
            label5.TabIndex = 7;
            label5.Text = "Critical Hit Multiplier";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(69, 197);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(150, 197);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(231, 197);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // maximumHealthTextBox
            // 
            this.maximumHealthTextBox.Location = new System.Drawing.Point(196, 24);
            this.maximumHealthTextBox.Name = "maximumHealthTextBox";
            this.maximumHealthTextBox.Size = new System.Drawing.Size(100, 20);
            this.maximumHealthTextBox.TabIndex = 8;
            // 
            // minimumDexerityTextBox
            // 
            this.minimumDexerityTextBox.Location = new System.Drawing.Point(196, 50);
            this.minimumDexerityTextBox.Name = "minimumDexerityTextBox";
            this.minimumDexerityTextBox.Size = new System.Drawing.Size(100, 20);
            this.minimumDexerityTextBox.TabIndex = 9;
            // 
            // maximumDexerityTextBox
            // 
            this.maximumDexerityTextBox.Location = new System.Drawing.Point(196, 76);
            this.maximumDexerityTextBox.Name = "maximumDexerityTextBox";
            this.maximumDexerityTextBox.Size = new System.Drawing.Size(100, 20);
            this.maximumDexerityTextBox.TabIndex = 10;
            // 
            // maximumArmourValueTextBox
            // 
            this.maximumArmourValueTextBox.Location = new System.Drawing.Point(196, 102);
            this.maximumArmourValueTextBox.Name = "maximumArmourValueTextBox";
            this.maximumArmourValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.maximumArmourValueTextBox.TabIndex = 11;
            // 
            // criticalHitMultiplierTextBox
            // 
            this.criticalHitMultiplierTextBox.Location = new System.Drawing.Point(196, 128);
            this.criticalHitMultiplierTextBox.Name = "criticalHitMultiplierTextBox";
            this.criticalHitMultiplierTextBox.Size = new System.Drawing.Size(100, 20);
            this.criticalHitMultiplierTextBox.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 157);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(121, 13);
            label6.TabIndex = 13;
            label6.Text = "Maximum Base Damage";
            // 
            // maximumBaseDamageTextbox
            // 
            this.maximumBaseDamageTextbox.Location = new System.Drawing.Point(196, 154);
            this.maximumBaseDamageTextbox.Name = "maximumBaseDamageTextbox";
            this.maximumBaseDamageTextbox.Size = new System.Drawing.Size(100, 20);
            this.maximumBaseDamageTextbox.TabIndex = 14;
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(318, 232);
            this.Controls.Add(this.maximumBaseDamageTextbox);
            this.Controls.Add(label6);
            this.Controls.Add(this.criticalHitMultiplierTextBox);
            this.Controls.Add(this.maximumArmourValueTextBox);
            this.Controls.Add(this.maximumDexerityTextBox);
            this.Controls.Add(this.minimumDexerityTextBox);
            this.Controls.Add(this.maximumHealthTextBox);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox maximumHealthTextBox;
        private System.Windows.Forms.TextBox minimumDexerityTextBox;
        private System.Windows.Forms.TextBox maximumDexerityTextBox;
        private System.Windows.Forms.TextBox maximumArmourValueTextBox;
        private System.Windows.Forms.TextBox criticalHitMultiplierTextBox;
        private System.Windows.Forms.TextBox maximumBaseDamageTextbox;
    }
}