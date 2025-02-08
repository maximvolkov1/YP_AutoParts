using AutoParts.AppDate;
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

namespace AutoParts.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void autoPartsMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AutoPartsPage());
        }

        private void clientsMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new ClientsPage());
        }

        private void providersMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new ProvidersPage());
        }

        private void supplyMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new SupplyPage());
        }

        private void saleMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new SalesPage());
        }

        private void typeAutoPartsMI_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new TypeAutoPartsPage());
        }
    }
}
