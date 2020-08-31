using System;

namespace Structs.PersonDir
{
    /// <summary>
    /// Structure with the person information: name, surname and age
    /// </summary>
    public struct Person
    {
        /// <summary>
        /// Maximum person's age valid value
        /// </summary>
        public const ushort MAX_AGE_VALUE = 200;

        #region Fields
        /// <summary>
        /// Private name field
        /// </summary>
        private string _name;

        /// <summary>
        /// Private surname field
        /// </summary>
        private string _surname;

        /// <summary>
        /// Private age field
        /// </summary>
        private ushort _age;
        #endregion

        #region Properties

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                    throw new PersonException(PersonException.EMPTY_NAME);
                _name = value[0].ToString().ToUpper() + value.Substring(1);
            }
        }

        /// <summary>
        /// Person's surname
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                    throw new PersonException(PersonException.EMPTY_SURNAME);
                _surname = value[0].ToString().ToUpper() + value.Substring(1);
            }
        }

        /// <summary>
        /// Person's age
        /// </summary>
        public ushort Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > Person.MAX_AGE_VALUE)
                    throw new PersonException(string.Format(PersonException.INVALID_AGE, Person.MAX_AGE_VALUE));
                _age = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructor to create person object
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="age">Person's age</param>
        public Person(string name, string surname, ushort age) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        #region Methods
        /// <summary>
        /// Method to check person's age
        /// </summary>
        /// <param name="n">Integer positive value to check person's age</param>
        /// <returns>Formatted string about person's age</returns>
        public string CheckAge(uint n)
        {
            if (n < uint.MinValue || n > uint.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(n), n, PersonException.n_OUT_OF_RANGE);
            if (n == 0)
                throw new ArgumentException(PersonException.n_IS_ZERO, nameof(n));

            if (Age > n)
                return $"{Name} {Surname} is older than {n}";
            else if (Age < n)
                return $"{Name} {Surname} is younger than {n}";
            else
                return $"{Name} {Surname}'s age is {n}";
        }
        #endregion
    }
}