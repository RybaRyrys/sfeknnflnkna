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
    /// Логика взаимодействия для ItemTypePage.xaml
    /// </summary>
    public partial class ItemTypePage : Page
    {
        item_typeTableAdapter type = new item_typeTableAdapter();
        public ItemTypePage()
        {
            InitializeComponent();
            TypeDgr.ItemsSource = type.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeTbx.Text != "")
                {
                    type.InsertQuery(TypeTbx.Text);
                    TypeDgr.ItemsSource = type.GetData();
                }
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }           
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(TypeDgr.SelectedItem != null)
            {
                object id = (TypeDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (TypeTbx.Text != "")
                    {
                        type.UpdateQuery(TypeTbx.Text, (int)id);
                        TypeDgr.ItemsSource = type.GetData();
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
            if(TypeDgr.SelectedItem != null)
            {
                object id = (TypeDgr.SelectedItem as DataRowView).Row[0];
                type.DeleteQuery((int)id);
                TypeDgr.ItemsSource = type.GetData();
            }
            
        }

        private void TypeDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TypeDgr.SelectedItem != null)
            {
            TypeTbx.Text = (TypeDgr.SelectedItem as DataRowView).Row[1].ToString();

            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<ItemType> types = Deserialize.DeserializeObject<List<ItemType>>();
            foreach (var t in types)
            {
                type.InsertQuery(t.name);
            }
            TypeDgr.ItemsSource = type.GetData();
        }
    }
}
