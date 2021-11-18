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
using System.Data.Entity;
using System.Data;

namespace Agency
{
    /// <summary>
    /// Логика взаимодействия для RPage.xaml
    /// </summary>
    public partial class RPage : Page
    {
        //Real_estate_agencyEntities REA_Entities = new Real_estate_agencyEntities();
        //CollectionViewSource collectionViewSource;
        private Agent _agent = new Agent();
        public RPage()
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 350;
            Application.Current.MainWindow.Width = 800;
            DataContext = _agent;
            agentDataGrid.ItemsSource = Real_estate_agencyEntities1.GetContext().Agents.ToList();
            //collectionViewSource = ((CollectionViewSource)(FindResource("agentViewSource")));
            //DataContext = this;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //REA_Entities.Clients.Load();
            //collectionViewSource.Source = REA_Entities.Clients.Local;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new REditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new REditPage((sender as Button).DataContext as Agent));
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var agentForRemoving = agentDataGrid.SelectedItems.Cast<Agent>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {agentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Real_estate_agencyEntities1.GetContext().Agents.RemoveRange(agentForRemoving);
                    Real_estate_agencyEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    agentDataGrid.ItemsSource = Real_estate_agencyEntities1.GetContext().Clients.ToList();
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
                Real_estate_agencyEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                agentDataGrid.ItemsSource = Real_estate_agencyEntities1.GetContext().Agents.ToList();
            }
        }



    }
}
