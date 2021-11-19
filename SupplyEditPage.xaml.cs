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
    /// Логика взаимодействия для SupplyEditPage.xaml
    /// </summary>
    public partial class SupplyEditPage : Page
    {
        public Supply _supply = new Supply();
        public SupplyEditPage(Supply selectedsupply)
        {
            InitializeComponent();
            if (selectedsupply != null)
                _supply = selectedsupply;
            DataContext = _supply;
            ComboAgent.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
            ComboClient.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
            ComboDistricts.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_supply.Id == 0)
                Real_estate_agencyEntities2.GetContext().Supplies.Add(_supply);
            try
            {
                Real_estate_agencyEntities2.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new SupplyPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
