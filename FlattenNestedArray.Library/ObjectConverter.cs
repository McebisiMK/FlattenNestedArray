using FlattenNestedArray.Library.Exceptions;
using FlattenNestedArray.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.Library
{
    public class ObjectConverter : IObjectConverter
    {
        public int ConvertObject(object arrayValue)
        {
            var number = 0;
            try
            {
                number = Convert.ToInt32(arrayValue);
            }
            catch (FormatException)
            {
                throw new InvalidInputException(arrayValue);
            }

            return number;
        }
    }
}
