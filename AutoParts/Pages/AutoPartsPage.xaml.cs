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
    /// Логика взаимодействия для AutoPartsPage.xaml
    /// </summary>
    public partial class AutoPartsPage : Page
    {
        public AutoPartsPage()
        {
            InitializeComponent();
            
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddAutoPartsPage((sender as Button).DataContext as AutoPartsTable));
        }
    

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddAutoPartsPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delAutoParts = autoPartsLV.SelectedItems.Cast<AutoPartsTable>().ToList();
            foreach (var delAutoPart in delAutoParts)
            {
                if (Connect.context.AutoPartsTable.Any(x => x.IdAutoPart == delAutoPart.IdAutoPart))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delAutoParts.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.AutoPartsTable.RemoveRange(delAutoParts);
                }
                try
                {
                    Connect.context.SaveChanges();
                    autoPartsLV.ItemsSource = Connect.context.AutoPartsTable.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var autoParts = Connect.GetCont().TypeAutoParts.ToList();
                autoPartsLV.ItemsSource = autoParts;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var autoParts = Connect.GetCont().AutoPartsTable.ToList();
            autoPartsLV.ItemsSource = autoParts;
        }
    }
}
