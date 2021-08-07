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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KosGue2.Pembayaran
{
    /// <summary>
    /// Interaction logic for EditPembayaran.xaml
    /// </summary>
    public partial class EditPembayaran : UserControl
    {
        private Frame Frame;
        private PembayaranViewModel PembayaranVM;
        private Pembayaran Pembayaran;

        public EditPembayaran()
        {
            InitializeComponent();
        }

        public EditPembayaran(Frame frame, PembayaranViewModel pembayaranVM, Pembayaran pembayaran)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PembayaranVM = pembayaranVM;
            this.Pembayaran = pembayaran;
            // Loading Record into TextBoxes
            this.KodeBayarTBox.Text = pembayaran.KodeBayar.ToString();
            this.TglBayarTBox.Text = pembayaran.TglBayar;
            this.JmlBayarTBox.Text = pembayaran.JmlBayar;
            this.BuktiTBox.Text = pembayaran.Bukti;
            this.StatusTBox.Text = pembayaran.Status;
            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Pembayaran tempPembayaran = new Pembayaran();
            tempPembayaran.KodeBayar = int.Parse(KodeBayarTBox.Text.ToString());
            tempPembayaran.TglBayar = TglBayarTBox.Text;
            tempPembayaran.JmlBayar = JmlBayarTBox.Text;
            tempPembayaran.Bukti = BuktiTBox.Text;
            tempPembayaran.Status = StatusTBox.Text;
            PembayaranVM.UpdatePembayaranInRepo(tempPembayaran);
            MessageBox.Show("Pembayaran sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Pembayaran
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        /* 
         * Function: Event Handler for TextBox
         * Enable update button if text is edited in Box
         */
        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(
                this.Pembayaran.KodeBayar.Equals(int.Parse(this.KodeBayarTBox.Text))
                && this.Pembayaran.TglBayar.Equals(this.TglBayarTBox.Text)
                && this.Pembayaran.JmlBayar.Equals(this.JmlBayarTBox.Text)
                && this.Pembayaran.Bukti.Equals(this.BuktiTBox.Text)
                && this.Pembayaran.Status.Equals(this.StatusTBox.Text)))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
