using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week2A0
{
    public partial class PreferencesForm : Form
    {
        private FightClubSimulatorGame game = null;


        public PreferencesForm(FightClubSimulatorGame game)
        {
            InitializeComponent();

            Initialize();

            this.game = game;
        }

        public void Initialize()
        {
            maximumHealthTextBox.Text = FightClubPlayer.MaximumHealth.ToString();
            minimumDexerityTextBox.Text = FightClubPlayer.MinimumDexerityValue.ToString();
            maximumDexerityTextBox.Text = FightClubPlayer.MaximumDexerityValue.ToString();
            maximumArmourValueTextBox.Text = FightClubPlayer.MaximumArmourValue.ToString();
            criticalHitMultiplierTextBox.Text = FightClubPlayer.CriticalHitMultiplier.ToString();
            maximumBaseDamageTextbox.Text = FightClubPlayer.MaximumBaseDamage.ToString();
        }


        /// <summary>
        /// Applies the changes for the form.
        /// </summary>
        public void ApplyChanges()
        {
            int maximumHealth = 0;
            int mininmumDexerity = 0;
            int maximumDexerity = 0;
            int maximumArmourValue = 0;
            int criticalHitMultiplier = 0;
            int maximumBaseDamage = 0;

            try
            {
                maximumHealth = Convert.ToInt32(maximumHealthTextBox.Text);
                mininmumDexerity = Convert.ToInt32(minimumDexerityTextBox.Text);
                maximumDexerity = Convert.ToInt32(maximumDexerityTextBox.Text);
                maximumArmourValue = Convert.ToInt32(maximumArmourValueTextBox.Text);
                criticalHitMultiplier = Convert.ToInt32(criticalHitMultiplierTextBox.Text);
                maximumBaseDamage = Convert.ToInt32(maximumBaseDamageTextbox.Text);
            }
            catch (System.FormatException)
            {
                const string errorMessage = "Enter a valid number in the textboxes.";

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Assign the variables
            FightClubPlayer.MaximumHealth           = maximumHealth;
            FightClubPlayer.MinimumDexerityValue    = mininmumDexerity;
            FightClubPlayer.MaximumDexerityValue    = maximumDexerity;
            FightClubPlayer.MaximumArmourValue      = maximumArmourValue;
            FightClubPlayer.CriticalHitMultiplier   = criticalHitMultiplier;
            FightClubPlayer.MaximumBaseDamage       = maximumBaseDamage;

            if (game != null)
            {
                game.Start();
            }
        }


        /// <summary>
        /// Cancels changes.
        /// </summary>
        public void CancelChanges()
        {
            Close();
        }



        private void okButton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            CancelChanges();
        }


        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
    }
}
