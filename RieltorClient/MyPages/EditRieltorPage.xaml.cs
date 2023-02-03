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
    /// Логика взаимодействия для EditRieltorPage.xaml
    /// </summary>
    public partial class EditRieltorPage : Page
    {
        public Realtor realtor { get; set; }
        public EditRieltorPage(Realtor _realtor)
        {
            realtor = _realtor;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var RealtId = BdConect.db.Realtor.Where(x => x.Name == NameTb.Text.Trim() && x.Surname == SurnameTb.Text.Trim()).FirstOrDefault();
            if (RealtId == null)
            {
                if (NameTb.Text.Length > 0 || PatronymicTb.Text.Length > 0 || SurnameTb.Text.Length>0)
                {
                   
                        BdConect.db.Realtor.Add(new Realtor
                        {

                            Name = NameTb.Text.Trim(),
                            Patronymic = PatronymicTb.Text.Trim(),
                            Surname = SurnameTb.Text.Trim(),
                            CommissionShare = int.Parse(CommissionShareTb.Text.Trim())
                     });
                        MessageBox.Show("yes");
                        BdConect.db.SaveChanges();
                        Navigation.Nextpage(new Nav(new RieltorPage()));

                   
                }
                else MessageBox.Show("Заполните полностью фио ");

            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "";
            SurnameTb.Text = "";
            PatronymicTb.Text = "";
            CommissionShareTb.Text = "";

        }

        private void SurnameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PatronymicTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
