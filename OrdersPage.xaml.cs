using itog.toy_storeDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace itog
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        clientTableAdapter client = new clientTableAdapter();
        workerTableAdapter worker = new workerTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        public OrdersPage()
        {
            InitializeComponent();
            OrderGrd.ItemsSource = orders.GetData();
            ClientBx.ItemsSource = client.GetData();
            WorkerBx.ItemsSource = worker.GetData();
            ClientBx.DisplayMemberPath = "client_id";
            WorkerBx.DisplayMemberPath = "worker_id";
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(ClientBx.SelectedItem != null && WorkerBx.SelectedItem != null)
            {
                object client_id = (ClientBx.SelectedItem as DataRowView).Row[0];
                object worker_id = (WorkerBx.SelectedItem as DataRowView).Row[0];

                orders.InsertQuery((int)worker_id, (int)client_id);
                OrderGrd.ItemsSource = orders.GetData();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(ClientBx.SelectedItem != null && WorkerBx.SelectedItem != null && OrderGrd.SelectedItem != null)
            {
                object client_id = (ClientBx.SelectedItem as DataRowView).Row[0];
                object worker_id = (WorkerBx.SelectedItem as DataRowView).Row[0];
                object id = (OrderGrd.SelectedItem as DataRowView).Row[0];

                try
                {
                    orders.UpdateQuery((int)worker_id, (int)client_id, (int)id);
                    OrderGrd.ItemsSource = orders.GetData();
                }
                catch
                {
                    MessageBox.Show("Пустые поля");
                }
            }
            

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(OrderGrd.SelectedItem != null)
            {
            object id = (OrderGrd.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery((int)id);
            OrderGrd.ItemsSource = orders.GetData();

            }

        }
    }
}
