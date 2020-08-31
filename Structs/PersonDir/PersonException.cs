using System;
using System.Runtime.Serialization;

namespace Structs.PersonDir
{
    /// <summary>
    /// Custom exception to handle business-logical exceptions of <see cref="Person"/>
    /// Inherited from <see cref="Exception"/>
    /// </summary>
    [Serializable]
    public class PersonException : Exception
    {
        #region Values labels
        /// <summary>
        /// Age string to insert into error messages
        /// </summary>
        public const string AGE_LABEL = "Age";

        /// <summary>
        /// n string to insert into error messages
        /// </summary>
        public const string n_LABEL = "n";
        #endregion

        #region Error messages
        /// <summary>
        /// Predefined error message in case of invalid string format to parse
        /// </summary>
        /// <remarks>
        /// Use <see cref="string.Format(string, object, object)"/> to add the string with value label 
        /// (<see cref="AGE_LABEL"/> or <see cref="n_LABEL)"/>)
        /// and then the string with value data
        /// </remarks>
        public const string PARSE_ERROR = "Can't parse {0} value: '{1}' ";

        /// <summary>
        /// Predefined error message for case when <see cref="Person.Age"/> is bigger than allowed: <see cref="Person.MAX_AGE_VALUE"/>
        /// </summary>
        public const string INVALID_AGE = "Invalid person's age value: age can't be negative or more than {0} ";

        /// <summary>
        /// Predefined error message for case when <see cref="Person.Name"/> is empty
        /// </summary>
        public const string EMPTY_NAME = "Invalid person's Name value: name can't be empty ";

        /// <summary>
        /// Predefined error message for case when <see cref="Person.Surname"/> is empty
        /// </summary>
        public const string EMPTY_SURNAME = "Invalid person's Surname value: surname can't be empty ";

        /// <summary>
        /// Predefined error message in case when the n value is out of range
        /// </summary>
        public const string n_OUT_OF_RANGE = "n value is out of range ";

        /// <summary>
        /// Predefined error message in case when the n value is zero
        /// </summary>
        public const string n_IS_ZERO = "n value can't be zero ";
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public PersonException() : base() { }

        /// <summary>
        /// Constructor with error message inserted
        /// </summary>
        /// <param name="message">Error message</param>
        public PersonException(string message) : base(message) { }

        /// <summary>
        /// Constructor with error message and inner exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public PersonException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor, responsible for exception serialization
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        public PersonException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}