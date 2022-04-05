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
using Topface1.TF;

namespace Topface1
{
    /// <summary>
    /// Логика взаимодействия для Employe.xaml
    /// </summary>
    public partial class Employe : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Employe()
        {
            InitializeComponent();
            Empl();
        }

        private void Empl()
        {
            var qadr =
                from Employee in db.Employee
                select new
                {
                    ID = Employee.ID_Employee,
                    Surname = Employee.Surname,
                    Name = Employee.Name,
                    Patronymic = Employee.patronymic
                };
            Lout.ItemsSource = qadr.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hire hire = new Hire();
            hire.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idval = Lout.SelectedItem.ToString().Substring(7, 3);
            //MessageBox.Show(idval);
            int id = Convert.ToInt32(idval);
            var que = (from pr in db.Employee where pr.ID_Employee == id select pr).First();
            db.Employee.Remove(que);
            db.SaveChanges();
            Empl();
        }
    }
}
