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
    /// Логика взаимодействия для AddSalesPage.xaml
    /// </summary>
    public partial class AddSalesPage : Page
    {
        Sale s;
        public AddSalesPage(Sale sales)
        {
            InitializeComponent();
            clientCbx.ItemsSource = Connect.context.Clients.ToList();
            autoPartsCbx.ItemsSource = Connect.context.AutoPartsTable.ToList();
            typeAutoPartCbx.ItemsSource = Connect.context.TypeAutoParts.ToList();
            if (s == null)
                s = new Sale();
            DataContext = sales = s;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (s.IdSale == 0)
                Connect.context.Sale.Add(s);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о продаже сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                Nav.MFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
