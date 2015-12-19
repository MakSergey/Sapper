/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Sapper"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using SapperCore.Abstract;
using SapperCore.Concrete;
using System;

namespace Sapper.ViewModel
{
    public class ViewModelLocator
    {
        private int row { get; set; }
        private int column { get; set; }

        public ViewModelLocator()
        {
        }

        public MainViewModel Main
        {
            get
            {
                Messenger.Default.Register<string>(this, Convert—oordinates);
                return new MainViewModel(row, column);
            }
        }

        public void Convert—oordinates(string —oordinates)
        {
            string[] mas_—oordinates = new string[2];
            mas_—oordinates = —oordinates.Split(' ');
            int i = Convert.ToInt32(mas_—oordinates[0]);
            int j = Convert.ToInt32(mas_—oordinates[1]);
            this.row = i;
            this.column = j;
        }

        public BeginViewModel Begin
        {
            get
            {
                return new BeginViewModel(row,column);
            }
        }
        public WinnerViewModel Winner
        {
            get
            {
                return new WinnerViewModel();
            }
        }
        public LoserViewModel Loser
        {
            get
            {
                return new LoserViewModel();
            }
        }

        public static void Cleanup()
        {
        }
    }
}