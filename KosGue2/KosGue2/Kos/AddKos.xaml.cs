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

namespace KosGue2.Kos
{
    /// <summary>
    /// Interaction logic for AddKos.xaml
    /// </summary>
    public partial class AddKos : UserControl
    {
        KosViewModel KosVM;
        Frame Frame;
        public AddKos()
        {
            InitializeComponent();
        }

        public AddKos(Frame frame1, KosViewModel kosVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.KosVM = kosVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void NamaTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NamaTBox.Text = "";
            NamaTBox.FontStyle = FontStyles.Normal;
            NamaTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void AlamatTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AlamatTBox.Text = "";
            AlamatTBox.FontStyle = FontStyles.Normal;
            AlamatTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void JmlKamarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            JmlKamarTBox.Text = "";
            JmlKamarTBox.FontStyle = FontStyles.Normal;
            JmlKamarTBox.FontWeight = FontWeights.Normal;
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
        private void KodePetugasTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodePetugasTBox.Text = "";
            KodePetugasTBox.FontStyle = FontStyles.Normal;
            KodePetugasTBox.FontWeight = FontWeights.Normal;
        }
        private void KontakTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KontakTBox.Text = "";
            KontakTBox.FontStyle = FontStyles.Normal;
            KontakTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Kos kos = new Kos();
            kos.KodeKos = int.Parse(KodeKosTBox.Text);
            kos.Nama = NamaTBox.Text;
            kos.Alamat = AlamatTBox.Text;
            kos.JmlKamar = int.Parse(JmlKamarTBox.Text);
            kos.Fasilitas = FasilitasTBox.Text;
            kos.KodePetugas = int.Parse(KodePetugasTBox.Text);
            kos.Kontak = KontakTBox.Text;

            KosVM.AddKosToRepo(kos);
            MessageBox.Show("Kos sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodeKosTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeKosTBox.Text = "";
            KodeKosTBox.FontStyle = FontStyles.Normal;
            KodeKosTBox.FontWeight = FontWeights.Normal;
        }
    }
}
