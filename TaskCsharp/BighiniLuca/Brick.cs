using Common;
using BighiniLuca.Bounding;
using System;

namespace BighiniLuca
{
    /// <summary>
    /// Class to model the game object Brick.
    /// Extends GameObjectImpl.
    /// </summary>
    public class Brick : GameObjectImpl<RectBoundingBox>
    {
        public static readonly int BRICKS_COL = 6;
        public static readonly int BRICKS_ROW = 6;

        public static readonly double BRICK_WIDTH = 600 / BRICKS_COL;
        public static readonly double BRICK_HEIGHT = 600 / (BRICKS_ROW * 2);

        private TypePower powerUp { get; private set; }

        /// <summary>
        /// Brick constructor.
        /// </summary>
        /// <param name="pos">The position of the brick</param>
        /// <param name="lifeToSet">The life to set</param>
        public Brick(Vector2D pos, int lifeToSet) 
            : base(lifeToSet, new Vector2D(0, 0), TypeObj.BRICK, new RectBoundingBox(pos, BRICK_WIDTH, BRICK_HEIGHT))
        {
            powerUp = TypePower.NULL;
        }

        /// <summary>
        /// Sets the power-up type.
        /// </summary>
        /// <param name="powerUpToSet">The power-up to set</param>
        public void SetPowerUp(TypePower powerUpToSet) => powerUp = powerUpToSet;
    }
}
