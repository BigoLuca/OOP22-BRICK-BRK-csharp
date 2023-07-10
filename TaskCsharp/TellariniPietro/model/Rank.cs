using System.Collections.Generic;

namespace TellariniPietro.model
{
    /// <summary>
    /// Class representing a rank.
    /// </summary>
    public class Rank
    {
        private int level;
        private Dictionary<string, int> scores;

        /// <summary>
        /// Rank constructor.
        /// </summary>
        /// <param name="l">The level of the rank.</param>
        public Rank(int l)
        {
            level = l;
            scores = new Dictionary<string, int>();
        }

        /// <summary>
        /// Method to get the rank.
        /// </summary>
        /// <returns>A dictionary with the name of the player and the score representing the rank.</returns>
        public Dictionary<string, int> GetRank()
        {
            return scores;
        }

        /// <summary>
        /// Method to get the level of the rank.
        /// </summary>
        /// <returns>The level of the rank.</returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// Method to add a new score to the rank only if better.
        /// </summary>
        /// <param name="name">The name of the score.</param>
        /// <param name="score">The score.</param>
        public void AddScore(string name, int score)
        {
            if (score > scores.GetValueOrDefault(name, -1))
            {
                scores[name] = score;
            }
        }
    }
}
