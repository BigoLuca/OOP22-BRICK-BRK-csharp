using System;
using System.Collections.Generic;

namespace AgostinelliFrancesco.World
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the <see cref="IWorld"/> interface.
    /// </summary>
    public class WorldImpl : IWorld
    {
        /// <summary>
        /// Indicates on which side the collision occurred.
        /// </summary>
        public enum SideCollision
        {
            /// <summary>
            /// Top side.
            /// </summary>
            TOP,
            /// <summary>
            /// Bottom side.
            /// </summary>
            BOTTOM,
            /// <summary>
            /// Left side.
            /// </summary>
            LEFT,
            /// <summary>
            /// Right side.
            /// </summary>
            RIGHT
        }

        private List<Ball> balls;
        private Bar bar;
        private List<Brick> bricks;
        private List<PowerUp> powerUps;
        private RectBoundingBox mainBBox;
        private Dictionary<PowerUpApplicator, int> activePowerUps;
        private WorldEvent @event;
        private ApplicatorFactory factory;
        private int score;
        private bool destructibleBrick;

        private readonly double mulELAPSED = 0.001;
        private readonly int brickScore = 100;

        /// <summary>
        /// World constructor.
        /// </summary>
        /// <param name="mainBbox">The main bounding box of the world.</param>
        public WorldImpl(RectBoundingBox mainBbox)
        {
            balls = new List<Ball>();
            bricks = new List<Brick>();
            powerUps = new List<PowerUp>();
            mainBBox = mainBbox;
            activePowerUps = new Dictionary<PowerUpApplicator, int>();
            score = 0;
            @event = new WorldEvent();
            factory = new ApplicatorFactory();
            destructibleBrick = true;
        }

        /// <inheritdoc />
        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        /// <inheritdoc />
        public List<Ball> GetBalls()
        {
            return balls;
        }

        /// <inheritdoc />
        public Bar GetBar()
        {
            return bar;
        }

        /// <inheritdoc />
        public void SetBar(Bar bar)
        {
            this.bar = bar;
        }

        /// <inheritdoc />
        public void AddBricks(List<Brick> bricks)
        {
            this.bricks.AddRange(bricks);
        }

        /// <inheritdoc />
        public List<Brick> GetBricks()
        {
            return bricks;
        }

        /// <inheritdoc />
        public List<PowerUp> GetPowerUps()
        {
            return powerUps;
        }

        /// <inheritdoc />
        public RectBoundingBox GetMainBBox()
        {
            return mainBBox;
        }

        /// <inheritdoc />
        public void UpdateGame(int elapsed)
        {
            foreach (var ball in balls)
            {
                ball.Position += ball.Speed * (mulELAPSED * elapsed);
            }

            foreach (var powerUp in powerUps)
            {
                powerUp.Position += powerUp.Speed * (mulELAPSED * elapsed);
            }
        }

        /// <inheritdoc />
        public void CheckCollision()
        {
            CheckCollisionWithPowerUp();
            CheckCollisionWithBall();
            DisablePowerUp();
        }

        /*
         * Ball collsion with boundary
         * Ball collision with bar
         * Ball collision with bricks
         */
        private void CheckCollisionWithBall()
        {
            var ul = mainBBox.GetULCorner();
            var br = mainBBox.GetBRCorner();

            var ballIt = balls.GetEnumerator();
            while (ballIt.MoveNext())
            {
                var ball = ballIt.Current;
                var pos = ball.Position;
                var r = ball.Radius;

                if (pos.Y - r < ul.Y)
                {
                    // TOP-BORDER
                    @event.Process(ball, SideCollision.TOP, ul.Y);
                }
                else if (pos.Y + r > br.Y)
                {
                    // BOTTOM-BORDER
                    ballIt.Remove();
                    if (balls.Count <= 0)
                    {
                        bar.DecLife();
                    }
                }
                else if (pos.X - r < ul.X)
                {
                    // LEFT-BORDER
                    @event.Process(ball, SideCollision.LEFT, ul.X);
                }
                else if (pos.X + r > br.X)
                {
                    // RIGHT-BORDER
                    @event.Process(ball, SideCollision.RIGHT, br.X);
                }
                else if (bar.BBox.IsCollidingWith(ball.BBox))
                {
                    // BAR
                    @event.Process(ball, bar);
                }
                else
                {
                    // BRICK
                    var brickIt = bricks.GetEnumerator();
                    var found = true;
                    while (brickIt.MoveNext())
                    {
                        var brick = brickIt.Current;
                        if (brick.BBox.IsCollidingWith(ball.BBox))
                        {
                            if (found)
                            {
                                @event.Process(ball, brick);
                                found = false;
                            }
                            if (destructibleBrick)
                            {
                                brick.DecLife();
                                if (brick.Life <= 0)
                                {
                                    if (brick.PowerUp != TypePower.Null)
                                    {
                                        powerUps.Add(new PowerUp(brick.BBox.GetP2d(), brick.PowerUp));
                                    }
                                    brickIt.Remove();
                                    AddToScore(brickScore);
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * Power up collision with bar
         */
        private void CheckCollisionWithPowerUp()
        {
            var powerIt = powerUps.GetEnumerator();
            while (powerIt.MoveNext())
            {
                var p = powerIt.Current;
                if (p.Position.Y + p.Height / 2 > mainBBox.GetBRCorner().Y)
                {
                    powerIt.Remove();
                }
                else if (p.BBox.IsCollidingWith(bar.BBox))
                {
                    bool type = p.PowerUp.Type.Equals(TypePowerUp.Positive);
                    factory.CreateApplicator(p.PowerUp, type).ApplyPowerUp(this);
                    if (p.PowerUp.Duration > 0)
                    {
                        activePowerUps[factory.CreateApplicator(p.PowerUp, !type)] = p.PowerUp.Duration;
                    }
                    powerIt.Remove();
                }
            }
        }

        private void DisablePowerUp()
        {
            var iterator = activePowerUps.GetEnumerator();
            while (iterator.MoveNext())
            {
                var entry = iterator.Current;
                var key = entry.Key;
                var value = entry.Value - 1;
                if (value <= 0)
                {
                    key.ApplyPowerUp(this);
                    iterator.Remove();
                }
                else
                {
                    entry = new KeyValuePair<PowerUpApplicator, int>(key, value);
                }
            }
        }

        /// <inheritdoc />
        public int GetScore()
        {
            return score;
        }

        /// <inheritdoc />
        public void AddToScore(int value)
        {
            score += value;
        }

        /// <inheritdoc />
        public void SetDestructibleBrick(bool isDestructible)
        {
            destructibleBrick = isDestructible;
        }
    }
}
