using System;
using System.Collections.Generic;
using System.Text;

namespace Physike.Math
{
    public abstract class Field<T> where T : struct
    {
        public List<T> Points { get; }
    }
}
