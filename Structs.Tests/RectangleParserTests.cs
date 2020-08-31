using NUnit.Framework;
using Structs.Parsers;
using System;

namespace Structs.Tests
{
    public class RectangleParserTests
    {
        private RectangleParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new RectangleParser();
        }

        #region Coordinates
        [Test]
        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("-10", -10)]
        [TestCase("1,7976931348623157E+308", 1.7976931348623157E+308)]
        [TestCase("-1,7976931348623157E+308", -1.7976931348623157E+308)]
        public void ParseAbscissa_GetValidStrings_SuccessfullyParsed(string xStr, double expected)
        {
            double actual = _parser.ParseAbscissa(xStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("Abscissa")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void ParseAbscissa_InvalidString_ThrowsFormatException(string xStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseAbscissa(xStr)
                , "RectangleParser.ParseAbscissa(string) should throw FormatException while trying to parse incorrect string value."
            );
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("-10", -10)]
        [TestCase("1,7976931348623157E+308", 1.7976931348623157E+308)]
        [TestCase("-1,7976931348623157E+308", -1.7976931348623157E+308)]
        public void ParseOrdinate_GetValidStrings_SuccessfullyParsed(string yStr, double expected)
        {
            double actual = _parser.ParseOrdinate(yStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("Ordinate")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void ParseOrdinate_InvalidString_ThrowsFormatException(string xStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseOrdinate(xStr)
                , "RectangleParser.ParseAbscissa(string) should throw FormatException while trying to parse incorrect string value."
            );
        }

        [Test]
        [TestCase("0", "0", 0, 0)]
        [TestCase("10", "1", 10, 1)]
        [TestCase("-10", "10", -10, 10)]
        [TestCase("1,7976931348623157E+308", "-1,7976931348623157E+308", 1.7976931348623157E+308, -1.7976931348623157E+308)]
        public void ParseCoords_GetValidStrings_SuccessfullyParsed(string xStr, string yStr, double x_expected, double y_expected)
        {
            double x;
            double y;
            (x, y) = _parser.ParseCoords(xStr, yStr);
            Assert.AreEqual(x_expected, x);
            Assert.AreEqual(y_expected, y);
        }

        [Test]
        [TestCase("Abscissa", "Ordinate")]
        [TestCase("10O", "0")]
        [TestCase("1", "@@@")]
        [TestCase("", " ")]
        public void ParseCoords_GetInvalidData_ThrowsFormatException(string xStr, string yStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseCoords(xStr, yStr)
                , "RectangleParser.ParseCoords(string, string) should throw FormatException while parsing invalid string."
            );
        }
        #endregion

        #region Dimentions
        [Test]
        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("-10", -10)]
        [TestCase("1,7976931348623157E+308", 1.7976931348623157E+308)]
        [TestCase("-1,7976931348623157E+308", -1.7976931348623157E+308)]
        public void ParseWidth_GetValidStrings_SuccessfullyParsed(string widthStr, double expected)
        {
            double actual = _parser.ParseWidth(widthStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("Width")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void ParseWidth_InvalidString_ThrowsFormatException(string widthStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseWidth(widthStr)
                , "RectangleParser.ParseWidth(string) should throw FormatException while trying to parse incorrect string value."
            );
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase("10", 10)]
        [TestCase("-10", -10)]
        [TestCase("1,7976931348623157E+308", 1.7976931348623157E+308)]
        [TestCase("-1,7976931348623157E+308", -1.7976931348623157E+308)]
        public void ParseHeight_GetValidStrings_SuccessfullyParsed(string heightStr, double expected)
        {
            double actual = _parser.ParseHeight(heightStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("1.79")]
        [TestCase("Ordinate")]
        [TestCase("10O")]
        [TestCase("1@3")]
        [TestCase("")]
        [TestCase("    ")]
        public void ParseHeight_InvalidString_ThrowsFormatException(string heightStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseHeight(heightStr)
                , "RectangleParser.ParseHeight(string) should throw FormatException while trying to parse incorrect string value."
            );
        }

        [Test]
        [TestCase("0", "0", 0, 0)]
        [TestCase("10", "1", 10, 1)]
        [TestCase("-10", "10", -10, 10)]
        [TestCase("1,7976931348623157E+308", "-1,7976931348623157E+308", 1.7976931348623157E+308, -1.7976931348623157E+308)]
        public void ParseDimentions_GetValidStrings_SuccessfullyParsed(string widthStr, string heightStr, double width_expected, double height_expected)
        {
            double width;
            double height;
            (width, height) = _parser.ParseDimentions(widthStr, heightStr);
            Assert.AreEqual(width_expected, width);
            Assert.AreEqual(height_expected, height);
        }

        [Test]
        [TestCase("Abscissa", "Ordinate")]
        [TestCase("10O", "0")]
        [TestCase("1", "@@@")]
        [TestCase("", " ")]
        public void ParseDimentions_GetInvalidData_ThrowsFormatException(string widthStr, string heightStr)
        {
            Assert.Throws<FormatException>(
                () => _parser.ParseDimentions(widthStr, heightStr)
                , "RectangleParser.ParseDimentions(string, string) should throw FormatException while parsing invalid string."
            );
        }
        #endregion
    }
}
