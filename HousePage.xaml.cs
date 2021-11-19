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
    /// Логика взаимодействия для HousePage.xaml
    /// </summary>
    public partial class HousePage : Page
    {
        public House _house = new House();
        public HousePage()
        {
            InitializeComponent();
            DataContext = _house;
            houseDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Houses.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new HouseEditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new HouseEditPage((sender as Button).DataContext as House));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var houseForRemoving = houseDataGrid.SelectedItems.Cast<House>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {houseForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Real_estate_agencyEntities2.GetContext().Houses.RemoveRange(houseForRemoving);
                    Real_estate_agencyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    houseDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Houses.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }


        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Real_estate_agencyEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                houseDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Houses.ToList();
                // clientDataGrid.Items.Refresh();
            }
        }
    }
}
