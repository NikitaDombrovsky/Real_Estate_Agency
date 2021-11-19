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
        private Supply _supplyView = new Supply();
        public SupplyPage()
        {
            InitializeComponent();
            
            DataContext = _supplyView;
            supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new SupplyEditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new SupplyEditPage((sender as Button).DataContext as Supply));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var supplyForRemoving = supplyDataGrid.SelectedItems.Cast<Supply>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {supplyForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Real_estate_agencyEntities2.GetContext().Supplies.RemoveRange(supplyForRemoving);
                    Real_estate_agencyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
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
                supplyDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Supplies.ToList();
                // clientDataGrid.Items.Refresh();
            }
        }
    }
}
