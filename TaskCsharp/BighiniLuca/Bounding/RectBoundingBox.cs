using Common;

namespace BighiniLuca.Bounding
{
    /// <summary>
    /// Class to model a rectangular shape.
    /// Implements the BoundingBox interface.
    /// </summary>
    public class RectBoundingBox : BoundingBox
    {
        private Vector2D pos;
        private double width, height;

        /// <summary>
        /// RectBoundingBox constructor.
        /// </summary>
        /// <param name="pos">Position</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public RectBoundingBox(Vector2D pos, double width, double height)
        {
            this.pos = pos;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the 2D position.
        /// </summary>
        /// <returns>The 2D position</returns>
        public Vector2D GetP2d()
        {
            return pos;
        }

        /// <summary>
        /// Sets the 2D position.
        /// </summary>
        /// <param name="pos">The 2D position</param>
        public void SetP2d(Vector2D pos)
        {
            this.pos = pos;
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <returns>The width</returns>
        public double GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Sets the width.
        /// </summary>
        /// <param name="width">The width</param>
        public void SetWidth(double width)
        {
            this.width = width;
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <returns>The height</returns>
        public double GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Gets a Vector2D representing the upper-left corner.
        /// </summary>
        /// <returns>A Vector2D representing the upper-left corner</returns>
        public Vector2D GetULCorner()
        {
            return new Vector2D(pos.GetX() - width / 2, pos.GetY() - height / 2);
        }

        /// <summary>
        /// Gets a Vector2D representing the bottom-right corner.
        /// </summary>
        /// <returns>A Vector2D representing the bottom-right corner</returns>
        public Vector2D GetBRCorner()
        {
            return new Vector2D(pos.GetX() + width / 2, pos.GetY() + height / 2);
        }

        /// <summary>
        /// Checks if the rectangle is colliding with another bounding box object.
        /// </summary>
        /// <param name="obj">Bounding box object</param>
        /// <returns>True if the two objects are colliding, false otherwise</returns>
        public bool IsCollidingWith(BoundingBox obj)
        {
            if (obj is RectBoundingBox rect)
            {
                Vector2D ul = GetULCorner();
                Vector2D br = GetBRCorner();
                Vector2D pul = new Vector2D(rect.GetP2d().GetX() - rect.GetWidth() / 2, rect.GetP2d().GetY() - rect.GetHeight() / 2);
                Vector2D pbr = new Vector2D(rect.GetP2d().GetX() + rect.GetWidth() / 2, rect.GetP2d().GetY() + rect.GetHeight() / 2);

                return (ul.GetX() <= pul.GetX()
                        && ul.GetY() <= pul.GetY()
                        && br.GetX() >= pbr.GetX()
                        && br.GetY() >= pbr.GetY())
                        || (ul.GetX() <= pbr.GetX()
                            && ul.GetY() <= pbr.GetY()
                            && br.GetX() >= pul.GetX()
                            && br.GetY() >= pul.GetY());
            }
            else if (obj is CircleBoundingBox circ)
            {
                double circDistX = System.Math.Abs(circ.GetP2d().GetX() - pos.GetX());
                double circDistY = System.Math.Abs(circ.GetP2d().GetY() - pos.GetY());

                if (circDistX > (width / 2 + circ.GetRad()) || circDistY > (height / 2 + circ.GetRad()))
                {
                    return false;
                }

                if (circDistX <= (width / 2) || circDistY <= (height / 2))
                {
                    return true;
                }

                double dx = circDistX - width / 2;
                double dy = circDistY - height / 2;

                return ((dx * dx + dy * dy) <= (circ.GetRad() * circ.GetRad()));
            }

            return false;
        }
    }
}
