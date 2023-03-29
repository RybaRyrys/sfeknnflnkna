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
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        workerTableAdapter worker = new workerTableAdapter();
        user_dataTableAdapter user = new user_dataTableAdapter();
        public WorkerPage()
        {
            InitializeComponent();
            WorkerDgr.ItemsSource = worker.GetData();
            UserBx.ItemsSource = user.GetData();
            UserBx.DisplayMemberPath = "user_data_id";
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(UserBx.SelectedItem != null)
            {
                object id = (UserBx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (NameBx.Text != "" && SurBx.Text != "")
                    {
                        worker.InsertQuery(NameBx.Text, SurBx.Text, PatrBx.Text, Convert.ToInt32(id));
                        WorkerDgr.ItemsSource = worker.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Введено неверное значение");
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
            if(WorkerDgr.SelectedItem != null && UserBx.SelectedItem != null)
            {
                object worker_id = (WorkerDgr.SelectedItem as DataRowView).Row[0];
                object id = (UserBx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (NameBx.Text != "" && SurBx.Text != "")
                    {
                        worker.UpdateQuery(NameBx.Text, SurBx.Text, PatrBx.Text, Convert.ToInt32(id), Convert.ToInt32(worker_id));
                        WorkerDgr.ItemsSource = worker.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Введено неверное значение");
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
            if (WorkerDgr.SelectedItem != null)
            {
            object worker_id = (WorkerDgr.SelectedItem as DataRowView).Row[0];
            worker.DeleteQuery(Convert.ToInt32(worker_id));
            WorkerDgr.ItemsSource = worker.GetData();

            }
        }

        private void WorkerDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(WorkerDgr.SelectedItem != null)
            {
            NameBx.Text = (WorkerDgr.SelectedItem as DataRowView).Row[1].ToString();
            SurBx.Text = (WorkerDgr.SelectedItem as DataRowView).Row[2].ToString();
            PatrBx.Text = (WorkerDgr.SelectedItem as DataRowView).Row[3].ToString();

            }
        }
    }
}
