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
    /// Логика взаимодействия для REditPage.xaml
    /// </summary>
    public partial class REditPage : Page
    {
        private Agent _agent = new Agent();
        public REditPage(Agent selectedagent)
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            Application.Current.MainWindow.Width = 800;
            if (selectedagent != null)
                _agent = selectedagent;

            DataContext = _agent;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_agent.MiddleName))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_agent.FirstName))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(_agent.LastName))
                errors.AppendLine("Укажите Отчество");
            if (_agent.DealShare > 100 || _agent.DealShare < 0)
                errors.AppendLine("Доля от комиссии не может быть больше 100");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_agent.Id == 0)
                Real_estate_agencyEntities2.GetContext().Agents.Add(_agent);
            try
            {
                Real_estate_agencyEntities2.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new RPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
