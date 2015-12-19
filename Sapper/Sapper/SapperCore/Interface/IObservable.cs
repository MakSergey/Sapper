using SapperCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Interface
{
    public interface IObservable
    {
        void AddObserver(int i, int j);
        void NotifyObservers(int[] G);
    }
}
