//using ...World;

namespace BighiniLuca.Collision
{
    /// <summary>
    /// Interface for all power-ups to modify the world.
    /// </summary>
    public interface IPowerUpApplicator
    {
        /// <summary>
        /// Modifies the world objects with active power-ups.
        /// </summary>
        /// <param name="world">The world to modify.</param>
        void ApplyPowerUp(World world);
    }
}
