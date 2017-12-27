using BMS.DataBaseData;
using BMS.DataBaseModels;
using BmsWpf.Views.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace BmsWpf.Views.ChildWindows
{
    /// <summary>
    /// Interaction logic for MainOffers.xaml
    /// </summary>
    public partial class MainOffers : Window
    {
        public MainOffers()
        {
            InitializeComponent();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            var dash = new OfferForm();
            dash.Show();
            this.Close();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }

        public void fillingDataGrid()
        {
            var db = new BmsContex();
            DataTable dt = new DataTable();
            DataColumn creator = new DataColumn("Creator", typeof(string));
            DataColumn client = new DataColumn("Client", typeof(string));
            DataColumn inquiry = new DataColumn("InquiryID", typeof(string));
            DataColumn description = new DataColumn("Description", typeof(string));
            DataColumn date = new DataColumn("Date", typeof(DateTime));

            dt.Columns.Add(creator);
            dt.Columns.Add(client);
            dt.Columns.Add(inquiry);
            dt.Columns.Add(description);
            dt.Columns.Add(date);

            var offers = db.Offers.Include(e => e.Client).Include(e => e.Creator).Include(e => e.Inquiry).ToArray();

            foreach (var offer in offers)
            {
                DataRow row = dt.NewRow();
                row[0] = offer.Creator.Username;
                row[1] = offer.Client.Name;
                row[2] = offer.Inquiry.Description;
                row[3] = offer.Description;
                row[4] = offer.Date;
                dt.Rows.Add(row);
            }


            OffersDataGrid.ItemsSource = dt.DefaultView;
        }

        private void OffersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }

        private void OffersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dash = new OfferForm();
            var dada = this.OffersDataGrid.SelectedItems as Offer;
  

            dash.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var dash = new OfferForm();
            dash.Show();
            this.Close();
        }
    }
}
