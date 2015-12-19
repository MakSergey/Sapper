using MahApps.Metro.Controls;
using System;
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
using System.Windows.Shapes;

namespace Sapper.View
{
    /// <summary>
    /// Логика взаимодействия для Begin.xaml
    /// </summary>
    public partial class Begin : MetroWindow
    { 
        public static Begin Instance;
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Instance = null;
        }
        public Begin()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
