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
    public partial class WinLogin : Window
    {
        private int _error = 0;
        public WinLogin()
        {
            InitializeComponent();
        }

        private void Error()
        {
            if (_error == 3)
            {
                btnLogin.IsEnabled = false;
                UserBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
                MessageBox.Show("Слишком много ошибок(3)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Поля не заполнены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
                _error += 1;
                Error();
                return;
            }
            //var password = Helper.Md5Hash(PasswordBox.Password); // Разобраться с шифром

            try
            {
                var res = Helper.demoBd.Users.Where(i => i.Email == UserBox.Text && i.Passwords == PasswordBox.Password);
                if (res.Count() == 1)
                {
                    Helper.users = res.FirstOrDefault();
                    Helper.ActiveAdd(); //!!!!
                    this.Close();
                }
                if (res.Count() == 0)
                {
                    MessageBox.Show("Нет записей","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                    _error += 1;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка открытия базы данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            Error();
        }
        private void EndClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
