using System.Collections.Generic;

namespace DSC.SmartMarket.BusinessLogic.Common
{
    public static class TypeHelper
    {
        public static bool HasValue<T>(this T target)
        {
            return !EqualityComparer<T>.Default.Equals(target, default(T));
        }
    }
}
