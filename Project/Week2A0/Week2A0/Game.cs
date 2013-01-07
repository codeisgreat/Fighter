using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week2A0
{
    /// <summary>
    /// An abstract class that represents a Game.
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        /// Starts the Game off.
        /// </summary>
        public virtual void Start()
        {
            IsDone = false; 
        }


        /// <summary>
        /// Updates the Game.
        /// </summary>
        public virtual void Update()
        {
            // do nothing...
        }



        /// <summary>
        /// A boolean flag to tell whether the game is done.
        /// </summary>
        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }


        /// <summary>
        /// A boolean flag to tell whether the game is done.
        /// </summary>
        private bool isDone;
    }
}