using SapperCore.Abstract;
using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
   public class WonOrLost : Result
    {
       public WonOrLost(IFillPictures imp)
           : base(imp)
    {
    }
    }
}
