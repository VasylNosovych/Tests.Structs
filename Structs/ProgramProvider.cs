using Structs.Parsers;
using Structs.PersonDir;
using Structs.RectangleDir;
using System;
using System.Collections.Generic;

namespace Structs
{
    /// <summary>
    /// Singleton class for setting up the program algorithm. Uses only in Main (<see cref="Program"/>)
    /// </summary>
    /// <remarks>Handling of exceptions is trivial: display error messages and return to the main menu</remarks>
    class ProgramProvider
    {
        /// <summary>
        /// The single instance of singleton
        /// </summary>
        private static ProgramProvider _instance;

        /// <summary>
        /// The only way to create or get the existing object of singleton
        /// </summary>
        /// <returns>The single instance of <see cref="ProgramProvider"/></returns>
        public static ProgramProvider GetInstance()
        {
            if (_instance == null)
                _instance = new ProgramProvider();
            return _instance;
        }

        /// <summary>
        /// Manager of reading from console
        /// </summary>
        private readonly Reader _reader;

        /// <summary>
        /// Manager of <see cref="Person"/>
        /// </summary>
        private readonly PersonParser _personParser;

        /// <summary>
        /// Manager of <see cref="Rectangle"/>
        /// </summary>
        private readonly RectangleParser _rectangleParser;

        /// <summary>
        /// Methods that must be performed after user chooses the respective option: 
        /// <see cref="personManagement()"/>, <see cref="rectangleManagement"/> and <see cref="exit"/>
        /// </summary>
        private delegate void Option();

        /// <summary>
        /// Dictionary with keys and respective options
        /// </summary>
        private Dictionary<ConsoleKey, Option> _options;

        /// <summary>
        /// Private constructor with initializing of fields and filling the options dictionary
        /// </summary>
        private ProgramProvider()
        {
            _reader = Reader.GetInstance();
            _personParser = new PersonParser();
            _rectangleParser = new RectangleParser();
            fillOptionsDict();
        }

        /// <summary>
        /// Joining the actions with the respective keys
        /// </summary>
        void fillOptionsDict()
        {
            _options = new Dictionary<ConsoleKey, Option>();
            _options.Add(ConsoleKey.D1, personManagement);
            _options.Add(ConsoleKey.D2, rectangleManagement);
            _options.Add(ConsoleKey.D3, exit);
        }

        /// <summary>
        /// Performs the action, depending on the key which user has typed
        /// </summary>
        /// <param name="optionChoice">Key, referring to the user's choice</param>
        void performAction(ConsoleKey optionChoice)
        {
            try
            {
                _options[optionChoice]?.Invoke();
            }
            catch
            {
                Console.WriteLine();
                displayError("Please, choose the appropriate option.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Program algorithm
        /// </summary>
        public void Start()
        {
            defaultStyle();
            ConsoleKey key;
            do
            {
                Console.Clear();
                displayHeader("\t Choose which part of program to check: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Person");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Exit");
                defaultStyle();
                Console.WriteLine(" _");
                Console.Write("|_|\b\b");
                key = Console.ReadKey().Key;
                Console.Clear();
                performAction(key);
            }
            while (key != ConsoleKey.D3);
        }

        #region Console styles
        /// <summary>
        /// Setup the console style for headings
        /// </summary>
        /// <param name="header">Text to display</param>
        private void displayHeader(string header)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(header);
            defaultStyle();
        }

        /// <summary>
        /// Setup the console style for displaying the <see cref="Person"/> information
        /// </summary>
        /// <param name="person">Person to display</param>
        private void displayPersonInfo(Person person)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(getPersonInfo(person));
            defaultStyle();
        }

        /// <summary>
        /// Setup the console style for displaying the <see cref="Rectangle"/> information
        /// </summary>
        /// <param name="rectangle">Rectangle to display</param>
        private void displayRectangleInfo(Rectangle rectangle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(getRectangleInfo(rectangle));
            defaultStyle();
        }

        /// <summary>
        /// Setup the console style for displaying error messages
        /// </summary>
        /// <param name="errorMessage">Text of error message</param>
        private void displayError(string errorMessage)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(errorMessage);
            defaultStyle();
        }

