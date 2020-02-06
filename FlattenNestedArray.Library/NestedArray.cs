using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FlattenNestedArray.Library.Exceptions;
using FlattenNestedArray.Library.Interfaces;

namespace FlattenNestedArray.Library
{
    public class NestedArray : INestedArray
    {
        private List<int> flattenArray;
        private readonly IObjectConverter _objectConverter;

        public NestedArray(IObjectConverter objectConverter)
        {
            _objectConverter = objectConverter;
            flattenArray = new List<int>();
        }

        public int[] GetFlattenArray(IEnumerable<object> nestedArray)
        {
            if (!nestedArray.Any())
                throw new EmptyArrayException();

            var flattenArray = CreateFlattenArray(nestedArray);

            return flattenArray.ToArray();
        }

        private List<int> CreateFlattenArray(IEnumerable<object> nestedArray)
        {
            foreach (var arrayValue in nestedArray)
            {
                if (arrayValue.GetType().IsArray)
                {
                    var innerArray = ((IEnumerable)arrayValue).Cast<object>().Select(x => x as object).ToArray();
                    CreateFlattenArray(innerArray);
                }
                else
                {
                    var value = _objectConverter.ConvertObject(arrayValue);
                    flattenArray.Add(value);
                }
            }

            return flattenArray;
        }
    }
}