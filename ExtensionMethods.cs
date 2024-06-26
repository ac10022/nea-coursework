using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExtensionMethods
{
    public static class ExtensionMethods
    {
        public static List<T> RandomiseList<T>(this List<T> list)
        {
            // generates a new globally universal id to randomise elements by order
            return list.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
