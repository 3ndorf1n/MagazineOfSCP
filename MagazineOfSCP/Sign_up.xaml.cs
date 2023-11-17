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
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using MagazineOfSCP;

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для WinRegistr.xaml
    /// </summary>
    public partial class Sign_up : Window
    {
        string usersJson = @"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\Users.json";
        List<User> users = new List<User>();
        Fond fond;
        public Sign_up()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            /*File.WriteAllText(usersJson,JsonConvert.SerializeObject(new User("ad", "1234")));
            var obj = JsonConvert.DeserializeObject<User>(File.ReadAllText(usersJson));*/
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            Reg(login.Text, P1.Password, P2.Password);
        }
        public void Reg(string login, string P1, string P2) // Вынести в фонд и разные методы - разграничить
        {
            if (login!= "" && P1 != "" && P2 != "" && P1.Equals(P2))
            {
                if (Fond.User_Verification(login))
                {
                    fond.User_Add(new User(login, P1, 1));
                    Close();
                }    
                else MessageBox.Show("Указанный пользователь уже есть в системе");
            }   
        }
        private void winLog_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginOpen();
        }
        public void LoginOpen()
        {
            Close();
            Log_in log_In = new Log_in();
            log_In.ShowDialog();
        }

        private void user_btn_Click(object sender, RoutedEventArgs e)
        {
            Guest();
        }
        public void Guest()
        {
            UserAccess.login = "Гость";
            UserAccess.access_lvl = 0;
            Close();
        }
    }
}
