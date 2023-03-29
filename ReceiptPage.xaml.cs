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
    /// Логика взаимодействия для ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        itemTableAdapter item = new itemTableAdapter();
        receiptTableAdapter receipt = new receiptTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        order_itemTableAdapter order_Item= new order_itemTableAdapter();

        public ReceiptPage()
        {
            InitializeComponent();
            ReceiptDgr.ItemsSource = receipt.GetData();
            OrderCbx.ItemsSource = orders.GetData();
            OrderCbx.DisplayMemberPath = "order_id";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(OrderCbx.SelectedItem != null)
            {
                object order_id = (OrderCbx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (SumTbx.Text != "" && DepositTbx.Text != "")
                    {
                        receipt.InsertQuery((int)order_id, Convert.ToDecimal(SumTbx.Text), Convert.ToDecimal(DepositTbx.Text),
                            Convert.ToDecimal(ChangeB.Text));
                    }
                }
                catch { MessageBox.Show("Неверное значение"); }
                ReceiptDgr.ItemsSource = receipt.GetData();
            }
            
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(ReceiptDgr.SelectedItem != null && OrderCbx.SelectedItem != null)
            {
                object receipt_id = (ReceiptDgr.SelectedItem as DataRowView).Row[0];
                object order_id = (OrderCbx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (SumTbx.Text != "" && DepositTbx.Text != "")
                    {
                        receipt.UpdateQuery((int)order_id, Convert.ToDecimal(SumTbx.Text), Convert.ToDecimal(DepositTbx.Text),
                        Convert.ToDecimal(ChangeB.Text), (int)receipt_id);
                    }
                }
                catch { MessageBox.Show("Неверное значение"); }
                ReceiptDgr.ItemsSource = receipt.GetData();
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ReceiptDgr.SelectedItem != null)
            {
            object receipt_id = (ReceiptDgr.SelectedItem as DataRowView).Row[0];
            receipt.DeleteQuery((int)receipt_id);
            ReceiptDgr.ItemsSource = receipt.GetData();

            }
        }

        private void DepositTbx_TextChanged(object sender, TextChangedEventArgs e)
        {   
            if (DepositTbx.Text != null)
            {
                try
                {
                    decimal change = Convert.ToDecimal(DepositTbx.Text) - Convert.ToDecimal(SumTbx.Text);
                    ChangeB.Text = change.ToString();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }

            }
        }

        private void ReceiptDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ReceiptDgr.SelectedItem != null)
            {
                SumTbx.Text = (ReceiptDgr.SelectedItem as DataRowView).Row[2].ToString();
                DepositTbx.Text = (ReceiptDgr.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
