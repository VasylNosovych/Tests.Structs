using System;
using Structs.PersonDir;

namespace Structs.Parsers
{
    /// <summary>
    /// Class, containing methods to parse <see cref="Person"/> data
    /// </summary>
    public class PersonParser
    {
        /// <summary>
        /// Method to parse the <see cref="string"/> to <see cref="Person.Age"/> value
        /// </summary>
        /// <param name="ageStr">Parameter with age information</param>
        /// <returns>Parsed age value</returns>
        public ushort ParseAge(string ageStr)
        {
            if (!UInt16.TryParse(ageStr, out ushort age))
                throw new FormatException(string.Format(PersonException.PARSE_ERROR, PersonException.AGE_LABEL, ageStr));
            return age;
        }

        /// <summary>
        /// Method to parse the value to compare <see cref="Person.Age"/> with
        /// </summary>
        /// <param name="nStr">string parameter with n data</param>
        /// <returns>Parsed value</returns>
        public uint Parse_n(string nStr)
        {
            if (!UInt32.TryParse(nStr, out uint n))
                throw new FormatException(string.Format(PersonException.PARSE_ERROR, PersonException.n_LABEL, nStr));            
            return n;
        }
    }
}