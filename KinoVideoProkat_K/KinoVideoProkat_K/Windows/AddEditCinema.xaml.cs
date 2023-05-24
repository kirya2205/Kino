using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace KinoVideoProkat_K.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCinema.xaml
    /// </summary>
    public partial class AddEditCinema : Window
    {
        private Entity.Cinema currentCinema;

        public AddEditCinema()
        {
            InitializeComponent();
        }

        public AddEditCinema(Entity.Cinema cinema)
        {
            InitializeComponent();

            currentCinema = cinema;

            TbNameCinema.Text = currentCinema.NameCinema;
            TbINNCinema.Text = currentCinema.INNCinema.ToString();
            TbAddress.Text = currentCinema.Address;
            TbChief.Text = currentCinema.Chief;
            TbPhoneChief.Text = currentCinema.PhoneChief;
            TbOwner.Text = currentCinema.Owner;
            TbPhoneOwner.Text = currentCinema.PhoneOwner;
            TbPhone.Text = currentCinema.Phone;
            TbDistrict.Text = currentCinema.District;
            TbBankCinema.Text = currentCinema.BankCinema;
            TbAccountCinema.Text = currentCinema.AccountCinema.ToString();
            TbCapacity.Text = currentCinema.Capacity.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentCinema == null)
                {
                    var cinema = new Entity.Cinema
                    {
                        NameCinema = TbNameCinema.Text,
                        INNCinema = long.Parse(TbINNCinema.Text),
                        Address = TbAddress.Text,
                        Chief = TbChief.Text,
                        PhoneChief = TbPhoneChief.Text,
                        Owner = TbOwner.Text,
                        PhoneOwner = TbPhoneOwner.Text,
                        Phone = TbPhone.Text,
                        District = TbDistrict.Text,
                        BankCinema = TbBankCinema.Text,
                        AccountCinema = long.Parse(TbAccountCinema.Text),
                        Capacity = int.Parse(TbCapacity.Text)
                    };
                    App.Context.Cinemas.Add(cinema);
                }
                else
                {
                    currentCinema.NameCinema = TbNameCinema.Text;
                    currentCinema.INNCinema = long.Parse(TbINNCinema.Text);
                    currentCinema.Address = TbAddress.Text;
                    currentCinema.Chief = TbChief.Text;
                    currentCinema.PhoneChief = TbPhoneChief.Text;
                    currentCinema.Owner = TbOwner.Text;
                    currentCinema.PhoneOwner = TbPhoneOwner.Text;
                    currentCinema.Phone = TbPhone.Text;
                    currentCinema.District = TbDistrict.Text;
                    currentCinema.BankCinema = TbBankCinema.Text;
                    currentCinema.AccountCinema = long.Parse(TbAccountCinema.Text);
                    currentCinema.Capacity = int.Parse(TbCapacity.Text);
                }

                App.Context.SaveChanges();


                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
