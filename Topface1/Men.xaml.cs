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
    /// Логика взаимодействия для Men.xaml
    /// </summary>
    public partial class Men : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Men()
        {
            InitializeComponent();
            var cl = from pk in db.PodCategory where pk.ID_Category == 2 select pk;
            ComBom.ItemsSource = cl.ToList();
            ComBom.DisplayMemberPath = "Name";
        }

        private void Back_men_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void ComBom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pp = ComBom.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                          ID = pr.ID_Product,
                          Имя = pr.Name,
                          Описание = pr.Description,
                          Количество = pr.Number,

                      };
            bran.ItemsSource = pro.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WHAT what = new WHAT();
            what.Show();
         
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string idval = bran.SelectedItem.ToString().Substring(7, 3);
            int id = Convert.ToInt32(idval);
            var query = (from pr in db.Product where pr.ID_Product == id select pr).First();
            db.Product.Remove(query);
            db.SaveChanges();
            var pp = ComBom.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                          ID = pr.ID_Product,
                          Имя = pr.Name,
                          Описание = pr.Description,
                          Количество = pr.Number,

                      };
            bran.ItemsSource = pro.ToList();
        }
    }
}
