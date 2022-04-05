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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Window2()
        {
            InitializeComponent();
            var cl = from pk in db.PodCategory select pk;
            Mar.ItemsSource = cl.ToList();
            Mar.DisplayMemberPath = "Name";
        }

        private void Mar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pp = Mar.SelectedItem as PodCategory;
            var pro = from pr in db.Supplier
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                          Имя = pr.Name,
                          Описание = pr.Description,
                          Телефон = pr.Phone,

                      };
            Nand.ItemsSource = pro.ToList();
        }

        private void BK(object sender, MouseButtonEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
