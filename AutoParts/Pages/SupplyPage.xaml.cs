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
    /// Логика взаимодействия для SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        public SupplyPage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddSupplyPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delSupplys= supplyLV.SelectedItems.Cast<Supply>().ToList();
            foreach (var delSupply in delSupplys)
            {
                if (Connect.context.Supply.Any(x => x.IdSupply == delSupply.IdSupply))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delSupplys.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.Supply.RemoveRange(delSupplys);
                }
                try
                {
                    Connect.context.SaveChanges();
                    supplyLV.ItemsSource = Connect.context.Supply.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var supply = Connect.GetCont().Supply.ToList();
                supplyLV.ItemsSource = supply;
            }
        }

            private void editBtn_Click(object sender, RoutedEventArgs e)
            {
            Nav.MFrame.Navigate(new AddSupplyPage((sender as Button).DataContext as Supply));
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                var supply = Connect.GetCont().Supply.ToList();
                supplyLV.ItemsSource = supply;
            }
    }
}

