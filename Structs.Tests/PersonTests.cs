using NUnit.Framework;
using Structs.PersonDir;
using System.Collections.Generic;

namespace Structs.Tests
{
    public class PersonTests
    {
        private Person _person;
       
        [SetUp]
        public void Setup()
        {
            _person = new Person();
        }

        #region Person properties
        #region Name
        [Test]
        public void Name_SetEmpty_ThrowsPersonException()
        {
            string name = string.Empty;
            Assert.Throws<PersonException>(() => _person.Name = name
            , "Person Name setter should throw PersonException while setting empty string value."
            );
        }

        [Test]
        public void Name_SetNull_ThrowsPersonException()
        {
            string name = null;
            Assert.Throws<PersonException>(() => _person.Name = name
            , "Person Name setter should throw PersonException while setting null value."
            );
        }

        [Test]
        public void Name_SetWhiteSpaceValue_ThrowsPersonException()
        {
            string name = "   ";
            Assert.Throws<PersonException>(() => _person.Name = name
            , "Person Name setter should throw PersonException while setting white spaced value."
            );
        }

        [Test]
        public void Name_SetLowercase_UppercaseIsSet()
        {
            // Arrange
            string name = "vasyl";
            // Act
            _person.Name = name;
            // Assert
            Assert.AreEqual("Vasyl", _person.Name);
        }

        [Test]
        [TestCase("John", "John")]
        [TestCase("Mary", "Mary")]
        [TestCase("X AE A-12", "X AE A-12")]
        [TestCase("N@me", "N@me")]
        [TestCase("Philip 4", "Philip 4")]
        [TestCase("Philip IV", "Philip IV")]
        public void Name_SetValidValue_IsSuccessfullySet(string name, string expected)
        {
            _person.Name = name;
            Assert.AreEqual(expected, _person.Name);
        }
        #endregion

        #region Surname
        [Test]
        public void Surname_SetEmpty_ThrowsPersonException()
        {
            string surname = string.Empty;
            Assert.Throws<PersonException>(() => _person.Surname = surname
            , "Person Surname setter should throw PersonException while setting empty string value."
            );
        }

        [Test]
        public void Surname_SetNull_ThrowsPersonException()
        {
            string surname = null;
            Assert.Throws<PersonException>(() => _person.Surname = surname
            , "Person Surname setter should throw PersonException while setting null value."
            );
        }

        [Test]
        public void Surname_SetWhiteSpaceValue_ThrowsPersonException()
        {
            string surname = "   ";
            Assert.Throws<PersonException>(() => _person.Surname = surname
            , "Person Surname setter should throw PersonException while setting white spaced value."
            );
        }

        [Test]
        public void Surname_SetLowercase_UppercaseIsSet()
        {
            // Arrange
            string surname = "nosovych";
            // Act
            _person.Surname = surname;
            // Assert
            Assert.AreEqual("Nosovych", _person.Surname);
        }

        [Test]
        [TestCase("Smith", "Smith")]
        [TestCase("Jane", "Jane")]
        [TestCase("1Surn@me", "1Surn@me")]
        public void Surname_SetValidValue_IsSuccessfullySet(string surname, string expected)
        {
            _person.Surname = surname;
            Assert.AreEqual(expected, _person.Surname);
        }
        #endregion

        #region Age
        [Test]
        public void Age_SetMoreThanMaxAllowed_ThrowsPersonException()
        {
            ushort age = Person.MAX_AGE_VALUE + 1;
            Assert.Throws<PersonException>(() => _person.Age = age
            , $"Person Age setter should throw PersonException while setting age which is more than maximum allowed value ({Person.MAX_AGE_VALUE})."
            );
        }
        #endregion
        #endregion

        #region Person ctor
        [Test]
        [TestCase("", "Nosovych", (ushort)20)]
        [TestCase(" ", "Nosovych", (ushort)20)]
        [TestCase(null, "Nosovych", (ushort)20)]
        [TestCase("Vasyl", "", (ushort)20)]
        [TestCase("Vasyl", " ", (ushort)20)]
        [TestCase("Vasyl", null, (ushort)20)]
        [TestCase("", "", (ushort)20)]
        [TestCase(" ", " ", (ushort)20)]
        [TestCase(null, null, (ushort)20)]
        [TestCase("Vasyl", "Nosovych", (ushort)(Person.MAX_AGE_VALUE + 1))]
        [TestCase(null, null, (ushort)(Person.MAX_AGE_VALUE + 1))]
        public void Ctor_CreateWithInvalidValues_ThrowsPersonException(string name, string surname, ushort age)
        {
            Assert.Throws<PersonException>(() => _person = new Person(name, surname, age)
            , $"Person constructor should throw PersonException while creating the object with invalid data."
            );
        }

        [Test]
        public void Ctor_CreateWithValidValues_SuccessfullyCreated()
        {
            foreach (var (person, expected) in validPersonCreationData())
            {
                Assert.AreEqual(person, expected);
            }
        }
        #endregion

        #region Person methods
        [Test]
        public void CheckAge_ReturnsRespectiveInfoString()
        {
            foreach ((string actual, string expected) in ageComparisonData())
            {
                Assert.AreEqual(expected, actual);
            }
        }
        #endregion


        #region Data
        private IEnumerable<(Person people, Person expected)> validPersonCreationData()
        {
            yield return (
                people: new Person("Vasyl", "Nosovych", 20),
                expected: new Person("Vasyl", "Nosovych", 20));
            yield return (
                people: new Person("john", "Smith ", 40),
                expected: new Person("John", "Smith ", 40));
            yield return (
                people: new Person("Mary", "longage ", Person.MAX_AGE_VALUE),
                expected: new Person("Mary", "Longage ", Person.MAX_AGE_VALUE));
        }

        private IEnumerable<(string actual, string expected)> ageComparisonData()
        {
            ushort age = 20;
            string name = "AgeTestPerson";
            string surname = $"WithAge{20}";
            _person = new Person(name, surname, age);

            uint n = 10;
            yield return (
                actual: _person.CheckAge(n),
                expected: $"{name} {surname} is older than {n}");
            n = 21;
            yield return (
                actual: _person.CheckAge(n),
                expected: $"{name} {surname} is younger than {n}");
            n = age;
            yield return (
                actual: _person.CheckAge(n),
                expected: $"{name} {surname}'s age is {n}");
        }
        #endregion
    }
}