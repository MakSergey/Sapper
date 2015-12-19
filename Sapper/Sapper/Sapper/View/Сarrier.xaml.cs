using SapperCore.Concrete;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace Sapper.View
{
    /// <summary>
    /// Логика взаимодействия для Сarrier.xaml
    /// </summary>
    public partial class Сarrier : Window
    {
         public static Сarrier Instance;

         public Сarrier()
        {
            InitializeComponent();
            Instance = this;
            AuthBrowser.Navigate(DepartmentMail.url);  
            
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Instance = null;
        }


        private void AuthBrowser_LoadedCompleted(object sender, NavigationEventArgs e)
        {
            string url = AuthBrowser.Source.ToString();
            string l = url.Split('#')[1];
            if (l[0] == 'a')
            {
                DepartmentMail.token = l.Split('&')[0].Split('=')[1];
                DepartmentMail.id = l.Split('=')[3];
                DepartmentMail.IsAuthorized = true;
            }

            if (DepartmentMail.IsAuthorized == true)
            {
                DepartmentMail c = new DepartmentMail();
                c.Send();
            }
        }
           
            
        }
    }


