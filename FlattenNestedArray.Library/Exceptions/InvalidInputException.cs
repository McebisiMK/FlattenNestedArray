using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.Library.Exceptions
{
    class InvalidInputException : Exception
    {
        private static readonly string message = "is not convertible to number";
        public InvalidInputException(object input):base($"{input} {message}")
        {
        }
    }
}
