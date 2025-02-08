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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddClientsPage(null));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddClientsPage((sender as Button).DataContext as Clients));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = clientsLV.SelectedItems.Cast<Clients>().ToList();
            foreach (var delClient in delClients)
            {
                if (Connect.context.Sale.Any(x => x.IdClient == delClient.IdClient))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.Clients.RemoveRange(delClients);
                }
                try
                {
                    Connect.context.SaveChanges();
                    clientsLV.ItemsSource = Connect.context.Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var sale = Connect.GetCont().Clients.ToList();
                clientsLV.ItemsSource = sale;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var client = Connect.GetCont().Clients.ToList();
            clientsLV.ItemsSource = client;
        }
    }
}
