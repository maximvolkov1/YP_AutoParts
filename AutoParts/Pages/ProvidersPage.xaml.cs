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
    /// Логика взаимодействия для ProvidersPage.xaml
    /// </summary>
    public partial class ProvidersPage : Page
    {
        public ProvidersPage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddProviderPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delProviders = providersLV.SelectedItems.Cast<Providers>().ToList();
            foreach (var delProvider in delProviders)
            {
                if (Connect.context.Supply.Any(x => x.IdProvider == delProvider.IdProvider))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delProviders.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.Providers.RemoveRange(delProviders);
                }
                try
                {
                    Connect.context.SaveChanges();
                    providersLV.ItemsSource = Connect.context.Providers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var supply = Connect.GetCont().Providers.ToList();
                providersLV.ItemsSource = supply;
            }
        }
            private void editBtn_Click(object sender, RoutedEventArgs e)
            {
            Nav.MFrame.Navigate(new AddProviderPage((sender as Button).DataContext as Providers));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var provider = Connect.GetCont().Providers.ToList();
            providersLV.ItemsSource = provider;
        }
    }
}

