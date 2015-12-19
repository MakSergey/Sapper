using SapperCore.Abstract;
using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
   public class EmptyCell:Cell
    {
        public EmptyCell(ICellPaint CellPaint, int status) : base(CellPaint, status) { }
        public override void Up(Cell suddenly)
        {
            suddenly.open = true;
        }

    }
}
