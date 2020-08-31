using NUnit.Framework;
using Structs.RectangleDir;
using System;
using System.Collections.Generic;

namespace Structs.Tests
{
    public class RectangleTests
    {
        private Rectangle _rectangle;
        [SetUp]
        public void Setup()
        {
            _rectangle = new Rectangle();
        }

        #region Rectangle properties
        #region Width
        [Test]
        public void Rectangle_SetWidthNegative_ThrowsRectangleException()
        {
            double width = -1;

            Assert.Throws<RectangleException>(() =>
            {
                _rectangle.Width = width;
            }
            , "Rectangle Width setter should throw RectangleException while setting negative value."
            );
        }

        [Test]
        public void Rectangle_SetWidthZero_ThrowsRectangleException()
        {
            double width = 0;

            Assert.Throws<RectangleException>(() => _rectangle.Width = width
            , "Rectangle Width setter should throw RectangleException while setting zero value."
            );
        }

        [Test]
        [TestCase(1)]
        [TestCase(10.5d)]
        [TestCase(double.MaxValue)]
        public void Rectangle_SetWidthValidValue_SuccessfullySetted(double value)
        {
            _rectangle.Width = value;
            Assert.AreEqual(value, _rectangle.Width);
        }

        [Test]
        public void Rectangle_SetWidthMoreThanMaxValue_ThrowsArgumentOutOfRangeException()
        {
            double value = double.MaxValue * 2;

            Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.Width = value
            , "Rectangle Width setter should throw ArgumentOutOfRangeException while setting value that is more than type's maximum."
            );
        }
        #endregion

        #region Height
        [Test]
        public void Rectangle_SetHeightNegative_ThrowsRectangleException()
        {
            Rectangle rectangle = new Rectangle();
            double height = -1;

            Assert.Throws<RectangleException>(() =>
            {
                rectangle.Height = height;
            }
            , "Rectangle Height setter should throw RectangleException while setting negative value."
            );
        }

        [Test]
        public void Rectangle_SetHeightZero_ThrowsRectangleException()
        {
            Rectangle rectangle = new Rectangle();
            double height = 0;

            Assert.Throws<RectangleException>(() => rectangle.Height = height
            , "Rectangle Height setter should throw RectangleException while setting zero value."
            );
        }

        [Test]
        [TestCase(1)]
        [TestCase(10.5d)]
        [TestCase(double.MaxValue)]
        public void Rectangle_SetHeightValidValue_SuccessfullySetted(double value)
        {
            _rectangle.Height = value;
            Assert.AreEqual(value, _rectangle.Height);
        }

        [Test]
        public void Rectangle_SetHeightMoreThanMaxValue_ThrowsArgumentOutOfRangeException()
        {
            double value = double.MaxValue * 2;

            Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.Height = value
            , "Rectangle Height setter should throw ArgumentOutOfRangeException while setting value that is more than type's maximum."
            );
        }
        #endregion

        #region x Coordinate
        [Test]
        [TestCase(double.MaxValue * 2)]
        [TestCase(double.MinValue * 2)]
        public void Rectangle_SetXOutOfRangeValue_ThrowsArgumentOutOfRangeException(double value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.X = value
            , "Rectangle X setter should throw ArgumentOutOfRangeException while setting value that is out of type's range."
            );
        }
        #endregion

        #region y Coordinate
        [Test]
        [TestCase(double.MaxValue * 2)]
        [TestCase(double.MinValue * 2)]
        public void Rectangle_SetYOutOfRangeValue_ThrowsArgumentOutOfRangeException(double value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _rectangle.Y = value
            , "Rectangle Y setter should throw ArgumentOutOfRangeException while setting value that is out of type's range."
            );
        }
        #endregion
        #endregion

        #region Rectangle ctor
        [Test]
        [TestCase(0, 0, -10, 10)]
        [TestCase(0, 0, 10, -10)]
        [TestCase(0, 0, 0, 10)]
        [TestCase(0, 0, 10, 0)]
        [TestCase(0, 0, 0, 0)]
        public void Ctor_CreateWithInvalidValues_ThrowsRectangleException(double x, double y, double width, double height)
        {
            Assert.Throws<RectangleException>(
                () => _rectangle = new Rectangle(x, y, width, height)
                , $"Rectangle constructor should throw RectangleException while creating the object with invalid data."
            );
        }

        [Test]
        [TestCase(0, 0, double.MaxValue * 2, 10)]
        [TestCase(0, 0, 10, double.MaxValue * 2)]
        public void Ctor_CreateWithOutOfRangeDimention_ThrowsArgumentOutOfRangeException(double x, double y, double width, double height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _rectangle = new Rectangle(x, y, width, height)
                , $"Rectangle constructor should throw ArgumentOutOfRangeException while creating the object with dimentions that are out of range."
            );
        }

        [Test]
        public void Ctor_CreateWithValidValues_SuccessfullyCreated()
        {
            foreach (var (rectangle, expected) in validRectangleCreationData())
            {
                Assert.AreEqual(rectangle, expected);
            }
        }
        #endregion

        #region Perimeter
        [Test]
        public void Perimeter_OutOfRange_ThrowsRectangleException()
        {
            _rectangle.Width = double.MaxValue;
            _rectangle.Height = 1;
            Assert.Throws<RectangleException>(
                () => _rectangle.Perimeter()
                , "Rectangle.Perimeter() should throw RectangleException when perimeter value is out of range."
            );
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(100, 200)]
        public void Perimeter_ValidResult_IsEqualWithExpected(double width, double height)
        {
            _rectangle.Width = width;
            _rectangle.Height = height;
            double expected = 2 * (width + height);
            Assert.AreEqual(expected, _rectangle.Perimeter());
        }

        [Test]
        public void Perimeter_NotInitializedDimentions_ReturnsZero()
        {
            Rectangle rect = new Rectangle();
            double perimeter = rect.Perimeter();
            Assert.AreEqual(0, perimeter);
        }
        #endregion


        #region Data
        private IEnumerable<(Rectangle rectangle, Rectangle expected)> validRectangleCreationData()
        {
            yield return (
                rectangle: new Rectangle(0, 0, 2, 3),
                expected: new Rectangle(0, 0, 2, 3));
            yield return (
                rectangle: new Rectangle(10, -10, 4, 4),
                expected: new Rectangle(10, -10, 4, 4));
        }
        #endregion
    }
}
