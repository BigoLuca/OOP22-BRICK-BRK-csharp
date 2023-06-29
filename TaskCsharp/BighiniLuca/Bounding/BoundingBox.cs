using Common;

namespace BighiniLuca.Bounding
{
    /// <summary>
    /// An interface to model the object's bounding.
    /// </summary>
    public interface BoundingBox
    {
        /// <summary>
        /// Gets a 2D point.
        /// </summary>
        /// <returns>A 2D point</returns>
        Vector2D GetP2d();

        /// <summary>
        /// Sets a 2D point.
        /// </summary>
        /// <param name="pos">A 2D point</param>
        void SetP2d(Vector2D pos);

        /// <summary>
        /// Checks if the object is colliding with another bounding box object.
        /// </summary>
        /// <param name="obj">Bounding box object</param>
        /// <returns>True if the two objects are colliding, false otherwise</returns>
        bool IsCollidingWith(BoundingBox obj);
    }
}
