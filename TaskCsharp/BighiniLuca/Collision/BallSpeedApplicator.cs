using BighiniLuca.Collision;
//using ...World;

namespace BighiniLuca.Collision
{
    /// <summary>
    /// Class to apply speed powerUp to Ball.
    /// Implements the PowerUpApplicator interface.
    /// </summary>
    public class BallSpeedApplicator : PowerUpApplicator
    {
        private const double DELTA = 1.5;
        private bool bonus;

        /// <summary>
        /// Ball Speed constructor.
        /// </summary>
        /// <param name="bonusToSet">If increase or decrease the Ball speed</param>
        public BallSpeedApplicator(bool bonusToSet)
        {
            bonus = bonusToSet;
        }

        /// <summary>
        /// Applies the power-up to the world.
        /// </summary>
        /// <param name="world">The game world</param>
        public void ApplyPowerUp(World world)
        {
            double acceleration = bonus ? DELTA : 1 / DELTA;
            foreach (Ball b in world.GetBalls())
            {
                b.SetSpeed(b.GetSpeed().Mul(acceleration));
            }
        }
    }
}
