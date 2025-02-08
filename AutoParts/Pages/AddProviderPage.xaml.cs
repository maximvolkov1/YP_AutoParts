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
    /// Логика взаимодействия для AddProviderPage.xaml
    /// </summary>
    public partial class AddProviderPage : Page
    {
        static Providers pro;
        public AddProviderPage(Providers providers)
        {
            InitializeComponent();
            if (pro == null)
                pro = new Providers();
            DataContext = providers = pro;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.GoBack();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pro.IdProvider == 0)
                Connect.context.Providers.Add(pro);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о поставщике сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                Nav.MFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
