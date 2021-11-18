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

namespace Agency
{
    /// <summary>
    /// Логика взаимодействия для ClientEditPage.xaml
    /// </summary>
    public partial class ClientEditPage : Page
    {
        private Client _client = new Client();
        public ClientEditPage(Client selectedclient)
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            Application.Current.MainWindow.Width = 800;
            if (selectedclient != null)
                _client = selectedclient;


            DataContext = _client;
        }
        private void BtnFinalEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_client.MiddleName))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_client.Phone)) && string.IsNullOrWhiteSpace(_client.Email))
                errors.AppendLine("Укажите Номер телефона или почту");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_client.Id == 0)
                Real_estate_agencyEntities1.GetContext().Clients.Add(_client);
            try
            {
                Real_estate_agencyEntities1.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new ClientPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
