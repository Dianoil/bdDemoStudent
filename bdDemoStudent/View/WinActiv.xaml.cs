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
    /// <summary>
    /// Логика взаимодействия для WinActiv.xaml
    /// </summary>
    public partial class WinActiv : Window
    {
        public WinActiv()
        {
            InitializeComponent();
        }
        private void Action(object sender, RoutedEventArgs e)
        {
            var men = Helper.demoBd.Activrtes.Where(i => i.Id > 0).ToList();
            GriAction.ItemsSource = men;
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            foreach (var i in GriAction.ItemsSource)
                Helper.demoBd.Activrtes.Remove(i as Activrtes);
            Helper.demoBd.SaveChanges();
            this.Close();
        }
    }
}
