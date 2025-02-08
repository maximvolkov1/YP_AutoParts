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
    /// Логика взаимодействия для AddClientsPage.xaml
    /// </summary>
    public partial class AddClientsPage : Page
    {
        static Clients cli;
        
        public AddClientsPage(Clients clients)
        {
            InitializeComponent();
            if (cli == null)
                cli = new Clients();
            DataContext = clients = cli;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cli.IdClient == 0)
                Connect.context.Clients.Add(cli);
            try
            {
                Connect.GetCont().SaveChanges();
                MessageBox.Show("Информация о клиенте сохранена", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
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
