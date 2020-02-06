using System.Collections.Generic;

namespace FlattenNestedArray.Library.Interfaces
{
    public interface INestedArray
    {
        List<int> GetFlattenArray(IEnumerable<object> nestedArray);
    }
}