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
    /// Логика взаимодействия для ApartmentPage.xaml
    /// </summary>
    public partial class ApartmentPage : Page
    {
        private Apartment _apartment = new Apartment();
        public ApartmentPage()
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            Application.Current.MainWindow.Width = 800;
            DataContext = _apartment;
            apartmentDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Apartments.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ApartmentEditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ApartmentEditPage((sender as Button).DataContext as Apartment));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var apartmentForRemoving = apartmentDataGrid.SelectedItems.Cast<Apartment>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {apartmentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    
                    Real_estate_agencyEntities2.GetContext().Apartments.RemoveRange(apartmentForRemoving);
                    Real_estate_agencyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                   

                    apartmentDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Apartments.ToList();
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
                apartmentDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Apartments.ToList();
                // clientDataGrid.Items.Refresh();
            }
        }
    }
}
