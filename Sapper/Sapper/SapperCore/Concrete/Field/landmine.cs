using SapperCore.Interface;
using SapperCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SapperCore.Concrete
{
    public class landmine : Cell
    {
        public landmine(ICellPaint CellPaint, int status) : base(CellPaint, status) { }
        public override void Up(Cell suddenly)
        {
            suddenly.open = true;
        }

    }
}
