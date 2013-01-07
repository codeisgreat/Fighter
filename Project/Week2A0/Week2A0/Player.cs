using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Week2A0
{
    /// <summary>
    /// A class that represents a generic Player.
    /// </summary>
    public class Player : ICodeable
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Player()
        {
            // Set the name to be the default
            name = "Un-named Player";
        }


        /// <summary>
        /// Sets the name of the Player once constructed.
        /// </summary>
        /// <param name="name">The name you wish to name the Player.</param>
        public Player(string name)
        {
            // Set the name of the player
            this.name = name;
        }


        /// <summary>
        /// Un-serializes a Player Object.
        /// </summary>
        public Player(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }

            // set the name
            this.Name = info.GetString("Name");
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// Resembles the Name of the Player.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion



        #region Overridden Methods

        public virtual void ReadFromStream(System.IO.StreamReader streamReader)
        {
            // The text to extract variables from
            string textToExtractVariablesFrom = streamReader.ReadLine(); 

            // Get the name value, lol.
            string nameValue = textToExtractVariablesFrom.Substring(textToExtractVariablesFrom.IndexOf('=') + 1, 
                                                                    textToExtractVariablesFrom.Length - 1 - textToExtractVariablesFrom.IndexOf('='));

            Name = nameValue;
        }


        public virtual void WriteToStream(System.IO.StreamWriter streamWriter)
        {
            streamWriter.WriteLine("Name=" + this.Name);

            streamWriter.Flush();
        }

        #endregion



        #region Private Instance Varaibles

        /// <summary>
        /// The Player's name.
        /// </summary>
        private string name;

        #endregion
    }
}