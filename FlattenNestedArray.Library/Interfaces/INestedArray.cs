using System.Collections.Generic;

namespace FlattenNestedArray.Library.Interfaces
{
    public interface INestedArray
    {
        int[] GetFlattenArray(IEnumerable<object> nestedArray);
    }
}