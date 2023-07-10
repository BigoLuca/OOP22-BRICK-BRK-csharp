namespace TellariniPietro.model
{
    /// <summary>
    /// Class representing a user.
    /// </summary>
    public class User
    {
        private string name;
        private int levelReached;

        /// <summary>
        /// User constructor.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        public User(string userName)
        {
            name = userName;
            levelReached = 1;
        }

        /// <summary>
        /// Method to get the name of the user.
        /// </summary>
        /// <returns>The name of the user.</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Method to get the level reached by the user.
        /// </summary>
        /// <returns>The level reached.</returns>
        public int GetLevelReached()
        {
            return levelReached;
        }
    }
}
