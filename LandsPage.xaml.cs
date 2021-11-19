﻿using System;
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
    /// Логика взаимодействия для LandsPage.xaml
    /// </summary>
    public partial class LandsPage : Page
    {
        private Land _land = new Land();
        public LandsPage()
        {
            InitializeComponent();
            DataContext = _land;
            landsDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Lands.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new LandsEditPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new LandsEditPage((sender as Button).DataContext as Land));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var landsForRemoving = landsDataGrid.SelectedItems.Cast<Land>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {landsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Real_estate_agencyEntities2.GetContext().Lands.RemoveRange(landsForRemoving);
                    Real_estate_agencyEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");


                    landsDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Lands.ToList();
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
                landsDataGrid.ItemsSource = Real_estate_agencyEntities2.GetContext().Lands.ToList();
                // clientDataGrid.Items.Refresh();
            }
        }
    }
}
