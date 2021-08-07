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
    /// Interaction logic for AddAduan.xaml
    /// </summary>
    public partial class AddAduan : UserControl
    {
        AduanViewModel AduanVM;
        Frame Frame;
        public AddAduan()
        {
            InitializeComponent();
        }

        public AddAduan(Frame frame1, AduanViewModel aduanVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.AduanVM = aduanVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void JudulTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            JudulTBox.Text = "";
            JudulTBox.FontStyle = FontStyles.Normal;
            JudulTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void KetTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KetTBox.Text = "";
            KetTBox.FontStyle = FontStyles.Normal;
            KetTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void TglAduanTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TglAduanTBox.Text = "";
            TglAduanTBox.FontStyle = FontStyles.Normal;
            TglAduanTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void KategoriTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KategoriTBox.Text = "";
            KategoriTBox.FontStyle = FontStyles.Normal;
            KategoriTBox.FontWeight = FontWeights.Normal;
        }
        private void NIKTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NIKTBox.Text = "";
            NIKTBox.FontStyle = FontStyles.Normal;
            NIKTBox.FontWeight = FontWeights.Normal;
        }
        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Aduan aduan = new Aduan();
            aduan.KodeAduan = int.Parse(KodeAduanTBox.Text);
            aduan.Judul = JudulTBox.Text;
            aduan.Ket = KetTBox.Text;
            aduan.TglAduan = TglAduanTBox.Text;
            aduan.Kategori = KategoriTBox.Text;
            aduan.NIK = int.Parse(NIKTBox.Text);

            AduanVM.AddAduanToRepo(aduan);
            MessageBox.Show("Aduan sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodeAduanTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeAduanTBox.Text = "";
            KodeAduanTBox.FontStyle = FontStyles.Normal;
            KodeAduanTBox.FontWeight = FontWeights.Normal;
        }
    }
}
