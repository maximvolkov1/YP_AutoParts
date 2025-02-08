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
    /// Логика взаимодействия для AddAutoPartsPage.xaml
    /// </summary>
    public partial class AddAutoPartsPage : Page
    {
        static AutoPartsTable autoP;
        public AddAutoPartsPage(AutoPartsTable autoParts)
        {
            InitializeComponent();
            typeAutoPartCbx.ItemsSource = Connect.context.TypeAutoParts.ToList();
            if (autoP == null)
                autoP = new AutoPartsTable();
            DataContext = autoParts = autoP;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (autoP.IdAutoPart == 0)
                Connect.context.AutoPartsTable.Add(autoP);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о автозапчасти сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                Nav.MFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }
    }
}
