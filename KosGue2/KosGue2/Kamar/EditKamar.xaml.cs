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
    /// Interaction logic for EditKamar.xaml
    /// </summary>
    public partial class EditKamar : UserControl
    {
        private Frame Frame;
        private KamarViewModel KamarVM;
        private Kamar Kamar;

        public EditKamar()
        {
            InitializeComponent();
        }

        public EditKamar(Frame frame, KamarViewModel pembayaranVM, Kamar pembayaran)
        {
            InitializeComponent();
            this.Frame = frame;
            this.KamarVM = pembayaranVM;
            this.Kamar = pembayaran;
            // Loading Record into TextBoxes
            this.KodeKamarTBox.Text = pembayaran.KodeKamar.ToString();
            this.TipeTBox.Text = pembayaran.Tipe;
            this.LokasiTBox.Text = pembayaran.Lokasi;
            this.FasilitasTBox.Text = pembayaran.Fasilitas;
            this.StatusTBox.Text = pembayaran.Status;
            this.KodeKosTBox.Text = pembayaran.KodeKos.ToString();
            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Kamar tempKamar = new Kamar();
            tempKamar.KodeKamar = int.Parse(KodeKamarTBox.ToString());
            tempKamar.Tipe = TipeTBox.Text;
            tempKamar.Lokasi = LokasiTBox.Text;
            tempKamar.Fasilitas = FasilitasTBox.Text;
            tempKamar.Status = StatusTBox.Text;
            tempKamar.KodeKos = int.Parse(KodeKosTBox.Text.ToString());
            KamarVM.UpdateKamarInRepo(tempKamar);
            MessageBox.Show("Kamar sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Kamar
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
                this.Kamar.KodeKamar.Equals(int.Parse(this.KodeKamarTBox.Text))
                && this.Kamar.Tipe.Equals(this.TipeTBox.Text)
                && this.Kamar.Lokasi.Equals(this.LokasiTBox.Text)
                && this.Kamar.Fasilitas.Equals(this.FasilitasTBox.Text)
                && this.Kamar.Status.Equals(this.StatusTBox.Text)
                && this.Kamar.KodeKos.Equals(int.Parse(this.KodeKosTBox.Text))

                ))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
