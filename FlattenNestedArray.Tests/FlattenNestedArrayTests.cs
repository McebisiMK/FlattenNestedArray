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

        private NestedArray CreateNestedArray()
        {
            return new NestedArray(new ObjectConverter());
        }
    }
}
