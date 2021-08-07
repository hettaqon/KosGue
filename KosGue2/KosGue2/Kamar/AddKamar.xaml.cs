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

namespace KosGue2.Kamar
{
    /// <summary>
    /// Interaction logic for AddKamar.xaml
    /// </summary>
    public partial class AddKamar : UserControl
    {
        KamarViewModel KamarVM;
        Frame Frame;
        public AddKamar()
        {
            InitializeComponent();
        }

        public AddKamar(Frame frame1, KamarViewModel pembayaranVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.KamarVM = pembayaranVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void TipeTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TipeTBox.Text = "";
            TipeTBox.FontStyle = FontStyles.Normal;
            TipeTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void LokasiTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LokasiTBox.Text = "";
            LokasiTBox.FontStyle = FontStyles.Normal;
            LokasiTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void FasilitasTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FasilitasTBox.Text = "";
            FasilitasTBox.FontStyle = FontStyles.Normal;
            FasilitasTBox.FontWeight = FontWeights.Normal;
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
        private void KodeKosTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeKosTBox.Text = "";
            KodeKosTBox.FontStyle = FontStyles.Normal;
            KodeKosTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Kamar pembayaran = new Kamar();
            pembayaran.KodeKamar = int.Parse(KodeKamarTBox.Text);
            pembayaran.Tipe = TipeTBox.Text;
            pembayaran.Lokasi = LokasiTBox.Text;
            pembayaran.Fasilitas = FasilitasTBox.Text;
            pembayaran.Status = StatusTBox.Text;
            pembayaran.KodeKos = int.Parse(KodeKosTBox.Text);

            KamarVM.AddKamarToRepo(pembayaran);
            MessageBox.Show("Kamar sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodeKamarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeKamarTBox.Text = "";
            KodeKamarTBox.FontStyle = FontStyles.Normal;
            KodeKamarTBox.FontWeight = FontWeights.Normal;
        }
    }
}
