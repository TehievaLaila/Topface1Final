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

namespace Topface1
{
    /// <summary>
    /// Логика взаимодействия для Supplier.xaml
    /// </summary>
    public partial class Supplier : Window
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void Back_supplier_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window1 windi = new Window1();
            windi.Show();
            this.Close();
        }
    }
}
