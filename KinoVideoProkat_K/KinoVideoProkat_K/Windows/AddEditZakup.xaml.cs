using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddEditZakup.xaml
    /// </summary>
    public partial class AddEditZakup : Window
    {
        private Entity.Purchase currentZakup;

        public AddEditZakup()
        {
            InitializeComponent();

            CbFilm.ItemsSource = App.Context.Films.Select(x => x.NameFilm).ToList();
            CbFilm.SelectedIndex = 0;
            CbProvider.ItemsSource = App.Context.Providers.Select(x => x.NameProvider).ToList();
            CbProvider.SelectedIndex = 0;
        }
        public AddEditZakup(Entity.Purchase zakup)
        {
            InitializeComponent();

            currentZakup = zakup;

            CbFilm.ItemsSource = App.Context.Films.Select(x => x.NameFilm).ToList();
            CbFilm.SelectedItem = App.Context.Films.Where(x => currentZakup.IdFilm == x.IdFilm).Select(x => x.NameFilm).FirstOrDefault();
            CbProvider.ItemsSource = App.Context.Providers.Select(x => x.NameProvider).ToList();
            CbProvider.SelectedItem = App.Context.Providers.Where(x => currentZakup.IdProvider == x.IdProvider).Select(x => x.NameProvider).FirstOrDefault();

            TbDateBuy.Text = currentZakup.DateBuy.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentZakup == null)
                {
                    var zakup = new Entity.Purchase
                    {
                        IdFilm = App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.IdFilm).FirstOrDefault(),
                        IdProvider = App.Context.Providers.Where(x => x.NameProvider == CbProvider.SelectedItem.ToString()).Select(x => x.IdProvider).FirstOrDefault(),
                        DateBuy = DateTime.Parse(TbDateBuy.Text),
                        Summ = (decimal)(App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString())
                                            .Select(x => x.Cost).FirstOrDefault() * 1.10)
                    };
                    App.Context.Purchases.Add(zakup);
                }
                else
                {
                    currentZakup.IdFilm = App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.IdFilm).FirstOrDefault();
                    currentZakup.IdProvider = App.Context.Providers.Where(x => x.NameProvider == CbProvider.SelectedItem.ToString()).Select(x => x.IdProvider).FirstOrDefault();
                    currentZakup.DateBuy = DateTime.Parse(TbDateBuy.Text);
                    currentZakup.Summ = (decimal)(App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString())
                                            .Select(x => x.Cost).FirstOrDefault() * 1.10);
                }

                App.Context.SaveChanges();

                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnSumm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmCost = (int)App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString())
                .Select(x => x.Cost).FirstOrDefault();

                decimal summ = (decimal)(filmCost * 1.10);

                MessageBox.Show("Стоимость фильма: " + filmCost +
                                "\nНадбавка: 10%" +
                                "\nСумма продажи: " + summ);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
