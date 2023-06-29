using System.Collections.Generic;
using brickbreaker.common;

namespace brickbreaker.model.map
{
    public class MapData
    {
        public const int MAP_ROWS_FILE_FORMAT = 6;
        public const int MAP_COLUMNS_FILE_FORMAT = 6;

        public int Index { get; set; }
        public string Landscape { get; set; }
        public List<int> Map { get; set; }
        public int Difficulty { get; set; }
        public string Name { get; set; }

        public MapData(int index, List<int> map, int difficulty, string name, string landscape)
        {
            Index = index;
            Map = map;
            Difficulty = difficulty;
            Name = name;
            Landscape = landscape;
        }

        public GameImages GetLandscape()
        {
            return (GameImages)System.Enum.Parse(typeof(GameImages), Landscape);
        }

        public void SetLandscape(string landscape)
        {
            Landscape = landscape;
        }

        public Difficulty GetDifficulty()
        {
            return (Difficulty)Difficulty;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            Difficulty = (int)difficulty;
        }
    }
}
