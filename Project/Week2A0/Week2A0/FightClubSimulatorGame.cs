using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week2A0
{
    public class FightClubSimulatorGame : Game, ICodeable
    {
        /// <summary>
        /// Resembles a Player's turn.
        /// </summary>
        public enum PlayerTurn
        {
            PlayerOneTurn = 1,
            PlayerTwoTurn
        }


        #region Public Constructors

        public FightClubSimulatorGame()
        {
            currentPlayerTurn = PlayerTurn.PlayerOneTurn;
            playerOne = new FightClubPlayer();
            playerTwo = new FightClubPlayer();


            // Set the player name's to the default Player One and Player Two
            PlayerOne.Name = "Player One";
            PlayerTwo.Name = "Player Two";
        }

        #endregion



        #region Overridden Methods

        /// <summary>
        /// Starts the Fight Club Simulator
        /// </summary>
        public override void Start()
        {
            // Generate a new player turn to set the current player's turn and the player that will start the fight...
            CurrentPlayerTurn = StartingPlayerTurn = GenerateNewPlayerTurn();
            
            playerOne.Renew();
            playerTwo.Renew();

            base.Start();
        }


        /// <summary>
        /// Updates the FightClubSimulator, by one frame/tick.
        /// </summary>
        public override void Update()
        {
            for (int i = 0; i < 2; ++i)
            {
                // Depending on what the current player turn is, hit a player.
                switch (CurrentPlayerTurn)
                {
                    case PlayerTurn.PlayerOneTurn:
                        playerOne.Hit(playerTwo);
                        break;
                    case PlayerTurn.PlayerTwoTurn:
                        playerTwo.Hit(playerOne);
                        break;
                }

                // Switch the player's turn.
                SwitchPlayerTurn();
            }

            // If we have a winner player
            if (playerOne.Health <= 0 || playerTwo.Health <= 0)
            {
                // Set done to true
                this.IsDone = true;
            }

            base.Update();
        }

        #endregion



        #region Public Methods


        public void ReadFromStream(System.IO.StreamReader streamReader)
        {
            playerOne.ReadFromStream(streamReader);
            playerTwo.ReadFromStream(streamReader);

            const char seperatingCharacter = '=';

            FightClubPlayer.MaximumHealth           = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            FightClubPlayer.MinimumDexerityValue    = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            FightClubPlayer.MaximumDexerityValue    = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            FightClubPlayer.MaximumArmourValue      = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            FightClubPlayer.CriticalHitMultiplier   = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            FightClubPlayer.MaximumBaseDamage       = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
        }


        public void WriteToStream(System.IO.StreamWriter streamWriter)
        {
            playerOne.WriteToStream(streamWriter);
            playerTwo.WriteToStream(streamWriter);

            streamWriter.WriteLine("Maximum Health="            + FightClubPlayer.MaximumHealth.ToString());
            streamWriter.WriteLine("Minimum Dexerity="          + FightClubPlayer.MinimumDexerityValue.ToString());
            streamWriter.WriteLine("Maximum Dexertiy="          + FightClubPlayer.MaximumDexerityValue.ToString());
            streamWriter.WriteLine("Maximum Armour Value="      + FightClubPlayer.MaximumArmourValue.ToString());
            streamWriter.WriteLine("Critical Hit Multiplier="   + FightClubPlayer.CriticalHitMultiplier.ToString());
            streamWriter.WriteLine("Maximum Base Damage="       + FightClubPlayer.MaximumBaseDamage.ToString());
        }


        public FightClubPlayer GetPlayer(PlayerTurn playerTurn)
        {
            FightClubPlayer temp = null;

            switch (playerTurn)
            {
                case PlayerTurn.PlayerOneTurn:
                    temp = PlayerOne;
                    break;
                case PlayerTurn.PlayerTwoTurn:
                    temp = PlayerTwo;
                    break;
            }

            return temp;
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// This resembles who started to hit whom in the start of the fight.
        /// </summary>
        public PlayerTurn StartingPlayerTurn
        {
            get
            {
                return startingPlayerTurn;
            }
            set
            {
                startingPlayerTurn = value;
            }
        }


        /// <summary>
        /// This resembles the winner player of the game. This will be null if there was no winner, or if there was a tie.
        /// </summary>
        public FightClubPlayer WinnerPlayer
        {
            get
            {
                FightClubPlayer winner = null;
                if (playerOne.Health >= 0 || playerTwo.Health >= 0)
                {
                    if (playerOne.Health <= 0)
                    {
                        winner = playerTwo;
                    }
                    else if (playerTwo.Health <= 0)
                    {
                        winner = playerOne;
                    }
                }

                return winner;
            }
        }


        /// <summary>
        /// This resembles the loser player of the game. This will be null if there was no winner, or if there was a tie.
        /// </summary>
        public FightClubPlayer LoserPlayer
        {
            get
            {
                FightClubPlayer loser = null;
                if (playerOne.Health >= 0 || playerTwo.Health >= 0)
                {
                    if (playerOne.Health <= 0)
                    {
                        loser = playerOne;
                    }
                    else if (playerTwo.Health <= 0)
                    {
                        loser = playerTwo;
                    }
                }

                return loser;
            }
        }


        /// <summary>
        /// This resembles who's turn it is to hit whom.
        /// </summary>
        public PlayerTurn CurrentPlayerTurn
        {
            get
            {
                return currentPlayerTurn;
            }
            private set
            {
                currentPlayerTurn = value;
            }
        }


        /// <summary>
        /// The first player in the game.
        /// </summary>
        public FightClubPlayer PlayerOne
        {
            get
            {
                return playerOne;
            }
        }


        /// <summary>
        /// The second player in the game.
        /// </summary>
        public FightClubPlayer PlayerTwo
        {
            get
            {
                return playerTwo;
            }
        }

        #endregion



        #region Private Utility Methods

        /// <summary>
        /// Switches the Current Player turn
        /// </summary>
        private void SwitchPlayerTurn()
        {
            switch (CurrentPlayerTurn)
            {
                case PlayerTurn.PlayerOneTurn:
                    CurrentPlayerTurn = PlayerTurn.PlayerTwoTurn;
                    break;
                case PlayerTurn.PlayerTwoTurn:
                    CurrentPlayerTurn = PlayerTurn.PlayerOneTurn;
                    break;
            }
        }


        /// <summary>
        /// Generates a new player turn.
        /// </summary>
        private PlayerTurn GenerateNewPlayerTurn()
        {
            Random randomNumberGenerator = new Random();
            PlayerTurn temp;

            int playerTurn = randomNumberGenerator.Next(2) + 1;
            temp = (PlayerTurn)playerTurn;

            return temp;
        }

        #endregion



        #region Private Instance Variables

        /// <summary>
        /// Resembles what player started to fight first.
        /// </summary>
        PlayerTurn startingPlayerTurn;


        /// <summary>
        /// The current player's turn.
        /// </summary>
        PlayerTurn currentPlayerTurn;


        /// <summary>
        /// Player one in this fight club simulator game.
        /// </summary>
        FightClubPlayer playerOne;


        /// <summary>
        /// Player two in this fight club simulator game.
        /// </summary>
        FightClubPlayer playerTwo;

        #endregion
    }
}
