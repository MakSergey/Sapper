using SapperCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SapperCore.Interface;
using System.Collections;
namespace SapperCore.Concrete 
{

    public class PlayingField : IObservable
    {
       
        public Cell[,] GameField { get; set; }
        public int mincol { get; set; }

      public void CreateField(int row, int column)
       {
            GameField = new Cell[row+2, column+2];
            Factory NeedCell= new CellFactory();
            mincol = Convert.ToInt32((column*row)/7);

            for (int i=0; i <mincol; i++)
            {

                Random n= new Random();
                int r;
                int c;
                bool flag = false;


                do
                {
                    r = n.Next(1, row+1);
                    c = n.Next(1, column+1);
                    if (GameField[r,c]!=null) flag = true; else flag = false;
                } while (flag);
                GameField[r, c] = NeedCell.GetCell(-1);
            }

            int st=0;

            for(int i=1;i<(row+1);i++)
                for (int j = 1;j<(column+1); j++) 
                {                    
                    if (GameField[i, j] == null)
                    { 
                        for(int i1=i-1;i1<(i+2);i1++)
                            for (int j1 = j - 1; j1 <(j + 2); j1++)
                            {
                                if ((i1 == i) && (j1 == j)) continue;
                                if ((GameField[i1, j1]!=null) && (GameField[i1, j1].status == -1)) st++;
                            }
                        GameField[i, j] = NeedCell.GetCell(st);
                    }
                   
                    st=0;
                }
        }

      public void AddObserver(int i, int j)
        {
           
            if ((GameField[i, j] != null) && (GameField[i, j].status != 0) && (GameField[i, j].open == false)) GameField[i, j].Up(GameField[i, j]);

            if ((GameField[i, j] != null) && (GameField[i, j].status == 0) && (GameField[i, j].open == false))
            {
                GameField[i, j].Up(GameField[i, j]);
                AddObserver(i, j - 1);
                AddObserver(i, j + 1);
                AddObserver(i + 1, j);
                AddObserver(i - 1, j);
                AddObserver(i - 1, j - 1);
                AddObserver(i + 1, j + 1);
                AddObserver(i - 1, j + 1);
                AddObserver(i + 1, j - 1);

            }

        }

      public void NotifyObservers(int[] G)
      {
          AddObserver(G[0], G[1]);
        }
    }
}
