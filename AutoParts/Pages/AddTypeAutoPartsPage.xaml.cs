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
    /// Логика взаимодействия для AddTypeAutoPartsPage.xaml
    /// </summary>
    public partial class AddTypeAutoPartsPage : Page
    {
        static TypeAutoParts typeAP;
        public AddTypeAutoPartsPage(TypeAutoParts typeAutoParts)
        {
            InitializeComponent();
            if (typeAP == null)
                typeAP = new TypeAutoParts();
            DataContext = typeAutoParts = typeAP;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (typeAP.IdTypeAutoPart == 0)
                Connect.context.TypeAutoParts.Add(typeAP);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о виде запчасти сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
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
