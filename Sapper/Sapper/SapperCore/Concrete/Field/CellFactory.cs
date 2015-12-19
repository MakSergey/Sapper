using SapperCore.Abstract;
using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
   public class CellFactory : Factory
    {
       public List<ICellPaint> CellPaint = new List<ICellPaint>();

       public override Cell GetCell(int type)
        {
            if (type == -1)
            {
                if (CellPaint.Find(b => b.GetType() == typeof(landminePaint)) == null)
                {
                    CellPaint.Add(new landminePaint());
                }
                return new landmine(CellPaint.First(p => p.GetType() == typeof(landminePaint)), type);

            }
              else
            {
                if (CellPaint.Find(b => b.GetType() == typeof(EmptyCellPaint)) == null)
                {
                    CellPaint.Add(new EmptyCellPaint());
                }
                return new EmptyCell(CellPaint.First(p => p.GetType() == typeof(EmptyCellPaint)), type);

            }
        }
    }
}
