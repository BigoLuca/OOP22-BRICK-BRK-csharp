using NUnit.Framework;

namespace BighiniLuca.Tests
{
    [TestFixture]
    public class CollisionTest
    {
        [Test]
        public void IsCollidingWith_AnotherRect()
        {
            // Arrange
            Vector2D pos1 = new Vector2D(0, 0);
            double width1 = 5;
            double height1 = 5;
            RectBoundingBox rect1 = new RectBoundingBox(pos1, width1, height1);

            Vector2D pos2 = new Vector2D(2, 2);
            double width2 = 4;
            double height2 = 4;
            RectBoundingBox rect2 = new RectBoundingBox(pos2, width2, height2);

            // Act
            bool isColliding = rect1.IsCollidingWith(rect2);

            // Assert
            Assert.IsTrue(isColliding);
        }

        [Test]
        public void IsNotCollidingWith_AnotherRect()
        {
            // Arrange
            Vector2D pos1 = new Vector2D(0, 0);
            double width1 = 5;
            double height1 = 5;
            RectBoundingBox rect1 = new RectBoundingBox(pos1, width1, height1);

            Vector2D pos2 = new Vector2D(10, 10);
            double width2 = 4;
            double height2 = 4;
            RectBoundingBox rect2 = new RectBoundingBox(pos2, width2, height2);

            // Act
            bool isColliding = rect1.IsCollidingWith(rect2);

            // Assert
            Assert.IsFalse(isColliding);
        }

        [Test]
        public void IsCollidingWith_Circle()
        {
            // Arrange
            Vector2D pos1 = new Vector2D(0, 0);
            double width = 5;
            double height = 5;
            RectBoundingBox rect = new RectBoundingBox(pos1, width, height);

            Vector2D pos2 = new Vector2D(3, 3);
            double radius = 3;
            CircleBoundingBox circle = new CircleBoundingBox(pos2, radius);

            // Act
            bool isColliding = rect.IsCollidingWith(circle);

            // Assert
            Assert.IsTrue(isColliding);
        }

        [Test]
        public void IsNotCollidingWith_Circle()
        {
            // Arrange
            Vector2D pos1 = new Vector2D(0, 0);
            double width = 5;
            double height = 5;
            RectBoundingBox rect = new RectBoundingBox(pos1, width, height);

            Vector2D pos2 = new Vector2D(10, 10);
            double radius = 3;
            CircleBoundingBox circle = new CircleBoundingBox(pos2, radius);

            // Act
            bool isColliding = rect.IsCollidingWith(circle);

            // Assert
            Assert.IsFalse(isColliding);
        }
    }
}
