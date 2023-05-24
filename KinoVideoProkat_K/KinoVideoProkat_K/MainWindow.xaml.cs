using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace KinoVideoProkat_K
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateLists();
        }

        public void UpdateLists()
        {
                
            try
            {
                LVFilms.ItemsSource = App.Context.Films.ToList();
                LVZakup.ItemsSource = App.Context.Purchases.ToList();
                LVKinot.ItemsSource = App.Context.Cinemas.ToList();
                LVArenda.ItemsSource = App.Context.Rents.ToList();
            }
            catch (EntityException)
            {
                MessageBox.Show("Ошибка при подключении к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }


        private void BtnAddFilm_Click(object sender, RoutedEventArgs e)
        {
            var windowAddFilm = new Windows.AddEditFilm();
            windowAddFilm.ShowDialog();
            UpdateLists();
        }
        private void BtnEditFilm_Click(object sender, RoutedEventArgs e)
        {
            if (LVFilms.SelectedItem != null)
            {
                var windowAddFilm = new Windows.AddEditFilm(LVFilms.SelectedItem as Entity.Film);
                windowAddFilm.ShowDialog();
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Фильм не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnDeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilm = LVFilms.SelectedItem as Entity.Film;

            if (LVFilms.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить фильм " + selectedFilm.NameFilm + "?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var filmsInRents = App.Context.Rents.Where(x => selectedFilm.IdFilm == x.IdFilm);
                    var filmsInPurchases = App.Context.Purchases.Where(x => x.IdFilm == selectedFilm.IdFilm);

                    if (filmsInRents.Count() > 0)
                        App.Context.Rents.RemoveRange(filmsInRents);

                    if (filmsInPurchases.Count() > 0)
                        App.Context.Purchases.RemoveRange(filmsInPurchases);

                    App.Context.Films.Remove(LVFilms.SelectedItem as Entity.Film);
                    App.Context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Фильм не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateLists();
        }




        private void BtnAddZakup_Click(object sender, RoutedEventArgs e)
        {
            var windowAddZakup = new Windows.AddEditZakup();
            windowAddZakup.ShowDialog();
            UpdateLists();
        }

        private void BtnEditZakup_Click(object sender, RoutedEventArgs e)
        {
            if (LVZakup.SelectedItem != null)
            {
                var windowAddZakup = new Windows.AddEditZakup(LVZakup.SelectedItem as Entity.Purchase);
                windowAddZakup.ShowDialog();
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Закупка не выбрана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteZakup_Click(object sender, RoutedEventArgs e)
        {
            if (LVZakup.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить закупку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.Context.Purchases.Remove(LVZakup.SelectedItem as Entity.Purchase);
                    App.Context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Закупка не выбрана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateLists();
        }



        private void BtnAddCinema_Click(object sender, RoutedEventArgs e)
        {
            var windowAddCinema = new Windows.AddEditCinema();
            windowAddCinema.ShowDialog();
            UpdateLists();
        }

        private void BtnEditCinema_Click(object sender, RoutedEventArgs e)
        {
            if (LVKinot.SelectedItem != null)
            {
                var windowAddCinema = new Windows.AddEditCinema(LVKinot.SelectedItem as Entity.Cinema);
                windowAddCinema.ShowDialog();
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Кинотеатр не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteCinema_Click(object sender, RoutedEventArgs e)
        {
            var selectedCinema = LVKinot.SelectedItem as Entity.Cinema;

            if (LVKinot.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить кинотеатр " + selectedCinema.NameCinema + "?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var cinemasInRents = App.Context.Rents.Where(x => x.IdCinema == selectedCinema.IdCinema);

                    if (cinemasInRents.Count() > 0)
                        App.Context.Rents.RemoveRange(cinemasInRents);

                    App.Context.Cinemas.Remove(LVKinot.SelectedItem as Entity.Cinema);
                    App.Context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Кинотеатр не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateLists();
        }




        private void BtnAddRent_Click(object sender, RoutedEventArgs e)
        {
            var windowAddRent = new Windows.AddEditRent();
            windowAddRent.ShowDialog();
            UpdateLists();
        }

        private void BtnEditRent_Click(object sender, RoutedEventArgs e)
        {
            if (LVArenda.SelectedItem != null)
            {
                var windowAddRent = new Windows.AddEditRent(LVArenda.SelectedItem as Entity.Rent);
                windowAddRent.ShowDialog();
                UpdateLists();
            }
            else
            {
                MessageBox.Show("Договор аренды не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteRent_Click(object sender, RoutedEventArgs e)
        {
            if (LVArenda.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить договор аренды?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.Context.Rents.Remove(LVArenda.SelectedItem as Entity.Rent);
                    App.Context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Договор аренды не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateLists();
        }

        private void BtnArendaZaMesac_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("document.pdf", FileMode.Create));

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            document.Open();
            PdfPTable table = new PdfPTable(9);
            table.WidthPercentage = 110;

            table.AddCell("IdRent");
            table.AddCell("DateStart");
            table.AddCell("DateStop");
            table.AddCell("Worker");
            table.AddCell("PhoneWorker");
            table.AddCell("Summa");
            table.AddCell("Tax");
            table.AddCell("IdCinema");
            table.AddCell("IdFilm");

            DateTime month = DateTime.Now.AddMonths(-1);
            var rents = App.Context.Rents.Where(x => month <= x.DateStart.Value);

            foreach (var rent in rents)
            {
                table.AddCell(rent.IdRent.ToString());
                table.AddCell(rent.DateStart.ToString());
                table.AddCell(rent.DateStop.ToString());
                table.AddCell(new Phrase(rent.Worker.ToString(), font));
                table.AddCell(rent.PhoneWorker.ToString());
                table.AddCell(rent.Summa.ToString());
                table.AddCell(rent.Tax.ToString());
                table.AddCell(rent.IdCinema.ToString());
                table.AddCell(rent.IdFilm.ToString());
            }

            document.Add(table);
            document.Close();

            Process.Start("document.pdf");
        }

        private void BtnDolgiZaMesac_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("document.pdf", FileMode.Create));

            document.Open();
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 110;

            table.AddCell("");
            table.AddCell("IdRent");
            table.AddCell("DateStart");
            table.AddCell("DateStop");
            table.AddCell("Tax");

            DateTime month = DateTime.Now.AddMonths(-1);
            var rents = App.Context.Rents.Where(x => month <= x.DateStart.Value);

            decimal summTax = 0;

            foreach (var rent in rents)
            {
                table.AddCell("");
                table.AddCell(rent.IdRent.ToString());
                table.AddCell(rent.DateStart.ToString());
                table.AddCell(rent.DateStop.ToString());
                table.AddCell(rent.Tax.ToString());
                summTax += (decimal)rent.Tax;
            }
            table.AddCell("Itog");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell(summTax.ToString());

            document.Add(table);
            document.Close();

            Process.Start("document.pdf");
        }

        private void BtnRatingKono_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("document.pdf", FileMode.Create));

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            document.Open();
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 40;

            table.AddCell("IdFilm");
            table.AddCell("NameFilm");
            table.AddCell("Rate");


            var films = App.Context.Films;

            foreach (var film in films)
            {
                table.AddCell(film.IdFilm.ToString());
                table.AddCell(new Phrase(film.NameFilm.ToString(), font));
                table.AddCell(film.Rate.ToString());
            }

            document.Add(table);
            document.Close();

            Process.Start("document.pdf");
        }

        private void BtnViruchkaZaMesac_Click(object sender, RoutedEventArgs e)
        {
            var windowVirPdf = new Windows.VirychkaPDF();
            windowVirPdf.ShowDialog();
        }
    }
}
