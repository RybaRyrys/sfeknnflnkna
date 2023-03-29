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
    /// Логика взаимодействия для ItemOrderPage.xaml
    /// </summary>
    public partial class ItemOrderPage : Page
    {
        itemTableAdapter item = new itemTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        order_itemTableAdapter order_Item = new order_itemTableAdapter();
        public ItemOrderPage()
        {
            InitializeComponent();
            IODgr.ItemsSource = order_Item.GetData();
            ItemCbx.ItemsSource = item.GetData();
            OrderCbx.ItemsSource = orders.GetData();
            ItemCbx.DisplayMemberPath = "item_name";
            OrderCbx.DisplayMemberPath = "order_id";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(ItemCbx.SelectedItem != null)
            {
                object item_id = (ItemCbx.SelectedItem as DataRowView).Row[0];
                try
                {
                    object order_id = (OrderCbx.SelectedItem as DataRowView).Row[0];
                    order_Item.InsertQuery((int)order_id, (int)item_id);
                    IODgr.ItemsSource = order_Item.GetData();
                }
                catch
                {
                    MessageBox.Show("Пустые поля");
                }
            }
            
           
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(ItemCbx.SelectedItem != null && OrderCbx.SelectedItem != null &&
                IODgr.SelectedItem != null)
            {
                object item_id = (ItemCbx.SelectedItem as DataRowView).Row[0];
                object order_id = (OrderCbx.SelectedItem as DataRowView).Row[0];
                object id = (IODgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    order_Item.UpdateQuery((int)order_id, (int)item_id, (int)id);
                    IODgr.ItemsSource = order_Item.GetData();
                }
                catch
                {
                    MessageBox.Show("Пустые поля");
                }
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(IODgr.SelectedItem != null)
            {

            object id = (IODgr.SelectedItem as DataRowView).Row[0];
            order_Item.DeleteQuery((int)id);
            IODgr.ItemsSource = order_Item.GetData();
            }
        }
    }
}
