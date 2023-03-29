using itog.toy_storeDataSetTableAdapters;
using Microsoft.Win32;
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
    /// Логика взаимодействия для UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : Page
    {
        user_dataTableAdapter user_data = new user_dataTableAdapter();
        jobTableAdapter job = new jobTableAdapter();
        public UserDataPage()
        {
            InitializeComponent();
            UserDgr.ItemsSource = user_data.GetData();
            JobCbx.ItemsSource = job.GetData();
            JobCbx.DisplayMemberPath = "job_name";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (JobCbx.SelectedItem != null)
            {
                object job_id = (JobCbx.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (LogTbx.Text == "" || PasTbx.Password == "")
                    {
                        MessageBox.Show("Поле не может быть пустым");
                    }
                    else
                    {
                        user_data.InsertQuery(LogTbx.Text, PasTbx.Password, Convert.ToInt32(job_id));
                        UserDgr.ItemsSource = user_data.GetData();
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
            if (JobCbx.SelectedItem != null && UserDgr.SelectedItem != null)
            {
                object job_id = (JobCbx.SelectedItem as DataRowView).Row[0];
                object user_id = (UserDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (LogTbx.Text == "" || PasTbx.Password == "")
                    {
                        MessageBox.Show("Поле не может быть пустым");
                    }
                    else
                    {
                        user_data.UpdateQuery(LogTbx.Text, PasTbx.Password, Convert.ToInt32(job_id), Convert.ToInt32(user_id));
                        UserDgr.ItemsSource = user_data.GetData();
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
            if(UserDgr.SelectedItem != null)
            {
                object user_id = (UserDgr.SelectedItem as DataRowView).Row[0];

                if ((int)user_id != 9)
                {
                    user_data.DeleteQuery(Convert.ToInt32(user_id));
                    UserDgr.ItemsSource = user_data.GetData();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить администратора");
                }
            }
            
            
            
        }

        private void UserDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDgr.SelectedItem != null)
            {
                LogTbx.Text = (UserDgr.SelectedItem as DataRowView).Row[1].ToString();
                PasTbx.Password = (UserDgr.SelectedItem as DataRowView).Row[2].ToString();
            }
        }
    }
}
