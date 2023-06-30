using System;
using System.Collections.Generic;
using System.Linq;

namespace AgostinelliFrancesco.Factory
{
    /// <summary>
    /// Factory class for creating game World.
    /// </summary>
    public class WorldFactory
    {
        public const double X_SPEED = 0.0;
        public const double Y_SPEED = -20.0;
        public const double BOUNDARIES_SIZE = 600.0;
        public const int BAR_OFFSET = 20;

        private static WorldFactory instance;
        private Random r = new Random();

        /// <summary>
        /// Returns the instance of WorldFactory if it exists, otherwise creates a new instance.
        /// </summary>
        /// <returns>The singleton instance of WorldFactory.</returns>
        public static WorldFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new WorldFactory();
            }

            return instance;
        }

        /// <summary>
        /// Creates a new empty World object with a Bar and a Ball.
        /// </summary>
        /// <returns>A new empty World object.</returns>
        private World GetEmptyWorld()
        {
            Bar newBar = GameFactory.GetInstance().CreateBar(new Vector2D(BOUNDARIES_SIZE / 2, BOUNDARIES_SIZE - BAR_OFFSET));
            Ball newBall = GameFactory.GetInstance().CreateBall(new Vector2D(BOUNDARIES_SIZE / 2, BOUNDARIES_SIZE - newBar.GetHeight() - Ball.RADIUS),
                new Vector2D(X_SPEED, Y_SPEED));
            RectBoundingBox boundary = new RectBoundingBox(new Vector2D(BOUNDARIES_SIZE / 2, BOUNDARIES_SIZE / 2),
                BOUNDARIES_SIZE, BOUNDARIES_SIZE);
            World w = new WorldImpl(boundary);

            w.SetBar(newBar);
            w.AddBall(newBall);
            return w;
        }

        /// <summary>
        /// Creates a new World object with random bricks based on the provided difficulty.
        /// The bricks have random positions within the world boundaries and random life values.
        /// </summary>
        /// <param name="d">The difficulty that determines the game world's characteristics.</param>
        /// <returns>A new World object with random bricks.</returns>
        public World GetRandomWorld(Difficulty d)
        {
            World w = GetEmptyWorld();
            w.AddBricks(GameFactory.GetInstance().CreateRandomBricks(d, Brick.BRICKS_COL, Brick.BRICKS_ROW));
            RandomPowerUpAssignment(d, w.GetBricks());
            return w;
        }

        /// <summary>
        /// Creates a new World object by loading a map from the database.
        /// The loaded map is used to create the bricks based on the map's difficulty.
        /// </summary>
        /// <param name="map">The map data object that contains the map to load.</param>
        /// <returns>A new World object with bricks loaded from the map.</returns>
        public World GetWorld(MapData map)
        {
            World w = GetEmptyWorld();
            w.AddBricks(GameFactory.GetInstance().CreateBricks(map.GetMap(), MapData.MAP_COLUMNS_FILE_FORMAT, MapData.MAP_ROWS_FILE_FORMAT));
            RandomPowerUpAssignment(map.GetDifficulty(), w.GetBricks());
            return w;
        }

        /// <summary>
        /// Assigns random power-ups to a list of bricks based on the specified difficulty.
        /// </summary>
        /// <param name="d">The difficulty that determines the power-up assignment.</param>
        /// <param name="b">The list of bricks to assign power-ups to.</param>
        private void RandomPowerUpAssignment(Difficulty d, List<Brick> b)
        {
            int numPowerUp = b.Count - (b.Count / 4);
            List<TypePower> p = GetWorldPowerUp(numPowerUp, d.GetBonusPercentage());
            List<int> val = Enumerable.Range(0, b.Count).ToList();

            foreach (TypePower i in p)
            {
                int index = r.Next(val.Count);
                b[val[index]].SetPowerUp(i);
                val.RemoveAt(index);
            }
        }

        /// <summary>
        /// Returns a list of power-up types present in the world.
        /// </summary>
        /// <param name="pQuantity">The number of power-ups to generate.</param>
        /// <param name="bonus">The bonus percentage of power-ups.</param>
        /// <returns>A list of power-up types.</returns>
        private List<TypePower> GetWorldPowerUp(int pQuantity, int bonus)
        {
            List<TypePower> ret = new List<TypePower>();

            int positive = pQuantity * bonus / 100;
            List<TypePower> p = TypePower.GetElement(TypePowerUp.POSITIVE);
            for (int i = 0; i < positive; i++)
            {
                ret.Add(p[r.Next(p.Count)]);
            }

            List<TypePower> n = TypePower.GetElement(TypePowerUp.NEGATIVE);
            for (int i = 0; i < (pQuantity - positive); i++)
            {
                ret.Add(n[r.Next(n.Count)]);
            }

            return ret;
        }
    }
}
