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
    /// Логика взаимодействия для HouseEditPage.xaml
    /// </summary>
    public partial class HouseEditPage : Page
    {
        private House _house = new House();
        public HouseEditPage(House selectedhouse)
        {
            InitializeComponent();
            if (selectedhouse != null)
                _house = selectedhouse;
            DataContext = _house;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_house.Id == 0)
                Real_estate_agencyEntities2.GetContext().Houses.Add(_house);
            try
            {
                Real_estate_agencyEntities2.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new HousePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
