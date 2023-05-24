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
    /// Логика взаимодействия для AddEditFilm.xaml
    /// </summary>
    public partial class AddEditFilm : Window
    {
        private Entity.Film currentFilm;

        public AddEditFilm()
        {
            InitializeComponent();
        }

        public AddEditFilm(Entity.Film film)
        {
            InitializeComponent();

            currentFilm = film;

            TbName.Text = currentFilm.NameFilm;
            TbAuthor.Text = currentFilm.Author;
            TbComment.Text = currentFilm.Comment;
            TbProducer.Text = currentFilm.Producer;
            TbCompany.Text = currentFilm.Company;
            TbYear.Text = currentFilm.Year.ToString();
            TbLand.Text = currentFilm.Land;
            TbTime.Text = currentFilm.Time.ToString();
            TbCost.Text = currentFilm.Cost.ToString();
            TbRate.Text = currentFilm.Rate.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentFilm == null)
                {
                    var film = new Entity.Film
                    {
                        NameFilm = TbName.Text,
                        Author = TbAuthor.Text,
                        Comment = TbComment.Text,
                        Producer = TbProducer.Text,
                        Company = TbCompany.Text,
                        Year = Int32.Parse(TbYear.Text),
                        Land = TbLand.Text,
                        Time = TimeSpan.Parse(TbTime.Text),
                        Cost = Int32.Parse(TbCost.Text),
                        Rate = Int32.Parse(TbRate.Text)
                    };
                    App.Context.Films.Add(film);
                }
                else
                {
                    currentFilm.NameFilm = TbName.Text;
                    currentFilm.Author = TbAuthor.Text;
                    currentFilm.Comment = TbComment.Text;
                    currentFilm.Producer = TbProducer.Text;
                    currentFilm.Company = TbCompany.Text;
                    currentFilm.Year = Int32.Parse(TbYear.Text);
                    currentFilm.Land = TbLand.Text;
                    currentFilm.Time = TimeSpan.Parse(TbTime.Text);
                    currentFilm.Cost = Int32.Parse(TbCost.Text);
                    currentFilm.Rate = Int32.Parse(TbRate.Text);
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
