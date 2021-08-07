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

namespace KosGue2.Penyewa
{
    /// <summary>
    /// Interaction logic for EditPenyewa.xaml
    /// </summary>
    public partial class EditPenyewa : UserControl
    {
        private Frame Frame;
        private PenyewaViewModel PenyewaVM;
        private Penyewa Penyewa;

        public EditPenyewa()
        {
            InitializeComponent();
        }

        public EditPenyewa(Frame frame, PenyewaViewModel penyewaVM, Penyewa penyewa)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PenyewaVM = penyewaVM;
            this.Penyewa = penyewa;
            // Loading Record into TextBoxes
            this.NIKTBox.Text = penyewa.NIK.ToString();
            this.NamaTBox.Text = penyewa.Nama;
            this.AlamatTBox.Text = penyewa.Alamat;
            this.NoHPTBox.Text = penyewa.NoHP;

            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Penyewa tempPenyewa = new Penyewa();
            tempPenyewa.NIK =int.Parse(NIKTBox.Text.ToString());
            tempPenyewa.Nama = NamaTBox.Text;
            tempPenyewa.Alamat = AlamatTBox.Text;
            tempPenyewa.NoHP = NoHPTBox.Text;

            PenyewaVM.UpdatePenyewaInRepo(tempPenyewa);
            MessageBox.Show("Penyewa sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Penyewa
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
                this.Penyewa.NIK.Equals(int.Parse(this.NIKTBox.Text))
                && this.Penyewa.Nama.Equals(this.NamaTBox.Text)
                && this.Penyewa.Alamat.Equals(this.AlamatTBox.Text)
                && this.Penyewa.NoHP.Equals(this.NoHPTBox.Text)
                ))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
