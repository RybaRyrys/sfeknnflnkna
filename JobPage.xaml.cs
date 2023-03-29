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
    /// Логика взаимодействия для JobPage.xaml
    /// </summary>
    public partial class JobPage : Page
    {
        jobTableAdapter job = new jobTableAdapter();
        public JobPage()
        {
            InitializeComponent();
            JobDgr.ItemsSource = job.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool isInt = int.TryParse(SalaryTbx.Text, out int result);
            try
            {
                if (JobTbx.Text == "" || isInt != true)
                {
                    MessageBox.Show("Введено неверное значение");
                }
                else
                {
                    job.InsertQuery(JobTbx.Text, Convert.ToDecimal(SalaryTbx.Text));
                    JobDgr.ItemsSource = job.GetData();
                }
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(JobDgr.SelectedItem != null)
            {
                bool isInt = int.TryParse(SalaryTbx.Text, out int result);
                object id = (JobDgr.SelectedItem as DataRowView).Row[0];
                try
                {
                    if (JobTbx.Text == "" || isInt != true)
                    {
                        MessageBox.Show("Введено неверное значение");
                    }
                    else
                    {
                        job.UpdateQuery(JobTbx.Text, Convert.ToDecimal(SalaryTbx.Text), Convert.ToInt32(id));
                        JobDgr.ItemsSource = job.GetData();
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
            if(JobDgr.SelectedItem != null)
            {
                object id = (JobDgr.SelectedItem as DataRowView).Row[0];
                job.DeleteQuery(Convert.ToInt32(id));
                JobDgr.ItemsSource = job.GetData();
            }
           
        }

        private void JobDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(JobDgr.SelectedItem != null)
            {
            JobTbx.Text = (JobDgr.SelectedItem as DataRowView).Row[1].ToString();
            SalaryTbx.Text = (JobDgr.SelectedItem as DataRowView).Row[2].ToString();

            }
        }
    }
}
