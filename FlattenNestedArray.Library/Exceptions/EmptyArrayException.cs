using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.Library.Exceptions
{
    class EmptyArrayException : Exception
    {
        private static readonly string message = "Given array contains no elements";
        public EmptyArrayException() : base(message)
        {
        }
    }
}
