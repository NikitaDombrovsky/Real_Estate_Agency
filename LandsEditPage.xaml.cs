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
    /// Логика взаимодействия для LandsEditPage.xaml
    /// </summary>
    public partial class LandsEditPage : Page
    {
        private Land _land = new Land();
        public LandsEditPage(Land selectedland)
        {
            InitializeComponent();
            if (selectedland != null)
                _land = selectedland;
            DataContext = _land;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_land.Id == 0)
                Real_estate_agencyEntities2.GetContext().Lands.Add(_land);
            try
            {
                Real_estate_agencyEntities2.GetContext().SaveChanges();
                MessageBox.Show("Добавление успешно!");
                App.ParentWindowRef.ParentFrame.Navigate(new LandsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
