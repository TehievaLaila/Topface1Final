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
using Microsoft.Data.SqlClient;

namespace Topface1
{
    /// <summary>
    /// Логика взаимодействия для WHAT.xaml
    /// </summary>
    public partial class WHAT : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public WHAT()
        {
            InitializeComponent();
            var cl = from pk in db.PodCategory where pk.ID_Category == 2 select pk;
            Box.ItemsSource = cl.ToList();
            Box.DisplayMemberPath = "Name";
        }

        private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pp = Box.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                         pr.Name
                      };

            Grid.ItemsSource = pro.ToList();
        }

        private void Butter_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=SQL-STUD1\SQL_001;Initial Catalog=Topface;Integrated Security=True";
            string sqlExpression;

            var lst = new List<String>();
            foreach (var item in Grid.Items)
            {
                if (item.ToString() == Grid.SelectedItem.ToString())
                    lst.Add(item.ToString());
            }

            foreach (var item in db.Product)
            {
                string name = lst[0];
                name = name.TrimStart(new char[8] { 'N', 'a', 'm', 'e', ' ', '=', '}', '{' });
                name = name.Replace("}", "");
                name = name.TrimEnd(new char[1] { ' ' });
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
