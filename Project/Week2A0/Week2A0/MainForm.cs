// Miguel Martin.
// 25/6/12
// Fight Club Simulator

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Week2A0
{
    public partial class MainForm : Form, ICodeable
    {
        public string[] WinningMessages = { "slayed", "dominated", "slayed" };


        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            Initialize();
        }

        #endregion



        #region Public Methods

        public new void Update()
        {
            playerOneUserControl.Update();
            playerTwoUserControl.Update();
            base.Update();
        }


        /// <summary>
        /// Initializes the class's defaults.
        /// </summary>
        public void Initialize()
        {
            timerSpeedTrackBar.Value = 1000;


            // Add events
            game.PlayerOne.OnPlayerAttemptedToHitAnotherPlayerEvent += onPlayerTriedToHitPlayer;
            game.PlayerTwo.OnPlayerAttemptedToHitAnotherPlayerEvent += onPlayerTriedToHitPlayer;

            game.PlayerOne.OnGotHitEvent += onPlayerTookDamage;
            game.PlayerTwo.OnGotHitEvent += onPlayerTookDamage;


            // Add user controls to the split containers, so we can see the information :D
            playerOneUserControl.PlayerToDisplayInformation = game.PlayerOne;
            playerTwoUserControl.PlayerToDisplayInformation = game.PlayerTwo;

            // Add it to the containers
            playerSplitContainer.Panel1.Controls.Add(playerOneUserControl);
            playerSplitContainer.Panel2.Controls.Add(playerTwoUserControl);

            // Resize the splitter container, to make it even.
            playerSplitterPanel_Resize(null, null);

            // User can fight, so set it to true
            CanFight = true;
        }


        public void SaveToStream(Stream stream)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(stream);
                WriteToStream(streamWriter);
            }
            catch (System.Exception e)
            {
                // Display a friendly error message if we got an exception
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (streamWriter != null)
                {
                    // Close the streamWriter (which also closes the stream)
                    streamWriter.Close();
                }
            }
        }


        public void OpenFromStream(Stream stream)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(stream);
                ReadFromStream(streamReader);
            }
            catch (Exception e)
            {
                // Display a friendly error message if we got an exception
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (streamReader != null)
                {
                    // Close the reader (which closes the stream too)
                    streamReader.Close();
                }
            }
        }


        public void ReadFromStream(StreamReader streamReader)
        {
            game.ReadFromStream(streamReader);
            game.Start();
            Update();
        }


        public void WriteToStream(StreamWriter streamWriter)
        {
            game.WriteToStream(streamWriter);
        }


        public void ShowSaveFileDialog()
        {
            // If the user chose a file to save to
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the file
                SaveToStream(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write));

                this.Text = "Fighter Simulator - " + saveFileDialog.FileName;
            }
        }


        public void ShowOpenFileDialog()
        {
            // If the user chose a file to open from
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the file
                OpenFromStream(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));

                this.Text = "Fighter Simulator - " + openFileDialog.FileName;
            }
        }


        public void ShowPreferencesForm()
        {
            PreferencesForm form = new PreferencesForm(game);
            form.ShowDialog();

            Update();
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// A handy boolean flag that tells whether the user can fight.
        /// This changes the UI to adjust to whether he/she can or cannot.
        /// </summary>
        public bool CanFight
        {
            get
            {
                return fightButton.Enabled;
            }
            set
            {
                fightButton.Enabled = value;
                playAgainButton.Enabled = !fightButton.Enabled;
                stopButton.Enabled = true;

                if (fightButton.Enabled)
                {
                    this.AcceptButton = fightButton;
                }
                else
                {
                    this.AcceptButton = playAgainButton;
                }
            }
        }

        #endregion



        #region Private Instance Variables

        /// <summary>
        /// The actual fight club simulator game.
        /// </summary>
        private FightClubSimulatorGame game = new FightClubSimulatorGame();


        /// <summary>
        /// Player one user control, to edit/show the player one's attributes.
        /// </summary>
        private PlayerUserControl playerOneUserControl = new PlayerUserControl();


        /// <summary>
        /// Player two user control, to edit/show the player two's attributes.
        /// </summary>
        private PlayerUserControl playerTwoUserControl = new PlayerUserControl();

        #endregion



        #region Private Utility Methods

        /// <summary>
        /// Appends text to the output console textbox and scrolls down to the text.
        /// </summary>
        /// <param name="text">The text you wish to append to</param>
        public void AppendTextToOutputTextBox(string text)
        {
            outputConsoleTextBox.Text += text;

            outputConsoleTextBox.Select(outputConsoleTextBox.Text.Length - 1, 0);
            outputConsoleTextBox.ScrollToCaret();
        }

        #endregion



        #region Events

        private void timerSpeedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TrackBar bar = sender as TrackBar;
                timerFakeLoop.Interval = bar.Value;

                // Update the label
                fightDelayLabel.Text = timerFakeLoop.Interval.ToString() + "ms";
            }
            catch (SystemException)
            {
                // ignore it (for null deref's etc.)
            }
        }


        private void playerSplitterPanel_Resize(object sender, EventArgs e)
        {
            playerSplitContainer.SplitterDistance = playerSplitContainer.Size.Width / 2;
        }


        private void fightButton_Click(object sender, EventArgs e)
        {
            CanFight = false;
            game.IsDone = false;
            timerFakeLoop.Enabled = true;
            timerFakeLoop.Start();
        }


        private void timerFakeLoop_Tick(object sender, EventArgs e)
        {
            // Update the game and form.
            game.Update();
            Update();

            // Update the timer's enabled to the opposite of game.IsDone
            timerFakeLoop.Enabled = !game.IsDone;

            // If the game has been done
            if (game.IsDone)
            {
                // Get the winner/loser players
                FightClubPlayer winner = game.WinnerPlayer;
                FightClubPlayer loser = game.LoserPlayer;

                // Let's get a random message
                Random r = new Random();
                int randomMessageIndex = r.Next(WinningMessages.Length);


                if (winner != null && loser != null)
                {
                    // Print it to the output console text box
                    AppendTextToOutputTextBox(winner.Name + " " + WinningMessages[randomMessageIndex] + " " + loser.Name + "!\r\n");
                }
                else
                {
                    // It was a draw
                    AppendTextToOutputTextBox("It was a draw :(!\r\n");
                }

                // user can no longer fight, as one or both of the players are dead
                CanFight = false;
            }
        }


        private void playAgainButton_Click(object sender, EventArgs e)
        {
            // Re-start the game.
            game.Start();

            // Set the CanFight flag to true, as he/she can fight once again.
            CanFight = true;

            // Clear the outputConsoleTextBox's text
            outputConsoleTextBox.Text = "";


            // Update the form.
            Update();
        }


        private void onPlayerTriedToHitPlayer(object sender, FightClubPlayer.PlayerHitEventArgs arg)
        {
            string outputMessage;

            string[] hitMessages = { "smacked", "wacked", "kicked", "elbowed" };
            string[] missMessages = { "dodged", "flipped away from" };

            // This is just to set the text message, 
            // it will be Red if someone got hit and Blue if someone missed
            // and Orange/Red if someone did a critical hit
            Color textColour = new Color();

            if (arg.DidHitPlayer)
            {
                string hitMessage = hitMessages[random.Next(hitMessages.Length)];
                outputMessage = ">" + arg.PlayerThatWasHit.Name + " got " + hitMessage + " by " + arg.PlayerThatHitTheOtherPlayer.Name + "\r\n";

                // set the text to red
                textColour = Color.Red;
            }
            else
            {
                string missMessage = missMessages[random.Next(missMessages.Length)];
                // player that was hit xxx player that hit other player
                outputMessage = ">" + arg.PlayerThatWasHit.Name + " " + missMessage + " " + arg.PlayerThatHitTheOtherPlayer.Name + "\r\n";

                // Set the text to blue
                textColour = Color.Blue;
            }


            if (arg.IsCriticalHit)
            {
                outputMessage += ">" + arg.PlayerThatHitTheOtherPlayer.Name + " did a critical hit on " + arg.PlayerThatWasHit.Name + "\r\n";

                // Set the text to orangey red
                textColour = Color.OrangeRed;
            }

            // Set the fore colour of the text box
            outputConsoleTextBox.SelectionColor = textColour;

            // Append the generated message for the textbox
            outputConsoleTextBox.Text += outputMessage;
        }


        private void onPlayerTookDamage(object sender, FightClubPlayer.PlayerGotHitEventArgs arg)
        {
            AppendTextToOutputTextBox(arg.Me.Name + " took " + arg.AmountOfDamageTaken.ToString() + " damage by " + arg.ByWho.Name + "\r\n");
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form
            Close();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOpenFileDialog();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.FileName == "")
            {
                ShowSaveFileDialog();
            }
            else
            {
                SaveToStream(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write));
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSaveFileDialog();
        }


        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPreferencesForm();
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            timerFakeLoop.Enabled = false;
            playAgainButton.Enabled = true;
            fightButton.Enabled = true;
        }

        #endregion


        /// <summary>
        /// A random generator
        /// </summary>
        static private Random random = new Random();
    }
}
