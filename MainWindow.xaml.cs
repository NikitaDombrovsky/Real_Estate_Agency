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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        private static Real_estate_agencyEntities2 _context;
        public Real_estate_agencyEntities2()
            : base("name=Real_estate_agencyEntities2")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public static Real_estate_agencyEntities2 GetContext()
        {
            if (_context == null)
                _context = new Real_estate_agencyEntities2();
            return _context;
        }
        */
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef = this;
            Application.Current.MainWindow.Height = 350;
            this.ParentFrame.Navigate(new MainPage());
            
        }

        private void ParentFrame_ContentRendered(object sender, EventArgs e)
        {
            ParentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            if (ParentFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            this.ParentFrame.Navigate(new MainPage());
            //
           // App.ParentWindowRef.ParentFrame.Navigate(new MainPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.ParentFrame.GoBack();
        }
    }
}
