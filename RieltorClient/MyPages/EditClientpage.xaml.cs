using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditClientpage.xaml
    /// </summary>
    public partial class EditClientpage : Page
    {
        public Client client { get; set; }
        public EditClientpage(Client _client)
        {
            client = _client;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneTb.Text.Length > 0 || EmailTb.Text.Length > 0)
            {
                string email = EmailTb.Text;
                if (Regex.IsMatch(email, @"^[\w.-]+@\w+\.\w+$"))
                {

                    var ClientId = BdConect.db.Client.Where(x => x.Name == NameTb.Text.Trim() && x.Surname == SurnameTb.Text.Trim()).FirstOrDefault();
                    if (ClientId == null)
                    {
                            BdConect.db.Client.Add(new Client
                            {
                                Email = email,
                                Name = NameTb.Text.Trim(),
                                Patronymic = PatronymicTb.Text.Trim(),
                                Surname = SurnameTb.Text.Trim(),
                                Phone = PhoneTb.Text.Trim()
                            });
                            MessageBox.Show("yes");
                            BdConect.db.SaveChanges();
                            Navigation.Nextpage(new Nav(new ClientPage()));
                        
                      

                    }

                }
                else
                {
                    MessageBox.Show($" Данная почта {email} не подходит");
                    EmailTb.Clear();
                }
            }
            else MessageBox.Show("Заполните почту или телефон");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "";
            SurnameTb.Text = "";
            PatronymicTb.Text = "";
            PhoneTb.Text = "";
            EmailTb.Text = "";
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
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

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurnameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
