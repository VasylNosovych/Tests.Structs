using System;
using Structs.PersonDir;
using Structs.RectangleDir;
using Structs.RectangleDir.Interfaces;

namespace Structs
{
    /// <summary>
    /// Singleton class for reading from console. Uses only in <see cref="ProgramProvider"/>
    /// </summary>
    class Reader
    {
        /// <summary>
        /// The single instance of singleton
        /// </summary>
        private static Reader _instance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private Reader() { }

        /// <summary>
        /// The only way to create or get the existing object of singleton
        /// </summary>
        /// <returns>The single instance of <see cref="Reader"/></returns>
        public static Reader GetInstance()
        {
            if (_instance == null)
                _instance = new Reader();
            return _instance;
        }

        /// <summary>
        /// Read all the data of <see cref="Person"/>
        /// </summary>
        /// <remarks>The instructions which property to read next are displayed directly in this method</remarks>
        /// <returns>String values of <see cref="Person"/> properties</returns>
        public (string name, string surname, string age) ReadPersonInfo()
        {
            string name;
            string surname;
            string ageStr;
            Console.Write("Name:    ");
            name = Console.ReadLine();
            Console.Write("Surname: ");
            surname = Console.ReadLine();
            Console.Write("Age: ");
            ageStr = Console.ReadLine();
            return (name, surname, ageStr);
        }

        /// <summary>
        /// Read the value to compare <see cref="Person.Age"/> with
        /// </summary>
        /// <returns>String value with data about n</returns>
        public string Read_n()
        {
            string nStr;
            Console.Write("n = ");
            nStr = Console.ReadLine();
            return nStr;
        }

        /// <summary>
        /// Read the coordinates of <see cref="ICoordinates"/>: <see cref="Rectangle.X"/> and <see cref="Rectangle.Y"/>
        /// </summary>
        /// <remarks>The instructions which coordinate to read next are displayed directly in this method</remarks>
        /// <returns>String values of <see cref="ICoordinates"/></returns>
        public (string x, string y) ReadCoords()
        {
            string x;
            string y;
            Console.WriteLine("Read coordinates (x,y):");
            Console.Write("x = ");
            x = Console.ReadLine();
            Console.Write("y = ");
            y = Console.ReadLine();
            return (x, y);
        }

        /// <summary>
        /// Read the dimentions of <see cref="ISize"/>: <see cref="Rectangle.Width"/> and <see cref="Rectangle.Height"/>
        /// </summary>
        /// <returns>String values of <see cref="ISize"/></returns>
        public (string width, string height) ReadDimentions()
        {
            string width;
            string height;
            Console.WriteLine("Read dimentions:");
            Console.Write("Width:  ");
            width = Console.ReadLine();
            Console.Write("Height: ");
            height = Console.ReadLine();
            return (width, height);
        }
    }
}