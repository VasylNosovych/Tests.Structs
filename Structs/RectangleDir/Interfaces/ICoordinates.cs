namespace Structs.RectangleDir.Interfaces
{
    /// <summary>
    /// Interface with information about the coordinates in 2D-plane
    /// </summary>
    public interface ICoordinates
    {
        /// <summary>
        /// Abscissa axis coordinate
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// Ordinate axis coordinate
        /// </summary>
        double Y { get; set; }
    }
}
