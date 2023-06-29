using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using brickbreaker.common;
using brickbreaker.model.rank;
using brickbreaker.common;

namespace brickbreaker.controllers
{
    public class RankController
    {
        private const string ENDLESS_RANKS_FILE = "endless.json";
        private const string LEVEL_RANKS_FILE = "levels.json";

        private List<Rank> endlessRanks;
        private List<Rank> levelsRanks;

        public RankController()
        {
            endlessRanks = new List<Rank>();
            levelsRanks = new List<Rank>();
            endlessRanks = JsonUtils.LoadData<List<Rank>>(ENDLESS_RANKS_FILE);
            levelsRanks = JsonUtils.LoadData<List<Rank>>(LEVEL_RANKS_FILE);
        }

        public void SaveRanks()
        {
            JsonUtils.SaveData(endlessRanks, ENDLESS_RANKS_FILE);
            JsonUtils.SaveData(levelsRanks, LEVEL_RANKS_FILE);
        }

        public List<Rank> GetEndlessRanks()
        {
            return endlessRanks;
        }

        public List<Rank> GetLevelsRanks()
        {
            return levelsRanks;
        }

        public void AddScoreInEndlessRank(Difficulty difficulty, string username, int newScore)
        {
            endlessRanks.FirstOrDefault(r => r.Index == difficulty.Ordinal()).AddScore(username, newScore);
        }

        public void AddScoreInLevelsRank(int level, string username, int newScore)
        {
            levelsRanks.FirstOrDefault(r => r.Index == level).AddScore(username, newScore);
        }

        public void RemoveScoreInAllRanks(string username)
        {
            endlessRanks.ForEach(r => r.Rank.Remove(username));
            levelsRanks.ForEach(r => r.Rank.Remove(username));
        }

        public Rank GetEndlessRank(Difficulty difficulty)
        {
            return endlessRanks.FirstOrDefault(r => r.Index == difficulty.Ordinal());
        }

        public int GetEndlessRankQuantity()
        {
            return endlessRanks.Count;
        }

        public Rank GetLevelsRank(int level)
        {
            return levelsRanks.FirstOrDefault(r => r.Index == level);
        }

        public int GetLevelsRankQuantity()
        {
            return levelsRanks.Count;
        }
    }
}
