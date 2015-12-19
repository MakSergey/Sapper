using SapperCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Interface
{
    public interface IObserver
    {
        void Up(Cell suddenly);
    }
}
