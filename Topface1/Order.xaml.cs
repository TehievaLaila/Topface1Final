using Microsoft.Data.SqlClient;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Order()
        {
            InitializeComponent();
            var cl = from pk in db.PodCategory where pk.ID_Category == 1 select pk;
            ORD.ItemsSource = cl.ToList();
            ORD.DisplayMemberPath = "Name";
        }

        private void ORD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pp = ORD.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                         pr.Name
                      };
           
            Fly.ItemsSource = pro.ToList();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=SQL-STUD1\SQL_001;Initial Catalog=Topface;Integrated Security=True";
            string sqlExpression;

            var lst = new List<String>();
            foreach (var item in Fly.Items)
            {
                if (item.ToString() == Fly.SelectedItem.ToString())
                    lst.Add(item.ToString());
            } 

            foreach (var item in db.Product)
            {
                string name = lst[0];
                name = name.TrimStart(new char[8] { 'N', 'a', 'm', 'e', ' ', '=', '}', '{' });
                name = name.Replace("}","");
                name = name.TrimEnd(new char[1] { ' '});
                if (item.Name.ToString() == name) 
                { 
                    sqlExpression = $"Update Product Set Number = '{Convert.ToInt32(item.Number) + 10}' Where Name = '{name}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Данные успешно обновлены");
                }
            }
            this.Close();
        }
    }
}
