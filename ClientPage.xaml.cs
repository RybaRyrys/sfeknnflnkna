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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        clientTableAdapter client = new clientTableAdapter();
        user_dataTableAdapter user = new user_dataTableAdapter();
        public ClientPage()
        {
            InitializeComponent();
            UserBx.ItemsSource = user.GetData();
            ClientDgr.ItemsSource = client.GetData();
            UserBx.DisplayMemberPath = "user_data_id";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (UserBx.SelectedItem != null)
            {
                object id = (UserBx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (NameBx.Text != "" && SurBx.Text != "" && TelBx.Text != "")
                    {
                        client.InsertQuery(NameBx.Text, SurBx.Text, Convert.ToInt32(TelBx.Text), Convert.ToInt32(id));
                        ClientDgr.ItemsSource = client.GetData();
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
            if (ClientDgr.SelectedItem != null && UserBx.SelectedItem != null)
            {
                object client_id = (ClientDgr.SelectedItem as DataRowView).Row[0];
                object user_id = (UserBx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (NameBx.Text != "" && SurBx.Text != "" && TelBx.Text != "")
                    {
                        client.UpdateQuery(NameBx.Text, SurBx.Text, Convert.ToInt32(TelBx.Text), Convert.ToInt32(user_id), Convert.ToInt32(client_id));
                        ClientDgr.ItemsSource = client.GetData();
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
            if(ClientDgr.SelectedItem != null)
            {
                object client_id = (ClientDgr.SelectedItem as DataRowView).Row[0];
                client.DeleteQuery((int)client_id);
                ClientDgr.ItemsSource = client.GetData();
            }
            
        }

        private void ClientDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ClientDgr.SelectedItem != null)
            {
            NameBx.Text = (ClientDgr.SelectedItem as DataRowView).Row[1].ToString();
            SurBx.Text = (ClientDgr.SelectedItem as DataRowView).Row[2].ToString();
            TelBx.Text = (ClientDgr.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
