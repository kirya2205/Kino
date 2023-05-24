using KinoVideoProkat_K.Entity;
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
using System.Windows.Shapes;

namespace KinoVideoProkat_K.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditRent.xaml
    /// </summary>
    public partial class AddEditRent : Window
    {
        private Entity.Rent currentRent;

        public AddEditRent()
        {
            InitializeComponent();

            CbFilm.ItemsSource = App.Context.Films.Select(x => x.NameFilm).ToList();
            CbFilm.SelectedIndex = 0;
            CbCinema.ItemsSource = App.Context.Cinemas.Select(x => x.NameCinema).ToList();
            CbCinema.SelectedIndex = 0;
        }

        public AddEditRent(Entity.Rent rent)
        {
            InitializeComponent();

            currentRent = rent;

            CbFilm.ItemsSource = App.Context.Films.Select(x => x.NameFilm).ToList();
            CbFilm.SelectedItem = App.Context.Films.Where(x => currentRent.IdFilm == x.IdFilm).Select(x => x.NameFilm).FirstOrDefault();
            CbCinema.ItemsSource = App.Context.Cinemas.Select(x => x.NameCinema).ToList();
            CbCinema.SelectedItem = App.Context.Cinemas.Where(x => currentRent.IdCinema == x.IdCinema).Select(x => x.NameCinema).FirstOrDefault();

            TbDateStart.Text = currentRent.DateStart.ToString();
            TbDateStop.Text = currentRent.DateStop.ToString();
            TbWorker.Text = currentRent.Worker;
            TbPhoneWorker.Text = currentRent.PhoneWorker;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRent == null)
                {
                    var rent = new Entity.Rent
                    {
                        IdFilm = App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.IdFilm).FirstOrDefault(),
                        IdCinema = App.Context.Cinemas.Where(x => x.NameCinema == CbCinema.SelectedItem.ToString()).Select(x => x.IdCinema).FirstOrDefault(),
                        DateStart = DateTime.Parse(TbDateStart.Text),
                        DateStop = DateTime.Parse(TbDateStop.Text),
                        Worker = TbWorker.Text,
                        PhoneWorker = TbPhoneWorker.Text,
                        Summa = SummZaDen(App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.Land).FirstOrDefault(),
                                                (double)App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.Cost).FirstOrDefault())
                                        * (DateTime.Parse(TbDateStop.Text) - DateTime.Parse(TbDateStart.Text)).Days,
                        Tax = 0
                    };
                    App.Context.Rents.Add(rent);
                }
                else
                {
                    currentRent.IdFilm = App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.IdFilm).FirstOrDefault();
                    currentRent.IdCinema = App.Context.Cinemas.Where(x => x.NameCinema == CbCinema.SelectedItem.ToString()).Select(x => x.IdCinema).FirstOrDefault();
                    currentRent.DateStart = DateTime.Parse(TbDateStart.Text);
                    currentRent.DateStop = DateTime.Parse(TbDateStop.Text);
                    currentRent.Worker = TbWorker.Text;
                    currentRent.PhoneWorker = TbPhoneWorker.Text;
                    currentRent.Summa = SummZaDen(App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.Land).FirstOrDefault(),
                                                (double)App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString()).Select(x => x.Cost).FirstOrDefault()) 
                                        * (DateTime.Parse(TbDateStop.Text) - DateTime.Parse(TbDateStart.Text)).Days;
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
                string land = App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString())
                .Select(x => x.Land).FirstOrDefault();
                double filmCost = (double)App.Context.Films.Where(x => x.NameFilm == CbFilm.SelectedItem.ToString())
                    .Select(x => x.Cost).FirstOrDefault();

                int summZaDen = SummZaDen(land, filmCost);

                MessageBox.Show("Стоимость фильма: " + filmCost +
                                    "\nСтрана производства фильма: " + land +
                                    "\nСумма аренды: " + summZaDen * (DateTime.Parse(TbDateStop.Text) - DateTime.Parse(TbDateStart.Text)).Days);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private int SummZaDen(string land, double filmCost)
        {
            int summ;
            if (land == "США")
            {
                summ = (int)(filmCost / 92 * 0.33);
            }
            else if (land == "Россия")
            {
                summ = (int)(filmCost / 92 * 0.10);
            }
            else
            {
                summ = (int)(filmCost / 92 * 0.20);
            }
            return summ;
        }
    }
}
