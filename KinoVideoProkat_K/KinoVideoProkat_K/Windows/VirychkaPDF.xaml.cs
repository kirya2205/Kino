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

namespace KinoVideoProkat_K.Windows
{
    /// <summary>
    /// Логика взаимодействия для VirychkaPDF.xaml
    /// </summary>
    public partial class VirychkaPDF : Window
    {
        public VirychkaPDF()
        {
            InitializeComponent();
        }

        private void BtnPDF_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("document.pdf", FileMode.Create));

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            document.Open();
            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 110;

            table.AddCell("");
            table.AddCell("IdRent");
            table.AddCell("DateStart");
            table.AddCell("DateStop");
            table.AddCell("Worker");
            table.AddCell("PhoneWorker");
            table.AddCell("Summa");
            table.AddCell("Tax");

            DateTime dateN;
            DateTime dateK;

            if (!(DateTime.TryParse(TbViruchkaS.Text, out dateN) & DateTime.TryParse(TbViruchkaP.Text, out dateK)))
            {
                MessageBox.Show("Неправильно введены даты");
                return;
            }

            var rents = App.Context.Rents.Where(x => x.DateStart >= dateN && x.DateStop <= dateK);
            decimal summ = 0;
            decimal tax = 0;

            foreach (var rent in rents)
            {
                table.AddCell("");
                table.AddCell(rent.IdRent.ToString());
                table.AddCell(rent.DateStart.ToString());
                table.AddCell(rent.DateStop.ToString());
                table.AddCell(new Phrase(rent.Worker.ToString(), font));
                table.AddCell(rent.PhoneWorker.ToString());
                table.AddCell(rent.Summa.ToString());
                table.AddCell(rent.Tax.ToString());

                tax += (decimal)rent.Tax;
                summ += (decimal)rent.Summa;
            }

            table.AddCell("Itog");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell(summ.ToString());
            table.AddCell(tax.ToString());

            document.Add(table);
            document.Close();

            Process.Start("document.pdf");
        }
    }
}
