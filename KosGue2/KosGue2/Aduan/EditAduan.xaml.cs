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

namespace KosGue2.Aduan
{
    /// <summary>
    /// Interaction logic for EditAduan.xaml
    /// </summary>
    public partial class EditAduan : UserControl
    {
        private Frame Frame;
        private AduanViewModel AduanVM;
        private Aduan Aduan;

        public EditAduan()
        {
            InitializeComponent();
        }

        public EditAduan(Frame frame, AduanViewModel aduanVM, Aduan aduan)
        {
            InitializeComponent();
            this.Frame = frame;
            this.AduanVM = aduanVM;
            this.Aduan = aduan;
            // Loading Record into TextBoxes
            this.KodeAduanTBox.Text = aduan.KodeAduan.ToString();
            this.JudulTBox.Text = aduan.Judul;
            this.KetTBox.Text = aduan.Ket;
            this.TglAduanTBox.Text = aduan.TglAduan;
            this.KategoriTBox.Text = aduan.Kategori;
            this.NIKTBox.Text = aduan.NIK.ToString();
            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Aduan tempAduan = new Aduan();
            tempAduan.KodeAduan = int.Parse(KodeAduanTBox.Text.ToString());
            tempAduan.Judul = JudulTBox.Text;
            tempAduan.Ket = KetTBox.Text;
            tempAduan.TglAduan = TglAduanTBox.Text;
            tempAduan.Kategori = KategoriTBox.Text;
            tempAduan.NIK = int.Parse(NIKTBox.Text.ToString());
            AduanVM.UpdateAduanInRepo(tempAduan);
            MessageBox.Show("Aduan sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Aduan
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
                this.Aduan.KodeAduan.Equals(int.Parse(this.KodeAduanTBox.Text))
                && this.Aduan.Judul.Equals(this.JudulTBox.Text)
                && this.Aduan.Ket.Equals(this.KetTBox.Text)
                && this.Aduan.TglAduan.Equals(this.TglAduanTBox.Text)
                && this.Aduan.Kategori.Equals(this.KategoriTBox.Text)
                && this.Aduan.NIK.Equals(int.Parse(this.KategoriTBox.Text))

                ))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
