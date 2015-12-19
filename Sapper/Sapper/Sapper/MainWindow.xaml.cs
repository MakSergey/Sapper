using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Sapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :MetroWindow
    {
        public static MainWindow Instance;
        public Button[,] buttons { get; set; }
        Binding myOpenCell = new Binding("OpenCell");

        public MainWindow()
        { 
          
            InitializeComponent();
            Instance = this;
            СreateButtonfield(GameField.Rows, GameField.Columns);
        }


        private void СreateButtonfield(int row, int column)
        {
            if (GameField.Children.Count > 0)
                GameField.Children.Clear();
            Button[,] buttons = CreateButtons(row, column);
            AddToGameField(buttons, row, column);
        }


        private Button[,] CreateButtons(int row, int column)
        {
            buttons = new Button[row, column];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Tag = new Point(i + 1, j + 1);
                    buttons[i, j].Click += СoordinatesSave;
                    buttons[i, j].SetBinding(Button.CommandProperty, myOpenCell);
                    buttons[i, j].Width = 40d;
                    buttons[i, j].Content = null;
                    buttons[i, j].MouseRightButtonDown += Marck;
                    buttons[i, j].Margin = new Thickness(1d);
                    buttons[i, j].Background = new SolidColorBrush(Colors.AliceBlue);

                }
            return buttons;
        }


        private void СoordinatesSave(object sender, EventArgs e)
        {
            int[] Сoordinates = { Convert.ToInt32(((Point)((Button)sender).Tag).X), Convert.ToInt32(((Point)((Button)sender).Tag).Y) };
            Messenger.Default.Send<int[]>(Сoordinates);
            Messenger.Default.Register<List<string>>(this, OpenBox);
        }



        public void OpenBox(List<string> ListOfOpen)
        {
            for (int i = 0; i < (ListOfOpen.LongCount<string>()); i++)
           {
         
               string[] mas_s = new string[3];
               mas_s = ListOfOpen[i].Split(' ');
               int i1 = Convert.ToInt32(mas_s[1]);
               int j = Convert.ToInt32(mas_s[2]);
               buttons[i1-1, j-1].Content = mas_s[0];
            }
        }
       

        private void Marck(object sender, EventArgs e)
        {
           string s = Convert.ToString( ((Button)sender).Content);
           if ((s != "?") && (((Button)sender).Content==null))
           {
               ((Button)sender).Content = '?';
               ((Button)sender).Click -= СoordinatesSave;
           }
           if (s == "?") { ((Button)sender).Click += СoordinatesSave; ((Button)sender).Content = null; }
        }


        private void AddToGameField(Button[,] buttons, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                { GameField.Children.Add(buttons[i, j]); }
            }
        }
    }
}
