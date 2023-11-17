using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.DirectX.Common;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для ChangeOrAdd.xaml
    /// </summary>
    public partial class ChangeOrAdd : Window
    {
        Fond fond;
        public ChangeOrAdd()
        {
            InitializeComponent();

        }
        public void Change(string Class, string Name, string Description, string Count, string Price, string Image)
        {
            @class.Text = Class;
            name.Text = Name;
            description.Text = Description;
            count.Text = Count;
            price.Text = Price;
            BitmapImage bm = new BitmapImage();
            bm.BeginInit();
            bm.UriSource = new Uri(Image, UriKind.RelativeOrAbsolute);
            bm.EndInit();
            image.Source = bm;
        }
        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageSwitch();
        }
        public void ImageSwitch()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            if (dlg.ShowDialog() == true)
            {
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
                bm.EndInit();
                image.Source = bm;
            }
        }

        private void changeOrAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            ChangeAdd();   
        }
        public void ChangeAdd()
        {
            @class.Text = @class.Text.Trim();
            name.Text = name.Text.Trim();
            count.Text = count.Text.Trim();
            price.Text = price.Text.Trim();
            description.Text = description.Text.Trim();

            if (@class.Text != "")
            {
                (string name_, int count_, double price_, string description_, string image_) = Template(@class.Text, name.Text, count.Text, price.Text, description.Text, image.Source.ToString());
                if (ChangeORAdd.coa)
                {
                    if (Fond.SCP_CanChange(name_))
                    {
                        fond.SCP_CHANGE(name_, @class.Text, description_, image_, count_, price_); Close();
                    }
                    else MessageBox.Show("Объект был обнаружен фондом");
                }
                else
                {
                    if (!Fond.SCP_IsFind(name_))
                    {
                        fond.SCP_ADD(new SCP(name_, @class.Text, description_, image_, count_, price_));
                        Close();
                    }
                    else MessageBox.Show("Объект был обнаружен фондом");
                }
            }   
            else MessageBox.Show("Класс объекта не указан");
        }
        public static (string, int, double, string, string) Template(string @class,string name, string count, string price, string description, string image)
        {
            string Name = name.Equals("") ? "███" : name;
            int Count = int.TryParse(count, out var c) ? c : 1;
            double Price = double.TryParse(price, out var r) ? r : 500000 + name.Length * -10000;
            string Description = description == "" ? "██████████ ЗАСЕКРЕЧЕНА ДО ██:██:██" : description;
            string Image = image.Equals("pack://application:,,,/Unknow.jpg") ? @$"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\{@class}.png" : image;
            return (Name, Count, Price, Description, Image);
        }


        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }
        public void Cancel()
        {
            string messageBoxText = "Вы уверены?";
            string caption = "Отмена";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
