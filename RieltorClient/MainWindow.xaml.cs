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

namespace RieltorClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.main = this;
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Nextpage(new Nav(new ClientPage()));
        }

        private void RealBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Nextpage(new Nav(new RieltorPage()));
        }
    }
}
