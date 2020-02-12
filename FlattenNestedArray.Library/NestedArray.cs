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
        private List<int> _flattenArray;
        private readonly IObjectConverter _objectConverter;

        public NestedArray(IObjectConverter objectConverter)
        {
            _objectConverter = objectConverter;
            _flattenArray = new List<int>();
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
                    var innerArray = GetNestedArray(arrayValue);
                    CreateFlattenArray(innerArray);
                }
                else
                {
                    var value = _objectConverter.ConvertObject(arrayValue);
                    _flattenArray.Add(value);
                }
            }

            return _flattenArray;
        }

        private object[] GetNestedArray(object arrayValue)
        {
            return
                (
                    ((IEnumerable)arrayValue)
                    .Cast<object>()
                    .Select(x => x as object)
                    .ToArray()
                );
        }
    }
}