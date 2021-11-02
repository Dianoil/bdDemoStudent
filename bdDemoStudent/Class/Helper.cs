using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using bdDemoStudent.View;
using System.Diagnostics;

namespace bdDemoStudent.Class
{
    public static class Helper
    {
        public static byte user = 0;
        public static DemoBdStudent1Entities demoBd; //Ссылка на БД
        public static Activrtes activites;  //Ссылка активность
        public static Users users;  //Ссылка на юзера
        public static string PatchUser = "avatar\\";  //Ссылка на аватары пользователей
        public static string PatchJpg = "JPG\\";   //Ссылка на иконки

        public static string PatchApplication(string str) =>
            System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\" + str;

        static Helper()
        {
            try
            {
                demoBd = new DemoBdStudent1Entities();
            }
            catch
            {
                View.MessageBox.Show("Ошибка при открытии БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }
        //Шифрование(опционально)
        public static string Md5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password)))
                .Replace("-", "")
                .ToLower();
        }
        //Запись в коллекцию
        public static void ActiveAdd()
        {
            if (users == null) return;

            if (activites == null)
            {
                activites = new Activrtes()
                {
                    IdUser = users.Id,
                    LoginTime = DateTime.Now,
                    Comment = "Успешный вход"
                };

                activites = demoBd.Activrtes.Add(activites);
            }
            else
            {
                activites.LogoutTime = DateTime.Now;
                activites.Comment += "/Нормальный выход";
            }
            demoBd.SaveChanges();
        }
    }
}
