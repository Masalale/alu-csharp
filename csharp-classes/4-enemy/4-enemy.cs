using System;

namespace Enemies
{
    /// <summary>
    /// Represents a zombie.
    /// </summary>
    public class Zombie
    {
        // health of the zombie
        private int health;
        // name of the zombie
        private string name = "(No name)";

        /// <summary>
        /// Gets or sets the name of the zombie.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zombie"/> class.
        /// </summary>
        public Zombie()
        {
            health = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zombie"/> class.
        /// </summary>
        /// <param name="value">Health value, must be greater than or equal to 0.</param>
        /// <exception cref="ArgumentException">Thrown when value is less than 0.</exception>
        public Zombie(int value)
        {
            if (value < 0)
                throw new ArgumentException("Health must be greater than or equal to 0");
            health = value;
        }

        /// <summary>
        /// Returns the health value of the zombie.
        /// </summary>
        /// <returns>The health value.</returns>
        public int GetHealth()
        {
            return health;
        }
    }
}
