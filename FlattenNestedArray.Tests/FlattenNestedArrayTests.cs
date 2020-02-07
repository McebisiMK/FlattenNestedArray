using FlattenNestedArray.Library;
using FlattenNestedArray.Library.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.Tests
{
    [TestFixture]
    public class FlattenNestedArrayTests
    {
        [Test]
        public void GetFlattenArray_Given_Empty_Array_Should_Throw_Exception_With_Message()
        {
            //----------------------------Arrange------------------------------------
            var nestedArrayInput = new object[] { };
            var nestedArray = CreateNestedArray();

            //----------------------------Act----------------------------------------
            var actual = Assert.Throws<EmptyArrayException>(() => nestedArray.GetFlattenArray(nestedArrayInput));

            //----------------------------Assert-------------------------------------
            actual.Message.Should().Be("Given array contains no elements");
        }

        [TestCase(new object[] { 1 }, new int[] { 1 })]
        [TestCase(new object[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new object[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void GetFlattenArray_Given_A_Flatten_Array_Should_Return_The_Same_Of_Type_Integer(object[] nestedArrayInput, int[] expectedFlattedArray)
        {
            //----------------------------Arrange------------------------------------
            var nestedArray = CreateNestedArray();

            //----------------------------Act----------------------------------------
            var actual = nestedArray.GetFlattenArray(nestedArrayInput);

            //----------------------------Assert-------------------------------------
            actual.Should().BeEquivalentTo(expectedFlattedArray);
        }

        [TestCase(new object[] { new object[] { 1, 2, 3 }, new object[] { 4, 5, 6 } }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new object[] { new object[] { 1, 2 }, new object[] { 3, 4, 5, 6 }, new object[] { 7, 8, 9, 10, 11 } }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        public void GetFlattenArray_Given_A_Flatten_Nested_Array_With_Only_Array_Should_Return_The_FlattenArray(object[] nestedArrayInput, int[] expectedFlattedArray)
        {
            //----------------------------Arrange------------------------------------
            var nestedArray = CreateNestedArray();

            //----------------------------Act----------------------------------------
            var actual = nestedArray.GetFlattenArray(nestedArrayInput);

            //----------------------------Assert-------------------------------------
            actual.Should().BeEquivalentTo(expectedFlattedArray);
        }

        [TestCase(new object[] { new object[] { 1, new object[] { 2, 3 }, 4 }, new object[] { 5, 6, new object[] { 7, 8, 9 } } }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new object[] { 1, 2, new object[] { 3, 4 }, new object[] { 5, 6, 7 }, new object[] { 8, 9 }, 10, 11 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [TestCase(new object[] { 1, new object[] { 2, new object[] { 3 } }, 4 }, new int[] { 1, 2, 3, 4 })]
        public void GetFlattenArray_Given_A_Flatten_Nested_Array_Where_A_Value_Can_Be_Number_Or_Array_Should_Return_The_FlattenArray(object[] nestedArrayInput, int[] expectedFlattedArray)
        {
            //----------------------------Arrange------------------------------------
            var nestedArray = CreateNestedArray();

            //----------------------------Act----------------------------------------
            var actual = nestedArray.GetFlattenArray(nestedArrayInput);

            //----------------------------Assert-------------------------------------
            actual.Should().BeEquivalentTo(expectedFlattedArray);
        }

        [TestCase(new object[] { new object[] { 1, new object[] { "r", 3 }, 4 }, new object[] { 5, 6, new object[] { 7, 8, 9 } } }, "'r' is not convertible to number")]
        [TestCase(new object[] { 1, "^", new object[] { 3, 4 }, new object[] { 5, 6, 7 }, new object[] { 8, 9 }, 10, 11 }, "'^' is not convertible to number")]
        [TestCase(new object[] { 1, new object[] { 2, new object[] { "#" } }, 4 }, "'#' is not convertible to number")]
        public void GetFlattenArray_Given_A_Flatten_Nested_Array_Where_A_Some_Values_Are_Not_Convertible_To_Number_Should_Return_The_FlattenArray(object[] nestedArrayInput,string expectedErrorMessage)
        {
            //----------------------------Arrange------------------------------------
            var nestedArray = CreateNestedArray();

            //----------------------------Act----------------------------------------
            var actual = Assert.Throws<InvalidInputException>(() => nestedArray.GetFlattenArray(nestedArrayInput));

            //----------------------------Assert-------------------------------------
            actual.Message.Should().Be(expectedErrorMessage);
        }

        private NestedArray CreateNestedArray()
        {
            return new NestedArray(new ObjectConverter());
        }
    }
}
