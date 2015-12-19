using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using Sapper;
using SapperCore.Concrete;
using GalaSoft.MvvmLight.Messaging;
using SapperCore.Abstract;
using System.Collections;
using System.Collections.Generic;
namespace Sapper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public int row { get; set; }
        public int column { get; set; }
        public PlayingField GameField { get; set; }
        bool StopPlaying = false;


        public MainViewModel(int row, int column)
        {
            if (row == 0) this.row = 10; else this.row = row;
            if (column == 0) this.column = 10; else this.column = column;
            GameField = new PlayingField();
            GameField.CreateField(this.row, this.column);
            Scor.mincol = Convert.ToString(GameField.mincol);
            Scor.allcol = Convert.ToString(this.row * this.column);
            Scor.WonOrLost = 0;
        }


        private RelayCommand _openhelp;
        public ICommand OpenHelp
        {
            get
            {
                if (_openhelp == null)
                    _openhelp = new RelayCommand(() =>
                    {
                        if (Sapper.View.Help.Instance == null)
                        {
                            Sapper.View.Help win = new Sapper.View.Help();
                            win.Show();
                        }
                        else
                            Sapper.View.Help.Instance.Focus();
                    });

                return _openhelp;
            }
        }


        private RelayCommand _openbegin;
        public ICommand OpenBegin
        {
            get
            {
                if (_openbegin == null)
                    _openbegin = new RelayCommand(() =>
                    {
                        if (Sapper.View.Begin.Instance == null)
                        {
                            Sapper.View.Begin win = new Sapper.View.Begin();
                            win.Show();
                        }
                        else
                            Sapper.View.Begin.Instance.Focus();
                    });

                return _openbegin;
            }
        }


        private RelayCommand _openÑarrier;
        public ICommand OpenÑarrier
        {
            get
            {
                if (_openÑarrier == null)
                    _openÑarrier = new RelayCommand(() =>
                    {
                        if (Sapper.View.Ñarrier.Instance == null)
                        {
                            Sapper.View.Ñarrier win = new Sapper.View.Ñarrier();
                            win.Show();
                        }
                        else
                            Sapper.View.Ñarrier.Instance.Focus();
                    });

                return _openÑarrier;
            }
        }
      
         private RelayCommand _OpenCell;
         public ICommand OpenCell 
         {
             get
             {
                     _OpenCell = new RelayCommand(() =>
                     {
                         bool YouLost = false;
                         Messenger.Default.Register<int[]>(this,GameField.NotifyObservers);
                         List<string> B = new List<string>();
                         int CellsOpen=0;


                         if (StopPlaying == false)
                         {
                         for (int i = 1; i < row + 1; i++)
                             for (int j = 1; j < column + 1; j++)
                             {
                                 if (((GameField.GameField[i, j] != null) && (GameField.GameField[i, j].open == true)))
                                 {
                                     B.Add(GameField.GameField[i, j].CellPaint.Paint((GameField.GameField[i, j].status), i, j)); CellsOpen++;
                                 }
                                 if (((GameField.GameField[i, j].status == -1) && (GameField.GameField[i, j].open == true))) YouLost= true;
                             }}


                         if (YouLost == true)
                         {
                             for (int i = 1; i < row + 1; i++)
                                 for (int j = 1; j < column + 1; j++) 
                                 { B.Add(GameField.GameField[i, j].CellPaint.Paint((GameField.GameField[i, j].status), i, j)); }
                         }


                         if (StopPlaying == false)
                         {
                             Messenger.Default.Send<List<string>>(B);
                         }
                         B.Clear();

                         if (YouLost == true) { Scor.WonOrLost = -1; Sapper.View.Loser win = new Sapper.View.Loser(); win.Show(); StopPlaying = true; }
                         Scor.opencol = Convert.ToString(CellsOpen);
                         if ((CellsOpen == ((row * column) - GameField.mincol)) && (YouLost == false))
                         {
                             Scor.WonOrLost = 1;
                             Sapper.View.Winner win = new Sapper.View.Winner();
                             win.Show();
                             StopPlaying = true;
                         }
                        
                     });
                         
                 return _OpenCell;
             }
         }
    }
}