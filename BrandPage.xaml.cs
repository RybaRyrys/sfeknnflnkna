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
    /// Логика взаимодействия для BrandPage.xaml
    /// </summary>
    public partial class BrandPage : Page
    {
        brandTableAdapter brand = new brandTableAdapter();
        public BrandPage()
        {
            InitializeComponent();
            BrandDgr.ItemsSource = brand.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (BrandTbx.Text != "")
                {
                    brand.InsertQuery(BrandTbx.Text);
                    BrandDgr.ItemsSource = brand.GetData();
                }
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (BrandDgr.SelectedItem != null)
            {
                object id = (BrandDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (BrandTbx.Text != "")
                    {
                        brand.UpdateQuery(BrandTbx.Text, (int)id);
                        BrandDgr.ItemsSource = brand.GetData();
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
            if(BrandDgr.SelectedItem != null)
            {
                object id = (BrandDgr.SelectedItem as DataRowView).Row[0];
                brand.DeleteQuery((int)id);
                BrandDgr.ItemsSource = brand.GetData();
            }
            

        }

        private void BrandDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(BrandDgr.SelectedItem != null)
            {

            BrandTbx.Text = (BrandDgr.SelectedItem as DataRowView).Row[1].ToString();
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<Brand> brands = Deserialize.DeserializeObject<List<Brand>>();
            foreach(var br in brands)
            {
                brand.InsertQuery(br.name);
            }
            BrandDgr.ItemsSource = brand.GetData();
        }
    }
}
