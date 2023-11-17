using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class Use : UserControl
    {
        Fond fond;
        private MyDelegate d;

        public Use(MyDelegate sender)
        {
            InitializeComponent();
            d = sender;

        }
        public void ButtonsVisible()
        {
            if (UserAccess.access_lvl == 0)
            {
                buy_btn.Visibility = Visibility.Collapsed;
                change_btn.Visibility = Visibility.Collapsed;
                delete_btn.Visibility = Visibility.Collapsed;
            }
            else if (UserAccess.access_lvl == 1)
            {
                buy_btn.Visibility = Visibility.Visible;
                change_btn.Visibility = Visibility.Collapsed;
                delete_btn.Visibility = Visibility.Collapsed;
            }
            else if (UserAccess.access_lvl == 2)
            {
                buy_btn.Visibility = Visibility.Visible;
                change_btn.Visibility = Visibility.Visible;
                delete_btn.Visibility = Visibility.Visible;
            }
            if (Convert.ToInt32(count.Text.Remove(0, "Кол-во: ".Length)) == 0)
            {
                buy_btn.IsEnabled = false;
            }
            else buy_btn.IsEnabled = true;
        }

        private void change_btn_Click(object sender, RoutedEventArgs e)
        {
            Change();
            d();
        }
        public void Change()
        {
            ChangeOrAdd changeOrAdd = new ChangeOrAdd();
            ChangeORAdd.coa = true;
            ConvertToMinView();
            changeOrAdd.Change(@class.Text, name.Text.Remove(0, "SCP-".Length), description.Text.Remove(0, "Описание и условия ██████████: ".Length), count.Text.Remove(0, "Кол-во: ".Length), price.Text.Remove(0, "Цена: $".Length), image.Source.ToString());
            changeOrAdd.ShowDialog();
            SelectSCP.Name = name.Text.Remove(0, "SCP-".Length);
        }
        private void ConvertToMinView()
        {
            SelectSCP.Class_ = @class.Text;
            SelectSCP.Name = name.Text.Remove(0, "SCP-".Length);
            SelectSCP.Description = description.Text.Remove(0, "Описание и условия ██████████: ".Length);
            SelectSCP.Image = image.Source.ToString();
            SelectSCP.Count = Convert.ToInt16(count.Text.Remove(0, "Кол-во: ".Length));
            SelectSCP.Price = Convert.ToDouble(price.Text.Remove(0, "Цена: $".Length));
            SelectSCP.scp = Fond.SCP_Reading().Find(s => s.Name.Equals(SelectSCP.Name));
        }

        private void buy_btn_Click(object sender, RoutedEventArgs e)
        {
            Buy();
            d();
        }
        public void Buy()
        {
            fond = new Fond();
            ConvertToMinView();
            fond.SCP_CHANGE(SelectSCP.Name, SelectSCP.Class_, SelectSCP.Description, SelectSCP.Image, SelectSCP.Count - 1, SelectSCP.Price);
            if (BuyedSCP.scps.Where(s => s.Name.Equals(SelectSCP.Name)).ToList().Count == 1)
            {
                foreach (var scp in BuyedSCP.scps)
                {
                    if (scp.Name.Equals(SelectSCP.Name))
                    {
                        scp.Count += 1;
                    }
                }
            }
            else { BuyedSCP.scps.Add(SelectSCP.scp); BuyedSCP.scps[BuyedSCP.scps.Count - 1].Count = 1; }
        }


        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Del();
            d();
        }
        public void Del()
        {
            string messageBoxText = "Вы правда хотите этого??";
            string caption = "Убийство, самое настоящее преступление против природы";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                fond = new Fond();
                ConvertToMinView();
                fond.SCP_DEL(SelectSCP.Name);
                BuyedSCP.scps.Where(s => s.Name.Equals(SelectSCP.Name)).Select(s => BuyedSCP.scps.Remove(s));
            }
        }
    }
}
