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

namespace BmsWpf.Views.Forms
{
    using BMS.DataBaseData;
    using BMS.DataBaseModels.Enums;

    /// <summary>
    /// Interaction logic for NoteForm.xaml
    /// </summary>
    public partial class NoteForm : Window
    {
        public NoteForm()
        {
            InitializeComponent();
            ShowTime();
            this.DataContext = new BmsContex();

        }

        private void ShowTime()
        {
                this.Date.Content = DateTime.Now.ToShortDateString();            
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            var context = new BmsContex();
            Enum.TryParse(this.NoteTypeBox.Text, out NoteType type);
            var date = DateTime.Now;
            var description = this.DescriptionBox.Text;

        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

        }
    }
}
