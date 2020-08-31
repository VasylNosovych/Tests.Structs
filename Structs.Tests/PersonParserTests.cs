using NUnit.Framework;
using Structs.Parsers;
using System;

namespace Structs.Tests
{
    public class PersonParserTests
    {
        private PersonParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new PersonParser();
        }

        #region Age
        [Test]
        [TestCase("0", (ushort)0)]
        [TestCase("10", (ushort)10)]
        [TestCase("65535", (ushort)65535)]
        public void ParseAge_GetValidStrings_SuccessfullyParsed(string ageStr, ushort expected)
        {
            double actual = _parser.ParseAge(ageStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("1,79")]
        [TestCase("-1")]
        [TestCase("Abscissa")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void ParseAge_InvalidString_ThrowsFormatException(string ageStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseAge(ageStr)
                , "PersonParser.ParseAge(string) should throw FormatException while trying to parse incorrect string value."
            );
        }
        #endregion

        [Test]
        [TestCase("0", (ushort)0)]
        [TestCase("10", (ushort)10)]
        [TestCase("65535", (ushort)65535)]
        public void Parse_n_GetValidStrings_SuccessfullyParsed(string nStr, ushort expected)
        {
            double actual = _parser.ParseAge(nStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("1,79")]
        [TestCase("-1")]
        [TestCase("Abscissa")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void Parse_n_InvalidString_ThrowsFormatException(string nStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseAge(nStr)
                , "PersonParser.Parse_n(string) should throw FormatException while trying to parse incorrect string value."
            );
        }
    }
}
