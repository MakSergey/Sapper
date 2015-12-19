using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Abstract
{
    public abstract class Factory
    {
        public Cell letCell(int type)
        {
            Cell Cell = null;
            Cell = GetCell(type);
            return Cell;
        }
        public abstract Cell GetCell(int type);
    }
}
