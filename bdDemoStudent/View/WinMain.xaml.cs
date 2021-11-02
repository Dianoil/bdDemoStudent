using bdDemoStudent.Class;
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

namespace bdDemoStudent.View
{
    public partial class WinMain : Window
    {
        public enum pageDemo
        { 
            PageAdmin = 1,
            PageUser
        }
        public DemoBdStudent1Entities bd_wpf = new DemoBdStudent1Entities();
        public WinMain()
        {
            InitializeComponent();
            //configSt = new ConfigSt(this);
            WinLogin winLogin = new WinLogin();
            winLogin.ShowDialog();
            try
            {
                switch (Helper.users.Roles.Id)
                {
                    case (int)pageDemo.PageAdmin:
                        Statistic.Visibility = Visibility.Visible;
                        OpenPageDemo(pageDemo.PageAdmin);
                        Helper.user = 1;
                        break;
                    case (int)pageDemo.PageUser:
                        OpenPageDemo(pageDemo.PageUser);
                        break;
                }
            }
            catch
            {
                Close();
            }
        }
        public void OpenPageDemo(pageDemo page)
        {
            switch (page)
            {
                case pageDemo.PageUser:
                    FrameMainDemo.Navigate(new PageUser(this));
                    break;
                case pageDemo.PageAdmin:
                    FrameMainDemo.Navigate(new PageAdmin(this));
                    break;
            }
        }

        private void endWin(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Helper.ActiveAdd();
        }
        private void CheckMenu(object sender, RoutedEventArgs e)
        {
            if (menuCheck.IsCheckable == true)
            {
                MessageBox.Show("Элемент выбран","Информация",MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void CheckMenu1(object sender, RoutedEventArgs e)
        { 
        }
        private void endWin1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Activ(object sender, RoutedEventArgs e)
        {
            WinActiv winActiv = new WinActiv();
            var loc = this.PointToScreen(new Point(0, 0));
            winActiv.Left = loc.X;
            winActiv.Top = loc.Y = 60;
            winActiv.ShowDialog();
        }
        private void Profil(object sender, RoutedEventArgs e)
        {
            WinProfil winProfil = new WinProfil(this);
            winProfil.ShowDialog();
        }
        private void Click_Check1(object sender, RoutedEventArgs e)
        {

            FrameMainDemo.Refresh();

        }
    }
}
