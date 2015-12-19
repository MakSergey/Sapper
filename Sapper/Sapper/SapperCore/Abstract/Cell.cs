using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Abstract
{
    public abstract class Cell : IObserver
    {
       public bool open = false;
       public int status {get; set;}
       public ICellPaint CellPaint { get; set; }
       public Cell (ICellPaint CellPaint, int status)
       {
           this.status = status;
           this.CellPaint = CellPaint;
       }

       public abstract void Up(Cell suddenly);

    }
}
