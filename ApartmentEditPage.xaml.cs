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
    /// Логика взаимодействия для ApartmentEditPage.xaml
    /// </summary>
    public partial class ApartmentEditPage : Page
    {
        private Apartment _apartment = new Apartment();
        public ApartmentEditPage(Apartment selectedapartment)
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            Application.Current.MainWindow.Width = 800;
            if (selectedapartment != null)
                _apartment = selectedapartment;
            DataContext = _apartment;
            ComboDistricts.ItemsSource = Real_estate_agencyEntities2.GetContext().Districts.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_apartment.Address_City))
                errors.AppendLine("Укажите Город");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_apartment.Address_House)))
                errors.AppendLine("Укажите Дом");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_apartment.Address_Number)))
                errors.AppendLine("Укажите Адрес");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_apartment.Address_Street)))
                errors.AppendLine("Укажите Улицу");
            if (_apartment.Coordinate_latitude > 90 || _apartment.Coordinate_latitude < -90)
                errors.AppendLine("Широта может принимать значения от -90 до 90");
            if (_apartment.Coordinate_longitude > 180 || _apartment.Coordinate_longitude < -180)
                errors.AppendLine("Долгота может принимать значения от -180 до 180");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_apartment.Id == 0)
                Real_estate_agencyEntities2.GetContext().Apartments.Add(_apartment);
            try
            {
                Real_estate_agencyEntities2.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new ApartmentPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