        /// <summary>
        /// Setup the console style for displaying the information about successfull result of the option
        /// </summary>
        /// <param name="successMessage">Text of the message to display</param>
        private void displaySuccess(string successMessage)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(successMessage);
            defaultStyle();
        }

        /// <summary>
        /// Setup the default console style
        /// </summary>
        private void defaultStyle()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region Options
        /// <summary>
        /// Perform the <see cref="Person"/> management
        /// </summary>
        private void personManagement()
        {
            displayHeader("\t Please, input new person's data: ");
            try
            {
                (string name, string surname, string ageStr) = _reader.ReadPersonInfo();
                Person person = createPerson(name, surname, ageStr);
                Console.WriteLine();
                displaySuccess("Person successfully created!");
                Console.ReadLine();

                Console.Clear();
                displayPersonInfo(person);
                Console.WriteLine();
                displayHeader(" Now, input the integer value to check person's age: ");
                string nStr = _reader.Read_n();
                uint n = _personParser.Parse_n(nStr);
                Console.WriteLine();
                displaySuccess(person.CheckAge(n));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue:");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Exception innerEx = ex;
                while (innerEx != null)
                {
                    displayError(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Perform the <see cref="Rectangle"/> management
        /// </summary>
        private void rectangleManagement()
        {
            displayHeader("\t Please, input new rectangle's data: ");
            try
            {
                (string x, string y) = _reader.ReadCoords();
                (string width, string height) = _reader.ReadDimentions();
                Rectangle rectangle = createRectangle(x, y, width, height);
                Console.WriteLine();
                displaySuccess("Rectangle successfully created!");
                Console.WriteLine();
                Console.Clear();
                displayHeader("\tNew rectangle:");
                displayRectangleInfo(rectangle);
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue:");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Exception innerEx = ex;
                while (innerEx != null)
                {
                    displayError(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Finish the program
        /// </summary>
        public void exit()
        {
            Console.Clear();
            Console.WriteLine("Bye!");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

        #region Create models
        /// <summary>
        /// Create the <see cref="Person"/> object
        /// All parameters are of type <see cref="string"/>
        /// </summary>
        /// <param name="nameStr">Person's name string</param>
        /// <param name="surnameStr">Person's surname string</param>
        /// <param name="ageStr">Person's age string</param>
        /// <returns></returns>
        public Person createPerson(string nameStr, string surnameStr, string ageStr)
        {
            ushort age = _personParser.ParseAge(ageStr);
            return new Person(nameStr, surnameStr, age);
        }

        /// <summary>
        /// Method to set coordinates and dimentions to <see cref="Rectangle"/> object
        /// </summary>
        /// <param name="xStr">string parameter with x-coordinate data</param>
        /// <param name="yStr">string parameter with y-coordinate data</param>
        /// <param name="widthStr">string parameter with width data</param>
        /// <param name="heightStr">string parameter with height data</param>
        /// <returns>New <see cref="Rectangle"/> object</returns>
        public Rectangle createRectangle(string xStr, string yStr, string widthStr, string heightStr)
        {
            double x;
            double y;
            double width;
            double height;
            (x, y) = _rectangleParser.ParseCoords(xStr, yStr);
            (width, height) = _rectangleParser.ParseDimentions(widthStr, heightStr);
            return new Rectangle(x, y, width, height);
        }
        #endregion

        #region Display models
        /// <summary>
        /// Get all rectangle's information
        /// </summary>
        /// <param name="rectangle">The rectangle object to display</param>
        /// <returns>Formatted string</returns>
        private string getRectangleInfo(Rectangle rectangle)
        {
            return $"Coordinates: ({rectangle.X};{rectangle.Y})\n" +
                   $"Width:  {rectangle.Width}\n" +
                   $"Height: {rectangle.Height}\n" +
                   $"Perimeter: {rectangle.Perimeter()}";
        }

        /// <summary>
        /// Get all person's information
        /// </summary>
        /// <param name="person">Person object to display</param>
        /// <returns>Formatted string</returns>
        private string getPersonInfo(Person person)
        {
            return $"Name:    {person.Name}\n" +
                   $"Surname: {person.Surname}\n" +
                   $"Age: {person.Age}\n";
        }
        #endregion
    }
}