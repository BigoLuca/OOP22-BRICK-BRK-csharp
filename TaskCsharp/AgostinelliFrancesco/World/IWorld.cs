using System.Collections.Generic;

namespace AgostinelliFrancesco.World
{
    /// <summary>
    /// Interface to model the Game World. It defines the objects that belong to it:
    /// Balls, Bar, Bricks, PowerUps, and the main Bounding Box on the edge of the World.
    /// It also defines the object movement and their collision.
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// Adds a ball to the world.
        /// </summary>
        /// <param name="ball">The ball to add.</param>
        void AddBall(Ball ball);

        /// <summary>
        /// Gets the list of balls in play.
        /// </summary>
        /// <returns>The list of balls in play.</returns>
        List<Ball> GetBalls();

        /// <summary>
        /// Gets the bar.
        /// </summary>
        /// <returns>The bar object.</returns>
        Bar GetBar();

        /// <summary>
        /// Sets the bar.
        /// </summary>
        /// <param name="bar">The bar to set.</param>
        void SetBar(Bar bar);

        /// <summary>
        /// Adds bricks to the world.
        /// </summary>
        /// <param name="bricks">The list of bricks to add.</param>
        void AddBricks(List<Brick> bricks);

        /// <summary>
        /// Gets the list of bricks in the world.
        /// </summary>
        /// <returns>The list of bricks.</returns>
        List<Brick> GetBricks();

        /// <summary>
        /// Gets the list of falling power-ups.
        /// </summary>
        /// <returns>The list of falling power-ups.</returns>
        List<PowerUp> GetPowerUps();

        /// <summary>
        /// Gets the main Bounding Box.
        /// </summary>
        /// <returns>The main Bounding Box.</returns>
        RectBoundingBox GetMainBoundingBox();

        /// <summary>
        /// Moves objects in the world at each frame.
        /// </summary>
        /// <param name="elapsed">The time elapsed since the last frame.</param>
        void UpdateGame(int elapsed);

        /// <summary>
        /// Checks for collisions between objects.
        /// </summary>
        void CheckCollision();

        /// <summary>
        /// Gets the current score.
        /// </summary>
        /// <returns>An integer value representing the score.</returns>
        int GetScore();

        /// <summary>
        /// Adds the specified value to the score.
        /// </summary>
        /// <param name="val">The value to add to the score.</param>
        void AddToScore(int val);

        /// <summary>
        /// Changes the states of indestructible bricks.
        /// </summary>
        /// <param name="b">A boolean value indicating if bricks are indestructible.</param>
        void SetDestructibleBrick(bool b);
    }
}
