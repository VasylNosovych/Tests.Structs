using System;
using System.Runtime.Serialization;

namespace Structs.RectangleDir
{
    /// <summary>
    /// Custom exception to handle business-logical exceptions of <see cref="Rectangle"/>
    /// Inherited from <see cref="Exception"/>
    /// </summary>
    [Serializable]
    public class RectangleException : Exception
    {
        #region Rectangle's properties labels
        /// <summary>
        /// x-coordinate string to insert into error messages
        /// </summary>
        public const string X_LABEL = "Abscissa";

        /// <summary>
        /// y-coordinate string to insert into error messages
        /// </summary>
        public const string Y_LABEL = "Ordinate";

        /// <summary>
        /// string of width dimention to insert into error messages
        /// </summary>
        public const string WIDTH_LABEL = "Width";

        /// <summary>
        /// string of height dimention to insert into error messages
        /// </summary>
        public const string HEIGHT_LABEL = "Height";
        #endregion

        #region Error messages
        /// <summary>
        /// Predefined error message in case of invalid string format to parse <see cref="Rectangle.X"/> or <see cref="Rectangle.Y"/>
        /// </summary>
        /// <remarks>
        /// Use <see cref="string.Format(string, object, object)"/> to add the string with coordinate label 
        /// (<see cref="X_LABEL"/> or <see cref="Y_LABEL"/>)
        /// and then the string with coordinate data
        /// </remarks>
        public const string COORD_PARSE_ERROR = "Can't parse {0} coordinate: '{1}' ";

        /// <summary>
        /// Predefined error message in case when coordinate value is out of range
        /// </summary>
        /// <remarks>
        /// Use <see cref="String.Format(string, object)"/> to add the string with coordinate label
        /// (<see cref="X_LABEL"/> or <see cref="Y_LABEL"/>)
        /// </remarks>
        public const string COORD_OUT_OF_RANGE = "{0} coordinate value is out of range";

        /// <summary>
        /// Predefined error message in case of invalid string format to parse <see cref="Rectangle.Width"/> or <see cref="Rectangle.Height"/>
        /// </summary>
        /// <remarks>
        /// Use <see cref="string.Format(string, object, object)"/> to add the string with dimention label 
        /// (<see cref="WIDTH_LABEL"/> or <see cref="HEIGHT_LABEL"/>)
        /// and then the string with dimention data
        /// </remarks>
        public const string DIMENTION_PARSE_ERROR = "Can't parse {0} dimention value: '{1}' ";

        /// <summary>
        /// Predefined error message in case when dimention value is out of range
        /// </summary>
        /// <remarks>
        /// Use <see cref="String.Format(string, object)"/> to add the string with dimention label
        /// (<see cref="WIDTH_LABEL"/> or <see cref="HEIGHT_LABEL"/>)
        /// </remarks>
        public const string DIMENTION_OUT_OF_RANGE = "Rectangle's {0} value is out of range ";
        #endregion

        /// <summary>
        /// Predefined error message for case when <see cref="Rectangle.Width"/> or <see cref="Rectangle.Height"/> is negative
        /// </summary>
        public const string INVALID_DIMENTION = "Invalid rectangle's dimention: {0} can't be zero or negative";

        /// <summary>
        /// Predefined error message for case when rectangle's perimeter (<see cref="Rectangle.Perimeter"/> method) is out of range
        /// </summary>
        public const string PERIMETER_OUT_OF_RANGE = "Can't calculate perimeter: out of range value";

        /// <summary>
        /// Default constructor
        /// </summary>
        public RectangleException() : base() { }

        /// <summary>
        /// Constructor with error message inserted
        /// </summary>
        /// <param name="message">Error message</param>
        public RectangleException(string message) : base(message) { }

        /// <summary>
        /// Constructor with error message and inner exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public RectangleException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor, responsible for exception serialization
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        public RectangleException(SerializationInfo info, StreamingContext context) : base (info, context) { }
    }
}
