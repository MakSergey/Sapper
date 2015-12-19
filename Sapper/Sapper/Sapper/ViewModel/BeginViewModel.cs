using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using GalaSoft.MvvmLight.Messaging;

namespace Sapper.ViewModel
{
   public class BeginViewModel : ViewModelBase
    {
       public int row { get; set; }
       public int column { get; set; }  
       public BeginViewModel(int row, int column) 
       {
           if (row == 0) this.row = 10; else this.row =  row;
           if (column == 0) this.column = 10; else this.column = column;
       }
       private RelayCommand _newGame;
       public ICommand newGame
                {
             get
             {
                     _newGame = new RelayCommand(() =>
                     {

                         string Сoordinates = Convert.ToString(row) + ' ' + Convert.ToString(column);
                         Messenger.Default.Send<string>(Сoordinates);
                         Messenger.Reset();
                         Sapper.MainWindow.Instance.Close();
                         Sapper.MainWindow win = new Sapper.MainWindow();
                         win.Show();
                         Sapper.View.Begin.Instance.Close();
                     });

                 return _newGame;
             }
         }
    }
}
