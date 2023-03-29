using itog.toy_storeDataSetTableAdapters;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        user_dataTableAdapter user_data = new user_dataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            UserWindow user= new UserWindow();
            var data = user_data.GetData().Rows;
            try
            {
                for (int i = 0; i < data.Count; i++)
                {
                    int role = (int)data[i][3];
                    if (LogTbx.Text == data[i][1].ToString() &&
                        PasTbx.Password == data[i][2].ToString())
                    {
                        switch (role)
                        {
                            case 7: admin.Show(); break;
                            case 8: user.Show(); break;
                            case 9: user.Show(); break;
                        }

                        Close();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
            
        }
    }
}
