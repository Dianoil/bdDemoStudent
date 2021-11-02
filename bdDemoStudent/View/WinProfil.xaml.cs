using bdDemoStudent.Class;
using Microsoft.Win32;
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
    public partial class WinProfil : Window
    {

        WinMain pw;
        public WinProfil(WinMain winMain)
        {
            var yearsArr = Enumerable.Range(1921, DateTime.Now.Year);
            pw = winMain;
            InitializeComponent();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            Helper.demoBd.SaveChanges();
            this.Close();
            if (Helper.user == 0)
            {
                pw.FrameMainDemo.Navigate(new PageUser(pw));
            }
            else
            {
                pw.FrameMainDemo.Navigate(new PageAdmin(pw));
            }
        }
        private void End(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void eee(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("yyyyyyyy","hhhhh", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        private void UserLoad(object sender, RoutedEventArgs e)
        {
            ComboPol.ItemsSource = Helper.demoBd.Gender.ToList();
            ComboGroup.ItemsSource = Helper.demoBd.Groups.ToList();
            ComboCount.ItemsSource = Helper.demoBd.Country.ToList();

            var res = Helper.demoBd.Users.FirstOrDefault(i => i.Id == Helper.users.Id);
            GrBox.DataContext = res;
            if (string.IsNullOrEmpty(Helper.users.NameFiles) != true)
                NameFiles.Text = res.NameFiles;
            else
                NameFiles.Text = "None.png";
            ImageUser.ImageSource = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchUser + NameFiles.Text)));
        }
        private void AvatarUser(object sender, RoutedEventArgs e)
        {
            string fullPathFile = "";
            OpenFileDialog photo = new OpenFileDialog();
            photo.Multiselect = true;
            photo.Filter = "Image files (*.png;*.jpg;*.ico)|*.png;*.jpg;*.ico|All files (*.*)|*.*";
            photo.InitialDirectory = Helper.PatchApplication(Helper.PatchUser);
            var aaa = photo.ShowDialog();
            if (photo.ShowDialog() == true)
            {
                fullPathFile = Helper.PatchApplication(Helper.PatchUser + photo.SafeFileName);
                if (string.Equals(photo.FileName, fullPathFile))
                {
                    NameFiles.Text = photo.SafeFileName;
                    ImageUser.ImageSource = new BitmapImage(new Uri(fullPathFile));
                    ImageUser.Stretch = Stretch.UniformToFill;
                }
                else
                    MessageBox.Show("Полные пути файлов не совпадают ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Conm(object sender, SelectionChangedEventArgs e)
        {
            Spec.Text = Helper.demoBd.Groups.FirstOrDefault(i => i.Id == (int)ComboGroup.SelectedValue).Comment;

        }
        private void LoadProf(object sender, RoutedEventArgs e)
        {
            GodEdit.ItemsSource = Enumerable.Range(2000, DateTime.Now.Year - 2000 + 1);
        }
    }
}
