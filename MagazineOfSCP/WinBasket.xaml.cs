using DevExpress.Data;
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

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для WinBasket.xaml
    /// </summary>
    public partial class WinBasket : Window
    {
        Fond fond = new Fond();
        UserControlBasket use;
        public WinBasket()
        {
            InitializeComponent();
        }
        public void ListUpdate()
        {
            viewscp.Items.Clear();
            if (BuyedSCP.scps.Count != 0)
            {
                List<SCP> scps = BuyedSCP.scps;
                foreach (var scp in scps)
                {
                    use = new UserControlBasket(new MyDelegate(ListUpdate));
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
                    
                }
            }
            MainWindow main = this.Owner as MainWindow;
            main.SCP_Update();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ListUpdate();
        }
    }
}
