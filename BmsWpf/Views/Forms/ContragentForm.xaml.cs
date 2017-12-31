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
using BmsWpf.ViewModels;
using BMS.DataBaseData;
using BMS.DataBaseModels;

namespace BmsWpf.Views.Forms
{
    /// <summary>
    /// Interaction logic for ContragentForm.xaml
    /// </summary>
    public partial class ContragentForm : Window
    {
        public ContragentForm()
        {
			InitializeComponent();
	        var vm = new ContragentViewModel();
	        this.DataContext = vm;
	        if (vm.CloseAction == null)
		        vm.CloseAction = new Action(() => this.Close());
		}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
			var db = new BmsContex();

	        var name = Name.Text;
	        if (name == string.Empty)
	        {
		        MessageBox.Show("Please insert Name");
		        return;
	        }

			var personalVatNumber = PersonalVatNumber.Text;
	        if (personalVatNumber == string.Empty)
	        {
		        MessageBox.Show("Please insert VAT Number");
		        return;
	        }
			var personalIndentityNumber = PersonalIndentityNumber.Text;
	        if (personalIndentityNumber == string.Empty)
	        {
		        MessageBox.Show("Please insert Identity Number");
		        return;
	        }

			var address = Address.Text;
	        if (address == string.Empty)
	        {
		        MessageBox.Show("Please insert Address");
		        return;
	        }

			var telephone = Telephone.Text;
	        if (telephone == string.Empty)
	        {
		        MessageBox.Show("Please insert Telephone Number");
		        return;
	        }

			var email = Email.Text;
	        if (email == string.Empty)
	        {
		        MessageBox.Show("Please insert Email");
		        return;
	        }

			var personForContact = PersonForContact.Text;
	        if (personForContact == string.Empty)
	        {
		        MessageBox.Show("Please insert Contact Person");
		        return;
	        }

			var bankDetails = BankDetails.Text;
	        if (bankDetails == string.Empty)
	        {
		        MessageBox.Show("Please insert Bank Details");
		        return;
	        }

			var description = Description.Text;
	        if (description == string.Empty)
	        {
		        MessageBox.Show("Please insert Description");
		        return;
	        }

	        var contragentCheck = db.Contragents.FirstOrDefault(c => c.PersonalVatNumber == personalVatNumber);

			if (contragentCheck == null)
	        {
		        var contragent = new Contragent()
		        {
			        Name = name,
			        PersonalVatNumber = personalVatNumber,
			        PersonalIndentityNumber = personalIndentityNumber,
			        Address = address,
			        Telephone = telephone,
			        Email = email,
			        PersonForContact = personForContact,
			        BankDetails = bankDetails,
			        Description = description
		        };

		        db.Contragents.Add(contragent);
		        db.SaveChanges();
		        MessageBox.Show("Contragent details saved successfully");

		        var dash = new MainWindow();
		        dash.Show();
		        this.Close();
	        }
	        else
	        {
		        var currentContragent = db.Contragents.First(c => c.Id == contragentCheck.Id);


		        currentContragent.Name = name;
		        currentContragent.PersonalVatNumber = personalVatNumber;
		        currentContragent.PersonalIndentityNumber = personalIndentityNumber;
		        currentContragent.Address = address;
		        currentContragent.Telephone = telephone;
		        currentContragent.Email = email;
		        currentContragent.PersonForContact = personForContact;
		        currentContragent.BankDetails = bankDetails;
		        currentContragent.Description = description;

		        db.SaveChanges();
		        MessageBox.Show("Contragent details edited successfully");

		        var dash = new MainWindow();
		        dash.Show();
		        this.Close();
			}
			
        }

    }

}
