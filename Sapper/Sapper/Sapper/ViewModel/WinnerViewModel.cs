using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
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
using System.Drawing;
namespace Sapper.ViewModel
{
   public class WinnerViewModel: ViewModelBase
    {
        public Bitmap Image { get; set; }
        public WinnerViewModel()
        { 
            WonOrLost Won = new WonOrLost(new PaintWinner()); 
            Image = Won.Winner(); 
        }

    }
}
