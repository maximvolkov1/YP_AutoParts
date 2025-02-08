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
    /// Логика взаимодействия для SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public SalesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var sale = Connect.GetCont().Sale.ToList();
            saleLV.ItemsSource = sale;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddSalesPage((sender as Button).DataContext as Sale));
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddSalesPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
                var delSales = saleLV.SelectedItems.Cast<Sale>().ToList();
            foreach (var delSale in delSales)
            {
                if (Connect.context.Sale.Any(x => x.IdSale == delSale.IdSale))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delSales.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.Sale.RemoveRange(delSales);
                }
                try
                {
                    Connect.context.SaveChanges();
                    saleLV.ItemsSource = Connect.context.Sale.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var sale = Connect.GetCont().Sale.ToList();
                saleLV.ItemsSource = sale;
            }
        }
    }
}
