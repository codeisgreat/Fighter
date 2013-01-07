using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week2A0
{
    /// <summary>
    /// A user control that displays information for a FightClubPlayer.
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="playerToDisplayInformationFor">The player you wish display information for in the user control.</param>
        public PlayerUserControl(FightClubPlayer playerToDisplayInformationFor = null)
        {
            InitializeComponent();

            // Set the player to display the information for.
            PlayerToDisplayInformation = playerToDisplayInformation;
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Updates the form.
        /// </summary>
        public new void Update()
        {
            // If we don't have an actual player to change our form, we'll just get out.
            if (PlayerToDisplayInformation == null)
            {
                // Set the UI to the defaults
                nameTextBox.Text = "";
                healthAmountLabel.Text = dexerityAmountLabel.Text = "0" + "/" + FightClubPlayer.MaximumHealth.ToString();
                armourAmountLabel.Text = "0" + "/" + FightClubPlayer.MaximumArmourValue.ToString();
                baseDamageLabel.Text   = "0" + "/" + FightClubPlayer.MaximumBaseDamage.ToString();
            }
            else
            {
                // else we'll update the form
                nameTextBox.Text = PlayerToDisplayInformation.Name;
                healthAmountLabel.Text = PlayerToDisplayInformation.Health.ToString()       + "/" + FightClubPlayer.MaximumHealth.ToString();
                dexerityAmountLabel.Text = PlayerToDisplayInformation.Dexerity.ToString();
                armourAmountLabel.Text = playerToDisplayInformation.ArmourAmount.ToString() + "/" + FightClubPlayer.MaximumArmourValue.ToString();
                baseDamageLabel.Text = playerToDisplayInformation.BaseDamage.ToString()     + "/" + FightClubPlayer.MaximumBaseDamage.ToString();
            }

            base.Update();
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// Resembles the player to display information in the user control.
        /// </summary>
        public FightClubPlayer PlayerToDisplayInformation
        {
            get
            {
                return playerToDisplayInformation;
            }

            set
            {
                // set the player
                playerToDisplayInformation = value;

                if (playerToDisplayInformation != null)
                {
                    playerToDisplayInformation.OnGotHitEvent += onPlayerTookDamage;
                }

                Update(); // and update the form
            }
        }

        #endregion



        #region Events

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PlayerToDisplayInformation == null)
            {
                return;
            }

            // Update the player's name
            playerToDisplayInformation.Name = nameTextBox.Text;
        }


        private void healthAmountLabel_TextChanged(object sender, EventArgs e)
        {
            // Get the value of health left from the player
            int healthLeft = playerToDisplayInformation == null ? 0 : playerToDisplayInformation.Health;
            double percentageOfHealthLeft = ((double)healthLeft / (double)FightClubPlayer.MaximumHealth);
            healthProgressBar.Value = (int)(100 * percentageOfHealthLeft);
        }


        private void onPlayerTookDamage(object sender, FightClubPlayer.PlayerGotHitEventArgs arg)
        {
            // If it's 0 or less than that
            if (arg.AmountOfDamageTaken <= 0)
            {
                // Clear the text
                playerDamageTaken.Text = "";
            }

            Color newColorOfText;

            // if we took more than 10 damage, it's red
            // more than 5 damage, it's orange
            // else it's blue

            if (arg.AmountOfDamageTaken >= 10)
            {
                newColorOfText = Color.Red;
            }
            else if (arg.AmountOfDamageTaken >= 5)
            {
                newColorOfText = Color.Orange;
            }
            else
            {
                newColorOfText = Color.Blue;
            }

            playerDamageTaken.ForeColor = newColorOfText; // set the fore colour of the text
            playerDamageTaken.Text = "-" + arg.AmountOfDamageTaken.ToString();
        }

        #endregion



        #region Private Instance Variables

        /// <summary>
        /// The player to display information in the user control.
        /// </summary>
        private FightClubPlayer playerToDisplayInformation;

        #endregion
    }
}
