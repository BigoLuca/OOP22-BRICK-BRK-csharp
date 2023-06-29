namespace BighiniLuca
{
    /// <summary>
    /// Controller che tiene traccia degli eventi di input.
    /// </summary>
    public class InputController
    {
        public bool IsMoveLeft { get; private set; }
        public bool IsMoveRight { get; private set; }

        /// <summary>
        /// Notifica lo spostamento a sinistra.
        /// </summary>
        public void NotifyMoveLeft() => IsMoveLeft = true;

        /// <summary>
        /// Annulla lo spostamento a sinistra.
        /// </summary>
        public void NoMoveLeft() => IsMoveLeft = false;

        /// <summary>
        /// Notifica lo spostamento a destra.
        /// </summary>
        public void NotifyMoveRight() => IsMoveRight = true;

        /// <summary>
        /// Annulla lo spostamento a destra.
        /// </summary>
        public void NoMoveRight() => IsMoveRight = false;
    }
}
