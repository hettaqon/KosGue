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
    /// Interaction logic for EditKos.xaml
    /// </summary>
    public partial class EditKos : UserControl
    {
        private Frame Frame;
        private KosViewModel KosVM;
        private Kos Kos;

        public EditKos()
        {
            InitializeComponent();
        }

        public EditKos(Frame frame, KosViewModel pembayaranVM, Kos pembayaran)
        {
            InitializeComponent();
            this.Frame = frame;
            this.KosVM = pembayaranVM;
            this.Kos = pembayaran;
            // Loading Record into TextBoxes
            this.KodeKosTBox.Text = pembayaran.KodeKos.ToString();
            this.NamaTBox.Text = pembayaran.Nama;
            this.AlamatTBox.Text = pembayaran.Alamat;
            this.JmlKamarTBox.Text = pembayaran.JmlKamar.ToString();
            this.FasilitasTBox.Text = pembayaran.Fasilitas;
            this.KodePetugasTBox.Text = pembayaran.KodePetugas.ToString();
            this.KontakTBox.Text = pembayaran.Kontak;

            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Kos tempKos = new Kos();
            tempKos.KodeKos = int.Parse(KodeKosTBox.Text.ToString());
            tempKos.Nama = NamaTBox.Text;
            tempKos.Alamat = AlamatTBox.Text;
            tempKos.JmlKamar = int.Parse(JmlKamarTBox.Text.ToString());
            tempKos.Fasilitas = FasilitasTBox.Text;
            tempKos.KodePetugas = int.Parse(KodePetugasTBox.Text.ToString());
            tempKos.Kontak = KontakTBox.Text;

            KosVM.UpdateKosInRepo(tempKos);
            MessageBox.Show("Kos sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Kos
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
                this.Kos.KodeKos.Equals(int.Parse(this.KodeKosTBox.Text))
                && this.Kos.Nama.Equals(this.NamaTBox.Text)
                && this.Kos.Alamat.Equals(this.AlamatTBox.Text)
                && this.Kos.JmlKamar.Equals(int.Parse(this.JmlKamarTBox.Text))
                && this.Kos.Fasilitas.Equals(this.FasilitasTBox.Text)
                && this.Kos.KodePetugas.Equals(int.Parse(this.KodePetugasTBox.Text))
                && this.Kos.Kontak.Equals(this.KontakTBox.Text)

                ))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
