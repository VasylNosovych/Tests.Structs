using Structs.RectangleDir.Interfaces;
using System;

namespace Structs.RectangleDir
{
    /// <summary>
    /// Rectangle figure structure
    /// Implements <see cref="ISize"/> and <see cref="ICoordinates"/>
    /// </summary>
    public struct Rectangle : ISize, ICoordinates
    {
        #region Fields
        /// <summary>
        /// Private field of width
        /// </summary>
        private double _width;

        /// <summary>
        /// Private field of height
        /// </summary>
        private double _height;

        /// <summary>
        /// Private field of abscissa coordinate
        /// </summary>
        private double _x;

        /// <summary>
        /// Private field of ordinate coordinate
        /// </summary>
        private double _y;
        #endregion

        #region Properties
        /// <summary>
        /// Rectangle's width: <see cref="ISize"/> component
        /// </summary>
        public double Width 
        { 
            get { return _width; } 
            set
            {
                if (value <= 0)
                    throw new RectangleException(string.Format(RectangleException.INVALID_DIMENTION, RectangleException.WIDTH_LABEL));
                if (value > double.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                               string.Format(RectangleException.DIMENTION_OUT_OF_RANGE, RectangleException.WIDTH_LABEL));
                _width = value;
            }
        }

        /// <summary>
        /// Rectangle's height: <see cref="ISize"/> component
        /// </summary>
        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                    throw new RectangleException(string.Format(RectangleException.INVALID_DIMENTION, RectangleException.HEIGHT_LABEL));
                if (value > double.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                               string.Format(RectangleException.DIMENTION_OUT_OF_RANGE, RectangleException.HEIGHT_LABEL));
                _height = value;
            }
        }

        /// <summary>
        /// Rectangle's center abscissa coordinate: <see cref="ICoordinates"/> component
        /// </summary>
        public double X
        {
            get { return _x; }
            set
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                                        string.Format(RectangleException.COORD_OUT_OF_RANGE, RectangleException.X_LABEL));
                }
                _x = value;
            }
        }

        /// <summary>
        /// Rectangle's center ordinate coordinate: <see cref="ICoordinates"/> component
        /// </summary>
        public double Y
        {
            get { return _y; }
            set
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                                        string.Format(RectangleException.COORD_OUT_OF_RANGE, RectangleException.Y_LABEL));
                }
                _y = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructor to create rectangle object
        /// </summary>
        /// <param name="x">Abscissa coordinate</param>
        /// <param name="y">Ordinate coordinate</param>
        /// <param name="width">Width dimention value</param>
        /// <param name="height">Height dimention value</param>
        public Rectangle(double x, double y, double width, double height) : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        #region Methods
        /// <summary>
        /// Rectangle's perimeter: realization of <see cref="ISize.Perimeter"/>
        /// </summary>
        /// <returns>Rectangle's perimeter</returns>
        public double Perimeter()
        {
            double perimeter = 2 * (Width + Height);
            if (perimeter > double.MaxValue)
                throw new RectangleException(RectangleException.PERIMETER_OUT_OF_RANGE);
            return perimeter;
        }
        #endregion
    }
}