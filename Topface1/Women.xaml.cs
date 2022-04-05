using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Women.xaml
    /// </summary>
    
    public partial class Women : Window
    {
        byte[] photo;
        public static TopfaceEntities db = new TopfaceEntities();
        public Women()
        {
            InitializeComponent();
            //var cl = from pk in db.PodCategory where pk.ID_Category == 1 select pk;
            typepro.ItemsSource = db.PodCategory.Where(c => c.ID_Category == 1).ToList();
            
            typepro.DisplayMemberPath = "Name";
        }

        private void Back_Women_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void typepro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var pro = from pr in db.Product
            //          join kat in db.PodCategory
            //          on pr.ID_PodCategory equals kat.ID_PodCategory
            //          where kat.Name == pp.Name
            //          select new
            //          {
            //              ID = pr.ID_Product,
            //              Имя = pr.Name,
            //              Описание = pr.Description,
            //              Количество = pr.Number,

            //          };
            UpdateDataGrid();
        }


        void UpdateDataGrid()
        {
            var pp = typepro.SelectedItem as PodCategory;
            var gg = db.Product.Where(c => c.ID_PodCategory == pp.ID_PodCategory).ToList();
            productdata.ItemsSource = gg;
        }
       
        private void Qwadr_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
            Order order = new Order();
            order.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ff = productdata.SelectedItem as Product;
            db.Product.Remove(ff);
            db.SaveChanges();
            UpdateDataGrid();
            //string idval = productdata.SelectedItem.ToString().Substring(7, 3);
            //int id = Convert.ToInt32(idval);
            //var query = (from pr in db.Product where pr.ID_Product == id select pr).First();
            //db.Product.Remove(query);
            //db.SaveChanges();
            //var pp = productdata.SelectedItem as PodCategory;
            //var pro = from pr in db.Product
            //          join kat in db.PodCategory
            //          on pr.ID_PodCategory equals kat.ID_PodCategory
            //          where kat.Name == pp.Name
            //          select new
            //          {
            //              ID = pr.ID_Product,
            //              Имя = pr.Name,
            //              Описание = pr.Description,
            //              Количество = pr.Number,
            //          };
            //productdata.ItemsSource = pro.ToList();
        }
    }
}
