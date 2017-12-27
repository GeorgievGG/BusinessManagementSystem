﻿using BMS.DataBaseData;
using BMS.DataBaseModels;
using BmsWpf.Views.ChildWindows;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace BmsWpf.Views.Forms
{
    /// <summary>
    /// Interaction logic for OfferForm.xaml
    /// </summary>
    public partial class OfferForm : Window
    {
        public OfferForm()
        {
            InitializeComponent();
            fillCombos();

        }

        private void fillCombos()
        {
            var db = new BmsContex();

            var clients = db.Contragents.ToList();
            ClientCombo.ItemsSource = clients.Select(c => c.Name);

            var inquiries = db.Inquiries.ToList();
            InquiryCombo.ItemsSource = inquiries.Select(c => c.Description);

            var creators = db.Users.ToList();
            CreatorCombo.ItemsSource = creators.Select(c => c.Username);

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainOffers();
            dash.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            var client_form = ClientCombo.SelectedItem.ToString();
            var inquiry_form = InquiryCombo.SelectedItem.ToString();
            var creator_form = CreatorCombo.SelectedItem.ToString();
            var desc_form = offer_description.Text;
            var date_form = date.SelectedDate.ToString(); // 6.12.2017 г. 0:00:00
            var format = "d.MM.yyyy г. h:mm:ss";

            var clientId = db.Contragents.Where(u => u.Name == client_form).SingleOrDefault().Id;
            var creatorId = db.Users.Where(u => u.Username == creator_form).SingleOrDefault().Id;
            var inquiryId = db.Inquiries.Where(u => u.Description == inquiry_form).SingleOrDefault().Id;

            var newOffer = new Offer
            {
                ClientId = clientId,
                CreatorId = creatorId,
                InquiryId = inquiryId,
                Description = desc_form,
                Date = DateTime.ParseExact(date_form, format, CultureInfo.InvariantCulture)
            };
            db.Offers.Add(newOffer);
            db.SaveChanges();
            MessageBox.Show("Offer Successfully created!");

            var dash = new MainOffers();
            dash.Show();
            this.Close();
        }
    }
}
