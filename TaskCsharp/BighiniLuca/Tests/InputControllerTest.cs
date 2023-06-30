using NUnit.Framework;

namespace BighiniLuca.Tests
{
    [TestFixture]
    public class InputControllerTest
    {
        [Test]
        public void NotifyMoveLeft()
        {
            // Arrange
            InputController inputController = new InputController();

            // Act
            inputController.NotifyMoveLeft();

            // Assert
            Assert.IsTrue(inputController.IsMoveLeft);

            // Act
            inputController.NoMoveLeft();

            // Assert
            Assert.IsFalse(inputController.IsMoveLeft);
        }

        [Test]
        public void NotifyMoveRight()
        {
            // Arrange
            InputController inputController = new InputController();

            // Act
            inputController.NotifyMoveRight();

            // Assert
            Assert.IsTrue(inputController.IsMoveRight);

            // Act
            inputController.NoMoveRight();

            // Assert
            Assert.IsFalse(inputController.IsMoveRight);
        }
    }
}