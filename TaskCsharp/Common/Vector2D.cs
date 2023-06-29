namespace Common
{
    /// <summary>
    /// Classe che rappresenta un vettore bidimensionale.
    /// </summary>
    public class Vector2D
    {
        public double X { get; }
        public double Y { get; }

        /// <summary>
        /// Costruttore della classe Vector2D.
        /// </summary>
        /// <param name="x">La coordinata x</param>
        /// <param name="y">La coordinata y</param>
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Somma un vettore a un altro.
        /// </summary>
        /// <param name="v">Il vettore da sommare</param>
        /// <returns>La nuova posizione</returns>
        public Vector2D Sum(Vector2D v) => new Vector2D(X + v.X, Y + v.Y);

        /// <summary>
        /// Moltiplica un vettore per un valore.
        /// </summary>
        /// <param name="value">Il valore da moltiplicare</param>
        /// <returns>Il nuovo vettore</returns>
        public Vector2D Mul(double value) => new Vector2D(value * X, value * Y);

        /// <summary>
        /// Calcola la distanza orizzontale tra due punti.
        /// </summary>
        /// <param name="xp">Il secondo punto</param>
        /// <returns>La distanza orizzontale tra due punti</returns>
        public double OrizDist(Vector2D xp) => X - xp.X;

        /// <summary>
        /// Calcola la distanza verticale tra due punti.
        /// </summary>
        /// <param name="yp">Il secondo punto</param>
        /// <returns>La distanza verticale tra due punti</returns>
        public double VertDist(Vector2D yp) => Y - yp.Y;
    }
}
