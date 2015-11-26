using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.Helpers
{
    class Utility
    {
        public static int IndexWrapAround(int index, int count)
        {
            return ((index % count) + count) % count;
        }
    }
}
