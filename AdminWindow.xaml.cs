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

namespace itog
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ItemPage();
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new StorePage();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new OrdersPage();
        }

        private void Item_Order_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ItemOrderPage();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new BrandPage();
        }

        private void Item_Type_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ItemTypePage();
        }

        private void Receipt_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ReceiptPage();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ClientPage();
        }

        private void User_Data_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new UserDataPage();
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new WorkerPage();
        }

        private void Job_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new JobPage();
        }
    }
}
