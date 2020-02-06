using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.Library.Exceptions
{
    public class EmptyArrayException : Exception
    {
        private static readonly string message = "Given array contains no elements";
        public EmptyArrayException() : base(message)
        {
        }
    }
}
