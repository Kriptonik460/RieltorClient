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
using RieltorClient.Componens;
using RieltorClient.MyPages;

namespace RieltorClient.MyPages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            ClientList.ItemsSource = BdConect.db.Client.ToList();

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var cl = (sender as Button).DataContext as Client;
            Navigation.Nextpage(new Nav(new EditClientpage(cl)));
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = (sender as Button).DataContext as Client;
            if (MessageBox.Show("Вы точно хотите удалить эту запись","Уведомление",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BdConect.db.Client.Remove(client);
            }
            BdConect.db.SaveChanges();
            ClientList.ItemsSource = BdConect.db.Client.ToList();
        }

        private void NewCkient_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Nextpage(new Nav(new EditClientpage(new Client())));

        }
    }
}
