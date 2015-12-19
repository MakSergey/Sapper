using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace SapperCore.Abstract
{
   public abstract  class Result
    {
       
       protected IFillPictures fillPictures;

       public IFillPictures FillPictures
        {
            set { fillPictures = value; }
        }


        public Result(IFillPictures imp)
        {
            fillPictures = imp;
        }

        Bitmap image = new Bitmap(200, 264);

       public virtual Bitmap Winner()
        {
            Graphics graphic = Graphics.FromImage(image);
            fillPictures.PaintWalls(image);
            Font font = new Font("Vivaldi", 32, FontStyle.Regular);
            graphic.DrawString("Winner!", font, Brushes.Blue, 10, 5);
            return image;
        }
       public virtual Bitmap Loser()
        {
                Graphics graphic = Graphics.FromImage(image);
                fillPictures.PaintWalls(image);
                Font font = new Font("Vivaldi", 32, FontStyle.Regular);
                graphic.DrawString("You Loser", font, Brushes.Blue, 5, 5);
                return image;
        }
    }
}
