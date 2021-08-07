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
    /// Interaction logic for AddPembayaran.xaml
    /// </summary>
    public partial class AddPembayaran : UserControl
    {
        PembayaranViewModel PembayaranVM;
        Frame Frame;
        public AddPembayaran()
        {
            InitializeComponent();
        }

        public AddPembayaran(Frame frame1, PembayaranViewModel pembayaranVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PembayaranVM = pembayaranVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void TglBayarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TglBayarTBox.Text = "";
            TglBayarTBox.FontStyle = FontStyles.Normal;
            TglBayarTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void JmlBayarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            JmlBayarTBox.Text = "";
            JmlBayarTBox.FontStyle = FontStyles.Normal;
            JmlBayarTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void BuktiTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BuktiTBox.Text = "";
            BuktiTBox.FontStyle = FontStyles.Normal;
            BuktiTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void StatusTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            StatusTBox.Text = "";
            StatusTBox.FontStyle = FontStyles.Normal;
            StatusTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.KodeBayar = int.Parse(KodeBayarTBox.Text);
            pembayaran.TglBayar = TglBayarTBox.Text;
            pembayaran.JmlBayar = JmlBayarTBox.Text;
            pembayaran.Bukti = BuktiTBox.Text;
            pembayaran.Status = StatusTBox.Text;

            PembayaranVM.AddPembayaranToRepo(pembayaran);
            MessageBox.Show("Pembayaran sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodeBayarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeBayarTBox.Text = "";
            KodeBayarTBox.FontStyle = FontStyles.Normal;
            KodeBayarTBox.FontWeight = FontWeights.Normal;
        }
    }
}
