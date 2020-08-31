using Structs.RectangleDir;
using System;

namespace Structs.Parsers
{
    /// <summary>
    /// Class, containing methods to parse <see cref="Rectangle"/> data
    /// </summary>
    public class RectangleParser
    {
        #region Coordinates
        /// <summary>
        /// Method to parse <see cref="string"/> value to <see cref="Rectangle.X"/>
        /// </summary>
        /// <param name="xStr">Parameter with abscissa coordinate information</param>
        /// <returns>Parsed abscissa coordinate value</returns>
        public double ParseAbscissa(string xStr)
        {
            double x;
            if (!double.TryParse(xStr, out x))
            {
                throw new FormatException(string.Format(RectangleException.COORD_PARSE_ERROR, RectangleException.X_LABEL, xStr));
            }
            return x;
        }

        /// <summary>
        /// Method to parse <see cref="string"/> value to <see <see cref="Rectangle.Y"/>
        /// </summary>
        /// <param name="yStr">Parameter with ordinate coordinate information</param>
        /// <returns>Parsed ordinate coordinate value</returns>
        public double ParseOrdinate(string yStr)
        {
            double y;
            if (!double.TryParse(yStr, out y))
            {
                throw new FormatException(string.Format(RectangleException.COORD_PARSE_ERROR, RectangleException.Y_LABEL, yStr));
            }
            return y;
        }

        /// <summary>
        /// Method to parse <see cref="string"/> values to <see cref="Rectangle.X"/> and <see cref="Rectangle.Y"/> value
        /// </summary>
        /// <param name="xStr">Parameter with abscissa coordinate information</param>
        /// <param name="yStr">Parameter with ordinate coordinate information</param>
        /// <returns>Parsed coordinates values</returns>
        public (double x, double y) ParseCoords(string xStr, string yStr)
        {
            double x;
            double y;
            x = ParseAbscissa(xStr);
            y = ParseOrdinate(yStr);
            return (x, y);
        }
        #endregion

        #region Dimentions
        /// <summary>
        /// Method to parse <see cref="string"/> value to <see cref="Rectangle.Width"/>
        /// </summary>
        /// <param name="widthStr">Parameter with width information</param>
        /// <returns>Parsed width value</returns>
        public double ParseWidth(string widthStr)
        {
            double width;
            if (!double.TryParse(widthStr, out width))
            {
                throw new FormatException(string.Format(RectangleException.DIMENTION_PARSE_ERROR, RectangleException.WIDTH_LABEL, widthStr));
            }
            return width;
        }

        /// <summary>
        /// Method to parse <see cref="string"/> value to <see cref="Rectangle.Height"/>
        /// </summary>
        /// <param name="widthStr">Parameter with height information</param>
        /// <returns>Parsed height value</returns>
        public double ParseHeight(string heightStr)
        {
            double height;
            if (!double.TryParse(heightStr, out height))
            {
                throw new FormatException(string.Format(RectangleException.DIMENTION_PARSE_ERROR, RectangleException.HEIGHT_LABEL, heightStr));
            }
            return height;
        }

        /// <summary>
        /// Method to parse <see cref="string"/> values to <see cref="Rectangle.Width"/> and <see cref="Rectangle.Height"/> value
        /// </summary>
        /// <param name="widthStr">Parameter with width information</param>
        /// <param name="heightStr">Parameter with height information</param>
        /// <returns>Parsed dimentions values</returns>
        public (double width, double height) ParseDimentions(string widthStr, string heightStr)
        {
            double width;
            double height;
            width = ParseWidth(widthStr);
            height = ParseHeight(heightStr);
            return (width, height);
        }
        #endregion
    }
}