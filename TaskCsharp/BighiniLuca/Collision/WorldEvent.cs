using Common;

namespace BighiniLuca.Collision
{
    /// <summary>
    /// Interface to execute the collision events of the world.
    /// </summary>
    public class WorldEvent
    {
        /// <summary>
        /// The speed of the ball when it hits the bar.
        /// </summary>
        public const int SCALE_SPEED = 15;

        /// <summary>
        /// Process the collision of the ball with the border side.
        /// </summary>
        /// <param name="ball">The ball to process</param>
        /// <param name="side">The side of the collision</param>
        /// <param name="newPos">The new position of the ball</param>
        public void Process(Ball ball, SideCollision side, double newPos)
        {
            switch (side)
            {
                case SideCollision.Top:
                    ball.Position = new Vector2D(ball.Position.X, newPos + ball.Radius);
                    ball.FlipVelocityOnY();
                    break;
                case SideCollision.Left:
                    ball.Position = new Vector2D(newPos + ball.Radius, ball.Position.Y);
                    ball.FlipVelocityOnX();
                    break;
                case SideCollision.Right:
                    ball.Position = new Vector2D(newPos - ball.Radius, ball.Position.Y);
                    ball.FlipVelocityOnX();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Process the ball collision with the bar.
        /// </summary>
        /// <param name="ball">The ball to process</param>
        /// <param name="bar">The bar to process</param>
        public void Process(Ball ball, Bar bar)
        {
            Vector2D oldPos = ball.Position;
            ball.Position = new Vector2D(oldPos.X, oldPos.Y - bar.Height / 2);
            ball.FlipVelocityOnY();
            double distX = ball.Position.OrizDist(bar.Position) / (bar.Width / 2);
            Vector2D oldSpeed = ball.Speed;
            ball.Speed = new Vector2D(distX * SCALE_SPEED, oldSpeed.Y);
        }

        /// <summary>
        /// Process the ball collision with an object (brick or bar).
        /// Flip the speed of the ball.
        /// </summary>
        /// <param name="ball">The ball to process</param>
        /// <param name="brick">The brick to process</param>
        public void Process(Ball ball, Brick brick)
        {
            double distY = ball.Position.VertDist(brick.Position);
            Vector2D oldPos = ball.Position;
            if (System.Math.Abs(distY) > brick.BoundingBox.Height / 2)
            {
                if (distY > 0)
                {
                    ball.Position = new Vector2D(oldPos.X, oldPos.Y + ball.Radius / 2);
                }
                else
                {
                    ball.Position = new Vector2D(oldPos.X, oldPos.Y - ball.Radius / 2);
                }
                ball.FlipVelocityOnY();
            }
            else
            {
                double distX = ball.Position.OrizDist(brick.Position);
                if (distX > 0)
                {
                    ball.Position = new Vector2D(oldPos.X + ball.Radius / 2, oldPos.Y);
                }
                else
                {
                    ball.Position = new Vector2D(oldPos.X - ball.Radius / 2, oldPos.Y);
                }
                ball.FlipVelocityOnX();
            }
        }
    }
}
