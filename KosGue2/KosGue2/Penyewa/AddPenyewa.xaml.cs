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
    /// Interaction logic for AddPenyewa.xaml
    /// </summary>
    public partial class AddPenyewa : UserControl
    {
        PenyewaViewModel PenyewaVM;
        Frame Frame;
        public AddPenyewa()
        {
            InitializeComponent();
        }

        public AddPenyewa(Frame frame1, PenyewaViewModel penyewaVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PenyewaVM = penyewaVM;
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
        private void NoHPTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NoHPTBox.Text = "";
            NoHPTBox.FontStyle = FontStyles.Normal;
            NoHPTBox.FontWeight = FontWeights.Normal;
        }


        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Penyewa penyewa = new Penyewa();
            penyewa.NIK = int.Parse(NIKTBox.Text);
            penyewa.Nama = NamaTBox.Text;
            penyewa.Alamat = AlamatTBox.Text;
            penyewa.NoHP = NoHPTBox.Text;

            PenyewaVM.AddPenyewaToRepo(penyewa);
            MessageBox.Show("Penyewa sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void NIKTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NIKTBox.Text = "";
            NIKTBox.FontStyle = FontStyles.Normal;
            NIKTBox.FontWeight = FontWeights.Normal;
        }
    }
}
