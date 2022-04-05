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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Topface1.TF;

namespace Topface1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static TF.TopfaceEntities tf = new TF.TopfaceEntities();

        public static TF.Autorization Auto;


        private void login_Click(object sender, RoutedEventArgs e)
        {
            foreach (var user in tf.Autorization)
            {
                if(user.login == log.Text.Trim())
                {
                    if (Pass.Password == "" || log.Text == "")
                    {
                        MessageBox.Show("Enter the data!");

                    }

                    if(user.password == Pass.Password.Trim() && user.ID_Role == 2)
                    {
                        MessageBox.Show($"Hello {user.login}");

                        Window1 window1 = new Window1();
                        window1.Show();
                        this.Close();
                    }

                    if(user.password == Pass.Password.Trim() && user.ID_Role == 1)
                    {
                        MessageBox.Show($"Hello Director{user.login}");

                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }

                }
                
            }
        }

        private void autoriz_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || sername.Text == "" || login1.Text == "" || password.Password == "")
            {
                MessageBox.Show("Enter the data!");
            }
            else
            {
                User users = new User();
                {
                    users.Name = name.Text;
                    users.Surname = sername.Text;
                }
                tf.User.Add(users);
                tf.SaveChanges();
                Autorization autoriz = new Autorization();
                {
                    autoriz.login = login1.Text;
                    autoriz.password = password.Password;
                    autoriz.ID_Role = 2;
                    autoriz.ID_User = users.ID_User;
                }
                tf.Autorization.Add(autoriz);
                tf.SaveChanges();
                MessageBox.Show("Cool!");

                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
        }
    }
}
