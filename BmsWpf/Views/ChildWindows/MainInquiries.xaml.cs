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
    /// Interaction logic for MainInquiries.xaml
    /// </summary>
    public partial class MainInquiries : Window
    {
        public MainInquiries()
        {
            InitializeComponent();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            var dash = new InquireForm();
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
            DataColumn inquiryId = new DataColumn("Id", typeof(int));
            DataColumn creator = new DataColumn("Creator", typeof(string));
            DataColumn client = new DataColumn("Client", typeof(string));
            DataColumn description = new DataColumn("Description", typeof(string));
            DataColumn date = new DataColumn("Date", typeof(DateTime));

            dt.Columns.Add(inquiryId);
            dt.Columns.Add(creator);
            dt.Columns.Add(client);
            dt.Columns.Add(description);
            dt.Columns.Add(date);


            var inquiries = db.Inquiries.Include(e => e.Contragent).Include(e => e.Creator).ToArray();

            foreach (var inqu in inquiries)
            {
                DataRow row = dt.NewRow();
                row[0] = inqu.Id;
                row[1] = inqu.Creator.Username;
                row[2] = inqu.Contragent.Name;
                row[3] = inqu.Description;
                row[4] = inqu.Date;
                dt.Rows.Add(row);
            }


            InquDataGrid.ItemsSource = dt.DefaultView;
        }

        private void InquDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditForm();
        }

        private void InquDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditForm();
        }

        private void EditForm()
        {
            var db = new BmsContex();
            var inqu = db.Inquiries.Include(i => i.Contragent).ToList();
          
            var dash = new InquireForm();
            DataRowView dataRow = (DataRowView)InquDataGrid.SelectedItem;
            Inquiry currentInqu = inqu.Where(u => u.Id.ToString() == dataRow.Row.ItemArray[0].ToString()).SingleOrDefault();
            dash.inquiry_id.Text = dataRow.Row.ItemArray[0].ToString();
            dash.CreatorCombo.SelectedItem = dataRow.Row.ItemArray[1].ToString();
            dash.ClientCombo.SelectedItem = dataRow.Row.ItemArray[2].ToString();
            dash.description_form.Text = dataRow.Row.ItemArray[3].ToString();
            dash.poc_form.Text = currentInqu.Contragent.PersonForContact.ToString();
            dash.email_form.Text = currentInqu.Contragent.Email.ToString();
            dash.phone_form.Text = currentInqu.Contragent.Telephone.ToString();
            dash.Show();
            this.Close();
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            DataRowView dataRow = (DataRowView)InquDataGrid.SelectedItem;
            var itemId = dataRow.Row.ItemArray[0].ToString();
            var currentInquiry = db.Inquiries.Where(o => o.Id.ToString() == itemId).SingleOrDefault();
            db.Inquiries.Remove(currentInquiry);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Inquire Removed Successfully!");
            }
            catch (Exception)
            {
                MessageBox.Show("You cannot delete inquiry that is used in an offer!");
                return;
            } 

            var dash = new MainInquiries();
            dash.Show();
            this.Close();

        }
    }
}
