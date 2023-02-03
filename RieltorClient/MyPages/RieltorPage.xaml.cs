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
    /// Логика взаимодействия для RieltorPage.xaml
    /// </summary>
    public partial class RieltorPage : Page
    {
        public RieltorPage()
        {
            InitializeComponent();
            RieltorList.ItemsSource = BdConect.db.Realtor.ToList();

        }


        private void NewCkient_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Nextpage(new Nav(new EditRieltorPage(new Realtor())));

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var real = (sender as Button).DataContext as Realtor;
            Navigation.Nextpage(new Nav(new EditRieltorPage(real)));
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var real = (sender as Button).DataContext as Realtor;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BdConect.db.Realtor.Remove(real);
            }
            BdConect.db.SaveChanges();
            RieltorList.ItemsSource = BdConect.db.Realtor.ToList();
        }
    }
}
