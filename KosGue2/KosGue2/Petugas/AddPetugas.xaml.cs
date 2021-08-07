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

namespace KosGue2.Petugas
{
    /// <summary>
    /// Interaction logic for AddPetugas.xaml
    /// </summary>
    public partial class AddPetugas : UserControl
    {
        PetugasViewModel PetugasVM;
        Frame Frame;
        public AddPetugas()
        {
            InitializeComponent();
        }

        public AddPetugas(Frame frame1, PetugasViewModel petugasVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PetugasVM = petugasVM;
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
        private void NoHPTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NoHPTBox.Text = "";
            NoHPTBox.FontStyle = FontStyles.Normal;
            NoHPTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void JobTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            JobTBox.Text = "";
            JobTBox.FontStyle = FontStyles.Normal;
            JobTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void ShiftTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ShiftTBox.Text = "";
            ShiftTBox.FontStyle = FontStyles.Normal;
            ShiftTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Petugas petugas = new Petugas();
            petugas.KodePetugas = int.Parse(KodePetugasTBox.Text);
            petugas.Nama = NamaTBox.Text;
            petugas.NoHP = NoHPTBox.Text;
            petugas.Job = JobTBox.Text;
            petugas.Shift = ShiftTBox.Text;

            PetugasVM.AddPetugasToRepo(petugas);
            MessageBox.Show("Petugas sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodePetugasTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodePetugasTBox.Text = "";
            KodePetugasTBox.FontStyle = FontStyles.Normal;
            KodePetugasTBox.FontWeight = FontWeights.Normal;
        }
    }
}
