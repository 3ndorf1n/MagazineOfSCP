using DevExpress.DashboardWeb.Native;
using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для UserControlBasket.xaml
    /// </summary>
    public partial class UserControlBasket : UserControl
    {
        Fond fond;
        private MyDelegate d;
        public UserControlBasket(MyDelegate sender)
        {
            InitializeComponent();
            d = sender;

        }
        public void BasketNull()
        {
            var i = BuyedSCP.scps.FindIndex(s => s.Name.Equals(name.Text.Remove(0, "SCP-".Length)));
            if (BuyedSCP.scps[i].Count == 0)
            {
                BuyedSCP.scps.RemoveAt(i);
            }
        }
        private void putAway_btn_Click(object sender, RoutedEventArgs e)
        {
            PutAway();
            BasketNull();
            d();
        }
        public void PutAway()
        {
            fond = new Fond();
            ConvertToMinView();
            List<SCP> scps = Fond.SCP_Reading();
            if (scps.Where(s => s.Name.Equals(SelectSCP.Name)).ToList().Count != 0)
            {
                int mainCount = Convert.ToInt32(scps.Where(s => s.Name.Equals(SelectSCP.Name)).Select(s => s).ToList()[0].Count);
                fond.SCP_CHANGE(SelectSCP.Name, SelectSCP.Class_, SelectSCP.Description, SelectSCP.Image, mainCount + 1, SelectSCP.Price);
            }
            BuyedSCP.scps[BuyedSCP.scps.FindIndex(s => s.Name.Equals(name.Text.Remove(0, "SCP-".Length)))].Count -= 1;
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
    }
}
