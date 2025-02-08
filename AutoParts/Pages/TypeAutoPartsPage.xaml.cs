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
    /// Логика взаимодействия для TypeAutoPartsPage.xaml
    /// </summary>
    public partial class TypeAutoPartsPage : Page
    {
        public TypeAutoPartsPage()
        {
            InitializeComponent();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddTypeAutoPartsPage((sender as Button).DataContext as TypeAutoParts));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new AddTypeAutoPartsPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delTypes = typeAutoPartsLV.SelectedItems.Cast<TypeAutoParts>().ToList();
            foreach (var delType in delTypes)
            {
                if (Connect.context.AutoPartsTable.Any(x => x.IdTypeAutoPart == delType.IdTypeAutoPart))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (MessageBox.Show($"Удалить {delTypes.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Connect.context.TypeAutoParts.RemoveRange(delTypes);
                }
                try
                {
                    Connect.context.SaveChanges();
                    typeAutoPartsLV.ItemsSource = Connect.context.TypeAutoParts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var autoParts = Connect.GetCont().TypeAutoParts.ToList();
                typeAutoPartsLV.ItemsSource = autoParts;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var typeAutoPart = Connect.GetCont().TypeAutoParts.ToList();
            typeAutoPartsLV.ItemsSource = typeAutoPart;
        }
    }
}
