
using TellariniPietro.common;
using TellariniPietro.model;

namespace TellariniPietro.Controllers
{
    /// <summary>
    /// The controller of the ranks.
    /// </summary>
    public class RankController
    {
        private const string ENDLESS_RANKS_FILE = "endless.json";
        private const string LEVEL_RANKS_FILE = "levels.json";

        private List<Rank> endlessRanks;
        private List<Rank> levelsRanks;

        /// <summary>
        /// RankController constructor.
        /// </summary>
        public RankController()
        {
            endlessRanks = new List<Rank>();
            levelsRanks = new List<Rank>();
            endlessRanks = JsonUtils.LoadData<List<Rank>>(ENDLESS_RANKS_FILE);
            levelsRanks = JsonUtils.LoadData<List<Rank>>(LEVEL_RANKS_FILE);
        }

        /// <summary>
        /// Method to save the ranks.
        /// </summary>
        public void SaveRanks()
        {
            JsonUtils.SaveData(endlessRanks, ENDLESS_RANKS_FILE);
            JsonUtils.SaveData(levelsRanks, LEVEL_RANKS_FILE);
        }

        /// <summary>
        /// Method to get all the endless mode ranks.
        /// </summary>
        /// <returns>A List of Rank of the endless.</returns>
        public List<Rank> GetEndlessRanks()
        {
            return endlessRanks;
        }

        /// <summary>
        /// Method to get all the levels mode ranks.
        /// </summary>
        /// <returns>A List of Rank of the levels.</returns>
        public List<Rank> GetLevelsRanks()
        {
            return levelsRanks;
        }

        /// <summary>
        /// Method to add a new score to the endless rank.
        /// The method adds the score in the rank of the difficulty passed.
        /// </summary>
        /// <param name="difficulty">The difficulty of the rank.</param>
        /// <param name="username">The username of the player.</param>
        /// <param name="newScore">The new score.</param>
        public void AddScoreInEndlessRank(Difficulty difficulty, string username, int newScore)
        {
            endlessRanks.FirstOrDefault(r => r.GetLevel() == difficulty.GetHashCode())?.AddScore(username, newScore);
        }

        /// <summary>
        /// Method to add a new score to the levels rank.
        /// The method adds the score in the rank of the level passed.
        /// </summary>
        /// <param name="level">The level of the rank.</param>
        /// <param name="username">The username of the player.</param>
        /// <param name="newScore">The new score.</param>
        public void AddScoreInLevelsRank(int level, string username, int newScore)
        {
            levelsRanks.FirstOrDefault(r => r.GetLevel() == level)?.AddScore(username, newScore);
        }

        /// <summary>
        /// Method to remove a score in all the ranks.
        /// </summary>
        /// <param name="username">The username of the player.</param>
        public void RemoveScoreInAllRanks(string username)
        {
            endlessRanks.ForEach(r => r.GetRank().Remove(username));
            levelsRanks.ForEach(r => r.GetRank().Remove(username));
        }

        /// <summary>
        /// Method to get the EndlessRank.
        /// </summary>
        /// <param name="difficulty">The difficulty of the rank.</param>
        /// <returns>A Rank.</returns>
        public Rank GetEndlessRank(Difficulty difficulty)
        {
            return endlessRanks.FirstOrDefault(r => r.GetLevel() == difficulty.GetHashCode());
        }

        /// <summary>
        /// Method to get the size of endless rank.
        /// </summary>
        /// <returns>An integer size.</returns>
        public int GetEndlessRankQuantity()
        {
            return endlessRanks.Count;
        }

        /// <summary>
        /// Method to get the LevelsRank.
        /// </summary>
        /// <param name="level">The level of the rank.</param>
        /// <returns>A Rank.</returns>
        public Rank GetLevelsRank(int level)
        {
            return levelsRanks.FirstOrDefault(r => r.GetLevel() == level);
        }

        /// <summary>
        /// Method to get the size of levels rank.
        /// </summary>
        /// <returns>An integer size.</returns>
        public int GetLevelsRankQuantity()
        {
            return levelsRanks.Count;
        }
    }
}
