using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
    public class PaintLoser : IFillPictures
    {
        public void PaintWalls(System.Drawing.Bitmap image)
        {
            Brush Lost = new TextureBrush(Resource.Loser);
            Graphics graphic = Graphics.FromImage(image);
            graphic.FillRectangle(Lost, 0, 0, 200, 264);
        }
    }
}
