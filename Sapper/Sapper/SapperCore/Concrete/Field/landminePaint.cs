using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
    public class landminePaint : ICellPaint
    {

        public string Paint(int st,int i, int j)
        {
            return "БУМ" + " " + Convert.ToString(i) + " " + Convert.ToString(j);
        }
    }
}