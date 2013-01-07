using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week2A0
{
    public class FightClubPlayer : Player
    {
        #region Static Public Instance Variables/Constants

        /// <summary>
        /// The maximum  base damage a player may do.
        /// </summary>
        public static int MaximumBaseDamage = 10;

        /// <summary>
        /// The maximum and default amount of health a Player is given.
        /// </summary>
        public static int MaximumHealth = 100;


        /// <summary>
        /// The minimum value of dexerity a Player may have.
        /// </summary>
        public static int MinimumDexerityValue = 1;


        /// <summary>
        /// The maximum value of dexerity a Player may have.
        /// </summary>
        public static int MaximumDexerityValue = 10;


        /// <summary>
        /// The maximum amount of armour that a Player can have.
        /// </summary>
        public static int MaximumArmourValue = 20;


        /// <summary>
        /// A multiplier that multiplies the player's hit when he does a critical hit.
        /// </summary>
        public static int CriticalHitMultiplier = 2;

        #endregion



        #region Public Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public FightClubPlayer()
        {
            Renew();
        }


        /// <summary>
        /// Sets the Player's health.
        /// </summary>
        /// <param name="health">The health of the player you wish the player to have.</param>
        public FightClubPlayer(int health)
        {
            Renew();

            Health = health;
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Hits a player.
        /// </summary>
        /// <param name="player">The player you wish to hit.</param>
        public void Hit(FightClubPlayer player)
        {
            int randomPercentage = randomGenerator.Next(100);
            bool criticalHit = false; // Determines whether it should be a critical hit or not
            bool didHit = false;

            // Using percentages : each time a player hits the other player they deduct 1 from the health pool.
            // % formula for hitting : value <= 50% chance + (dexterity X 2)
            if (randomPercentage <= (50 + (Dexerity * 2)))
            {
                int damageAmount = BaseDamage; // start with the base damage

                //  the damage amount will increase by (Dexerity - player.ArmourAmount)
                damageAmount += Math.Abs(Dexerity - (MaximumArmourValue - player.ArmourAmount));


                // if the random percentage was inbetween 40-50 then we'll do a critical hit
                if(randomPercentage >= 40)
                {
                    damageAmount *= CriticalHitMultiplier;
                    criticalHit = true;
                }


                // decrease the other player's health, because we hit them.
                player.Health -= damageAmount;

                didHit = true;

                // Send an event to the player that got hit
                if (player.OnGotHitEvent != null)
                {
                    player.OnGotHitEvent(this, new PlayerGotHitEventArgs(player, this, damageAmount));
                }
            }

            // Send the event that this player hit another player.
            if (OnPlayerAttemptedToHitAnotherPlayerEvent != null)
            {
                OnPlayerAttemptedToHitAnotherPlayerEvent(this, new PlayerHitEventArgs(this, player, didHit, criticalHit));
            }
        }


        /// <summary>
        /// Renews the Player, giving him/her new health, dexerity, armour and a new base damage.
        /// </summary>
        public void Renew()
        {
            Health = MaximumHealth;
            Dexerity = randomGenerator.Next(MaximumDexerityValue) + MinimumDexerityValue;
            ArmourAmount = randomGenerator.Next(MaximumArmourValue);
            BaseDamage = randomGenerator.Next(MaximumBaseDamage) + 1; // 0 base damage isn't really fair...
        }

        #endregion



        #region Overridden Methods

        public override void ReadFromStream(System.IO.StreamReader streamReader)
        {
            base.ReadFromStream(streamReader);
            const char seperatingCharacter = '=';

            Health = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            Dexerity = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            ArmourAmount = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
            BaseDamage = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), seperatingCharacter));
        }


        public override void WriteToStream(System.IO.StreamWriter streamWriter)
        {
            base.WriteToStream(streamWriter);

            streamWriter.WriteLine("Health=" + Health.ToString());
            streamWriter.WriteLine("Dexerity=" + Dexerity.ToString());
            streamWriter.WriteLine("Armour Armour=" + ArmourAmount.ToString());
            streamWriter.WriteLine("Base Damage=" + BaseDamage.ToString());

            streamWriter.Flush();
        }


        #endregion



        #region Public Events

        public class PlayerGotHitEventArgs : EventArgs
        {
            public PlayerGotHitEventArgs(FightClubPlayer me, FightClubPlayer byWho, int amountOfDamageTaken)
            {
                Me = me;
                ByWho = byWho;
                AmountOfDamageTaken = amountOfDamageTaken;
            }


            /// <summary>
            /// The player that got hit.
            /// </summary>
            public FightClubPlayer Me;


            /// <summary>
            /// By who the player who got hit by.
            /// </summary>
            public FightClubPlayer ByWho;


            /// <summary>
            /// The amount of damage the player took.
            /// </summary>
            public int AmountOfDamageTaken;
        }


        public class PlayerHitEventArgs : EventArgs
        {
            public PlayerHitEventArgs(FightClubPlayer playerThatHitTheOtherPlayer, FightClubPlayer playerThatWasHit,
                                    bool didHitPlayer, bool isCriticalHit = false)
            {
                this.PlayerThatHitTheOtherPlayer = playerThatHitTheOtherPlayer;
                this.PlayerThatWasHit = playerThatWasHit;
                this.DidHitPlayer = didHitPlayer;
                this.IsCriticalHit = isCriticalHit;
            }


            public bool IsCriticalHit;


            public bool DidHitPlayer;


            public FightClubPlayer PlayerThatHitTheOtherPlayer;


            public FightClubPlayer PlayerThatWasHit;
        }


        public delegate void OnAttemptedToHitPlayer(object sender, PlayerHitEventArgs arg);


        public delegate void OnGotHitByPlayer(object sender, PlayerGotHitEventArgs arg);


        /// <summary>
        /// This event is called when this player succesfully hit another player.
        /// </summary>
        public event OnAttemptedToHitPlayer OnPlayerAttemptedToHitAnotherPlayerEvent = null;


        /// <summary>
        /// This event is called whenever this player is hit by another player.
        /// </summary>
        public event OnGotHitByPlayer OnGotHitEvent = null;


        #endregion



        #region Public Properties

        public int BaseDamage
        {
            get
            {
                return baseDamage;
            }

            private set
            {
                baseDamage = value;
            }
        }


        /// <summary>
        /// Resembles the amount of Health a player has.
        /// The health will never be a negative value.
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }

            private set
            {
                health = value;

                // Restrict health to positive numbers
                if (health < 0)
                {
                    health = 0;
                }
                // also restrict it so it cant go past the maximum value
                else if (health > MaximumHealth)
                {
                    health = MaximumHealth;
                }
            }
        }


        /// <summary>
        /// Resembles the Dexerity of the Player.
        /// The dexerity of a player will never be negative.
        /// </summary>
        public int Dexerity
        {
            get
            {
                return dexerity;
            }
            private set
            {
                dexerity = value;

                // restrict dexerity to the minimum or maximum
                if (dexerity < MinimumDexerityValue)
                {
                    dexerity = MinimumDexerityValue;
                }
                else if (dexerity > MaximumDexerityValue)
                {
                    dexerity = MaximumDexerityValue;
                }
            }
        }


        /// <summary>
        /// Resembles the amount of armour a player has.
        /// This value will never be negative.
        /// </summary>
        public int ArmourAmount
        {
            get
            {
                return armourAmount;
            }
            private set
            {
                armourAmount = value;

                // restrict it to positive numbers
                if (armourAmount < 0)
                {
                    armourAmount = 0;
                }
                // restrict the armour amount to the maximum, if nessesary
                else if (armourAmount > MaximumArmourValue)
                {
                    armourAmount = MaximumArmourValue;
                }
            }
        }

        #endregion



        #region Private Instances

        /// <summary>
        /// The health of the Player.
        /// </summary>
        private int health;


        /// <summary>
        /// The amount of dexerity the Player has.
        /// </summary>
        private int dexerity;


        /// <summary>
        /// The amount of armour a Player has.
        /// </summary>
        private int armourAmount;


        /// <summary>
        /// The base amount of damage that a player does.
        /// </summary>
        private int baseDamage;


        /// <summary>
        /// A random number generator to randomize some things.
        /// </summary>
        static Random randomGenerator = new Random();

        #endregion
    }
}
