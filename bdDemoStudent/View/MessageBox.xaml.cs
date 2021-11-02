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
    public partial class MessageBox : Window
    {
        MessageBoxResult Result = MessageBoxResult.None;
        public MessageBox()
        {
            InitializeComponent();
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage ico)
        {
            var dialog = new MessageBox() { Title = caption };
            dialog.MessageContainer.Text = message;
            dialog.AddButtons(buttons);

            switch ((MessageBoxImage)ico)
            {
                case MessageBoxImage.Warning:
                    dialog.Pic_Jpg.Source = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchJpg + "Warning1.png")));
                    break;

                case MessageBoxImage.Error:
                    dialog.Pic_Jpg.Source = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchJpg + "Error1.png")));
                    break;

                case MessageBoxImage.Asterisk:
                    dialog.Pic_Jpg.Source = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchJpg + "Good1.png")));
                    break;

                case MessageBoxImage.None:
                    dialog.Pic_Jpg.Source = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchJpg + "Windows - Security.png")));
                    break;

                case MessageBoxImage.Question:
                    dialog.Pic_Jpg.Source = new BitmapImage(new Uri(Helper.PatchApplication(Helper.PatchJpg + "Question1.png")));
                    break;

                default:
                    throw new ArgumentException("Unknown image value", "ico");
            }
            dialog.ShowDialog();
            return dialog.Result;
        }

        void AddButtons(MessageBoxButton buttons)
        {
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    AddButton("OK", MessageBoxResult.OK);
                    break;

                case MessageBoxButton.OKCancel:
                    AddButton("OK", MessageBoxResult.OK);
                    AddButton("Cancel", MessageBoxResult.Cancel, isCancel: true);
                    break;

                case MessageBoxButton.YesNoCancel:
                    AddButton("Yes", MessageBoxResult.Yes);
                    AddButton("No", MessageBoxResult.No);
                    AddButton("Cancel", MessageBoxResult.Cancel, isCancel: true);
                    break;

                case MessageBoxButton.YesNo:
                    AddButton("Yes", MessageBoxResult.Yes);
                    AddButton("No", MessageBoxResult.No);
                    break;

                default:
                    throw new ArgumentException("Unknown image value", "buttons");
            }
        }

        void AddButton(string text, MessageBoxResult result , bool isCancel = false)
        {
            var button = new Button() { Content = text, IsCancel = isCancel };
            button.Click += (o, args) => { Result = result; DialogResult = true; };
            button.Template = (ControlTemplate)FindResource("myButtonMin");
            ButtonContainer.Children.Add(button);
        }
    }
}
