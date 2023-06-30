using System;
using System.Collections.Generic;

namespace AgostinelliFrancesco.Factory
{
    /// <summary>
    /// Factory class for creating game objects: Ball, Bar, Bricks.
    /// </summary>
    public class GameFactory
    {
        public const int LIFE_BAR = 1;
        private static GameFactory instance;

        /// <summary>
        /// Returns the instance of GameFactory if it exists, otherwise creates a new instance.
        /// </summary>
        /// <returns>The singleton instance of GameFactory.</returns>
        public static GameFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new GameFactory();
            }
            return instance;
        }

        /// <summary>
        /// Creates a new Ball object with the specified position and velocity.
        /// </summary>
        /// <param name="posToSet">The position to set for the Ball.</param>
        /// <param name="velToSet">The velocity to set for the Ball.</param>
        /// <returns>A new Ball object.</returns>
        public Ball CreateBall(Vector2D posToSet, Vector2D velToSet)
        {
            return new Ball(posToSet, velToSet);
        }

        /// <summary>
        /// Creates a list of Brick objects based on the provided list of brick lives, number of columns, and number of rows.
        /// </summary>
        /// <param name="list">The list of brick lives.</param>
        /// <param name="col">The number of columns.</param>
        /// <param name="row">The number of rows.</param>
        /// <returns>A list of Brick objects.</returns>
        public List<Brick> CreateBricks(List<int> list, int col, int row)
        {
            List<Brick> result = new List<Brick>();
            int life;
            for (int y = 0; y < row; y++)
            {
                for (int x = 0; x < col; x++)
                {
                    life = list[x + y * col];
                    if (life > 0)
                    {
                        result.Add(new Brick(
                            new Vector2D(x * Brick.BRICK_WIDTH + (Brick.BRICK_WIDTH / 2), y
                                * Brick.BRICK_HEIGHT + (Brick.BRICK_HEIGHT / 2)),
                            life));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Creates a list of random Brick objects based on the provided difficulty, number of columns, and number of rows.
        /// </summary>
        /// <param name="d">The difficulty of the game.</param>
        /// <param name="cols">The number of columns.</param>
        /// <param name="rows">The number of rows.</param>
        /// <returns>A list of random Brick objects.</returns>
        public List<Brick> CreateRandomBricks(Difficulty d, int cols, int rows)
        {
            Random r = new Random();
            List<Brick> bricks = new List<Brick>();

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (r.Next(100) < d.GetBrickPercentage())
                    {
                        bricks.Add(new Brick(
                            new Vector2D(i * Brick.BRICK_WIDTH + Brick.BRICK_WIDTH / 2, j
                                * Brick.BRICK_HEIGHT + Brick.BRICK_HEIGHT / 2),
                            r.Next(d.GetMaxBrickLife()) + 1));
                    }
                }
            }
            return bricks;
        }

        /// <summary>
        /// Creates a new Bar object with the specified position and a default life value of 1.
        /// </summary>
        /// <param name="posToSet">The position to set for the Bar.</param>
        /// <returns>A new Bar object.</returns>
        public Bar CreateBar(Vector2D posToSet)
        {
            return new Bar(posToSet, LIFE_BAR);
        }
    }
}
