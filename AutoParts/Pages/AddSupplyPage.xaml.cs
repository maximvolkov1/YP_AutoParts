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
    /// Логика взаимодействия для AddSupplyPage.xaml
    /// </summary>
    public partial class AddSupplyPage : Page
    {
        Supply supply;
        public AddSupplyPage(Supply supplys)
        {
            InitializeComponent();
            typeAutoPartCbx.ItemsSource = Connect.context.TypeAutoParts.ToList();
            autoPartsCbx.ItemsSource = Connect.context.AutoPartsTable.ToList();
            providerCbx.ItemsSource = Connect.context.Providers.ToList();
            if (supply == null)
                supply = new Supply();
            DataContext = supplys = supply;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (supply.IdSupply == 0)
                Connect.context.Supply.Add(supply);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о поставке сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                Nav.MFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

