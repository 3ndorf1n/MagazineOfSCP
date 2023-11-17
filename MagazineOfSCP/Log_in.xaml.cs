using MagazineOfSCP;
using MaterialDesignThemes.Wpf.Converters.CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MagazineOfSCP
{
    /// <summary>
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public Log_in()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void log_btn_Click(object sender, RoutedEventArgs e)
        {
            Log(login.Text, P1.Password);
        }
        public void Log(string login, string P1)
        {
            if (login != "" &&  P1 != "")
            {
                if(Fond.User_Verification(login, P1))
                {
                    Close();
                }
                else MessageBox.Show("Ошибка авторизации");
            }
        }
        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            RegOpen();
        }
        public void RegOpen()
        {
            Sign_up sign_Up = new Sign_up();
            Close();
            sign_Up.ShowDialog();
        }
    }
}
