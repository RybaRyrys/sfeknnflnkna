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
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        storeTableAdapter store = new storeTableAdapter();
        public StorePage()
        {
            InitializeComponent();
            StoreDgr.ItemsSource = store.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QuantTbx.Text != "" && Convert.ToInt32(QuantTbx.Text) >= 0 && PlaceTbx.Text != "" &&
                Convert.ToInt32(PlaceTbx.Text) > 0)
                {
                    store.InsertQuery(Convert.ToInt32(PlaceTbx.Text), Convert.ToInt32(QuantTbx.Text));
                    StoreDgr.ItemsSource = store.GetData();

                }
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (StoreDgr.SelectedItem != null)
            {
                object id = (StoreDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (QuantTbx.Text != "" && Convert.ToInt32(QuantTbx.Text) >= 0 && PlaceTbx.Text != "" &&
                    Convert.ToInt32(PlaceTbx.Text) > 0)
                    {
                        store.UpdateQuery(Convert.ToInt32(PlaceTbx.Text), Convert.ToInt32(QuantTbx.Text), (int)id);
                        StoreDgr.ItemsSource = store.GetData();
                    }
                }
                catch
                {
                    MessageBox.Show("Неверное значение");
                }
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(StoreDgr.SelectedItem != null)
            {
                object id = (StoreDgr.SelectedItem as DataRowView).Row[0];
                store.DeleteQuery((int)id);
                StoreDgr.ItemsSource = store.GetData();

            }
        }

        private void StoreDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StoreDgr.SelectedItem != null)
            {
            QuantTbx.Text = (StoreDgr.SelectedItem as DataRowView).Row[2].ToString();
            PlaceTbx.Text = (StoreDgr.SelectedItem as DataRowView).Row[1].ToString();

            }
        }
    }
}
