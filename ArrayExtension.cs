using System.Collections.Generic;

namespace CSLight
{
    public static class ArrayExtension
    {
        public static bool ContainsKey<T>(this IReadOnlyCollection<T> enumerable, in int index) =>
            index >= 0 && index < enumerable.Count;
    }
}
