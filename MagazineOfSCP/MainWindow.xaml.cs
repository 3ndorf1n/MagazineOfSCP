using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
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
using System.Text.Json;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml.Linq;
using DevExpress.Data.Helpers;

namespace MagazineOfSCP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void MyDelegate();
    public partial class MainWindow : Window
    {
        Fond fond = new Fond();
        
        Use use;
        public int accessLvl;
        public string userName;
        public MainWindow()
        {
            InitializeComponent();
            up_rb.IsChecked = false;
            down_rb.IsChecked = false;
            BuyedSCP.scps = new List<SCP>();
            Log_in log_In = new Log_in();
            log_In.ShowDialog();
            
        }

        private void test_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Distinction();
            SCP_Update();   
        }
        public void Distinction()
        {
            if (UserAccess.access_lvl == 0)
            {
                exit_btn.Content = "Войти";
                exit_btn.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(103, 169, 86));
                add_btn.Visibility = Visibility.Collapsed;
                basket_btn.Visibility = Visibility.Collapsed;
            }
            else if (UserAccess.access_lvl == 1)
            {
                exit_btn.Content = "Выйти";
                exit_btn.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(152, 102, 102));
                add_btn.Visibility = Visibility.Collapsed;
                basket_btn.Visibility = Visibility.Visible;

            }
            else if (UserAccess.access_lvl == 2)
            {
                exit_btn.Content = "Выйти";
                exit_btn.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(152, 102, 102));
                add_btn.Visibility = Visibility.Visible;
                basket_btn.Visibility = Visibility.Visible;
            }
        }
        public List<SCP> searchName(List<SCP> scps)
        {
            List<SCP> searchest = (from i in scps
                            where i.Name.Contains(name_tb.Text)
                            select i).ToList();
            return searchest;
        }
        public List<SCP> searchClass(List<SCP> scps)
        {
            List<SCP> searchest = (from i in scps
                                   where i.Class_.Equals(class_cb.SelectedValue.ToString().Remove(0, "System.Windows.Controls.ComboBoxItem: ".Length))
                                              select i).ToList() ;
            return searchest;
        }
        public List<SCP> searchDown(List<SCP> scps)
        {
            List<SCP> searchest = (from i in scps
                                    orderby i.Price descending
                                    select i).ToList();
            return searchest;
        }
        public List<SCP> searchUp(List<SCP> scps)
        {
            List<SCP> searchest = (from i in scps
                                 orderby i.Price 
                                 select i).ToList();
            return searchest;
        }
        public void SCP_Update()
        {
            viewscp.Items.Clear();
            Search();
            ListUpdate();

        }
        public void ListUpdate()
        {
            List<SCP> scps = Fond.SCP_Reading();
            foreach (var scp in scps)
            {
                use = new Use(new MyDelegate(SCP_Update));
                use.name.Text += scp.Name;
                use.@class.Text += scp.Class_;
                use.description.Text += scp.Description;
                use.price.Text += scp.Price;
                use.count.Text += scp.Count;
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(scp.Image, UriKind.RelativeOrAbsolute);
                bm.EndInit();
                use.image.Source = bm;
                viewscp.Items.Add(use);
                use.ButtonsVisible();
            }
            price_tb.Text = BuyedSCP.scps.Count() != 0 ? $"$ {BuyedSCP.scps.Sum(s => s.Price * s.Count)}" : "$ 0";
        }
        public void Search()
        {
            List<SCP> scps = Fond.SCP_Reading();
            if (name_tb.Text != "") scps = searchName(scps);
            if (down_rb.IsChecked == true) scps = searchDown(scps);
            else if (up_rb.IsChecked == true) scps = searchUp(scps);
            if (class_cb.SelectedIndex != -1 && class_cb.SelectedIndex != class_cb.Items.Count - 1) scps = searchClass(scps);
        }
        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        public void Exit()
        {
            use = new Use(new MyDelegate(SCP_Update));
            Log_in log_In = new Log_in();
            UserAccess.access_lvl = 0;
            UserAccess.login = null;
            BuyedSCP.scps.RemoveRange(0, BuyedSCP.scps.Count - 1);
            log_In.ShowDialog();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddObject();
        }
        public void AddObject()
        {
            ChangeOrAdd add = new ChangeOrAdd();
            ChangeORAdd.coa = false;
            add.ShowDialog();
        }

        private void basket_btn_Click(object sender, RoutedEventArgs e)
        {
            BasketOpen();
        }
        public void BasketOpen()
        {
            WinBasket winBasket = new WinBasket();
            winBasket.Owner = this;
            winBasket.ShowDialog();
        }

        
        private void name_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            SCP_Update();
        }

        private void default_btn_Click(object sender, RoutedEventArgs e)
        {
            DefaultSearchSetting();
            SCP_Update();
        }
        public void DefaultSearchSetting()
        {
            down_rb.IsChecked = false;
            up_rb.IsChecked = false;
            class_cb.SelectedIndex = class_cb.Items.Count - 1;
        }

        private void down_rb_Checked(object sender, RoutedEventArgs e)
        {
            up_rb.IsChecked=false;
            SCP_Update();
        }

        private void up_rb_Checked(object sender, RoutedEventArgs e)
        {
            down_rb.IsChecked = false;
            SCP_Update();

        }
        private void class_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SCP_Update();
        }

        private void class_cb_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
