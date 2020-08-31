namespace Structs.RectangleDir.Interfaces
{
    /// <summary>
    /// Interface with information about the dimentions of geometrical figures with two sides
    /// </summary>
    public interface ISize
    {
        /// <summary>
        /// Figure's width
        /// </summary>
        double Width { get; set; }
        
        /// <summary>
        /// Figure's height
        /// </summary>
        double Height { get; set; }

        /// <summary>
        /// Method to calculate the figure's perimeter
        /// </summary>
        /// <returns>Figure's perimeter</returns>
        double Perimeter();
    }
}
