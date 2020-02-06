using System;
using System.Collections.Generic;
using System.Linq;
using FlattenNestedArray.Library.Exceptions;
using FlattenNestedArray.Library.Interfaces;

namespace FlattenNestedArray.Library
{
    public class NestedArray : INestedArray
    {
        private readonly IObjectConverter _objectConverter;

        public NestedArray(IObjectConverter objectConverter)
        {
            _objectConverter = objectConverter;
        }

        public List<int> GetFlattenArray(IEnumerable<object> nestedArray)
        {
            if (nestedArray.Any())
            {
                throw new EmptyArrayException();
            }

            var flattenArray = CreateFlattenArray(nestedArray);

            return flattenArray;
        }

        private List<int> CreateFlattenArray(IEnumerable<object> nestedArray)
        {
            var flattenArray = new List<int>();
            foreach (var arrayValue in nestedArray)
            {
                if (arrayValue.GetType().IsArray)
                {
                    var innerArray = arrayValue as object[];
                    CreateFlattenArray(innerArray);
                }
                var value = _objectConverter.ConvertObject(arrayValue);
                flattenArray.Add(value);
            }

            return flattenArray;
        }
    }
}