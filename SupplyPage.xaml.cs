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
    /// Логика взаимодействия для Supply.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        private Supply_View _supplyView = new Supply_View();
        public SupplyPage()
        {
            InitializeComponent();
            DataContext = _supplyView;
            supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supply_View.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ClientEditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ClientEditPage((sender as Button).DataContext as Client));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var supplyForRemoving = supplyDataGrid.SelectedItems.Cast<Supply_View>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {supplyForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Real_estate_agencyEntities2.GetContext().Supply_View.RemoveRange(supplyForRemoving);
                    Real_estate_agencyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supply_View.ToList();
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
                supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supply_View.ToList();
                // clientDataGrid.Items.Refresh();
            }
        }
    }
}
