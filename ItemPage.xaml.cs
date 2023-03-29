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
    /// Логика взаимодействия для ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Page
    {
        itemTableAdapter item = new itemTableAdapter();
        brandTableAdapter brand = new brandTableAdapter();
        storeTableAdapter store = new storeTableAdapter();
        item_typeTableAdapter type = new item_typeTableAdapter();
        public ItemPage()
        {
            InitializeComponent();
            ItemDgr.ItemsSource = item.GetData();
            BrandCbx.ItemsSource = brand.GetData();
            PlaceCbx.ItemsSource = store.GetData();
            TypeCbx.ItemsSource = type.GetData();
            BrandCbx.DisplayMemberPath = "brand_name";
            PlaceCbx.DisplayMemberPath = "place";
            TypeCbx.DisplayMemberPath = "item_type";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(BrandCbx.SelectedItem != null && PlaceCbx.SelectedItem != null &&
                TypeCbx.SelectedItem != null)
            {
                object brand_id = (BrandCbx.SelectedItem as DataRowView).Row[0];
                object place_id = (PlaceCbx.SelectedItem as DataRowView).Row[0];
                object type_id = (TypeCbx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (ItemTbx.Text != "" && CostTbx.Text != "" && Convert.ToInt32(CostTbx.Text) >= 0)
                    {
                        item.InsertQuery(ItemTbx.Text, Convert.ToDecimal(CostTbx.Text), (int)brand_id, (int)place_id, (int)type_id);
                        ItemDgr.ItemsSource = item.GetData();
                    }
                }
                catch
                {
                    MessageBox.Show("Неверное значение");
                }
            }
            
            
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(BrandCbx.SelectedItem != null && PlaceCbx.SelectedItem != null &&
                TypeCbx.SelectedItem != null && ItemDgr.SelectedItem != null)
            {
                object brand_id = (BrandCbx.SelectedItem as DataRowView).Row[0];
                object place_id = (PlaceCbx.SelectedItem as DataRowView).Row[0];
                object type_id = (TypeCbx.SelectedItem as DataRowView).Row[0];
                object id = (ItemDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (ItemTbx.Text != "" && CostTbx.Text != "" && Convert.ToDecimal(CostTbx.Text) >= 0)
                    {
                        item.UpdateQuery(ItemTbx.Text, Convert.ToDecimal(CostTbx.Text), (int)brand_id, (int)place_id, (int)type_id, (int)id);
                        ItemDgr.ItemsSource = item.GetData();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Неверное значение"); }
            }
            
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(ItemDgr.SelectedItem != null)
            {
                object id = (ItemDgr.SelectedItem as DataRowView).Row[0];
                item.DeleteQuery((int)id);
                ItemDgr.ItemsSource = item.GetData();
            }
            
        }

        private void ItemDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(ItemDgr.SelectedItem != null)
            {
            ItemTbx.Text = (string)(ItemDgr.SelectedItem as DataRowView).Row[1];
            CostTbx.Text =(ItemDgr.SelectedItem as DataRowView).Row[2].ToString();

            }
        }
    }
}
