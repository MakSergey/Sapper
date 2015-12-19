using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
    public class PaintWinner : IFillPictures
    {
        public void PaintWalls(System.Drawing.Bitmap image)
        {
            Brush Won = new TextureBrush(Resource.Winner);
            Graphics graphic = Graphics.FromImage(image);
            graphic.FillRectangle(Won, 0, 0, 200, 264);
        }
    }
}
