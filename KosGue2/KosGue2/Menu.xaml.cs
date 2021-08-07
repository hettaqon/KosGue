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
using KosGue2.Pembayaran;
using KosGue2.Petugas;
using KosGue2.Penyewa;
using KosGue2.Kos;
using KosGue2.Kamar;
using KosGue2.Booking;
using KosGue2.Aduan;

namespace KosGue2
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menup : UserControl
    {
        public PembayaranViewModel PembayaranVM { get; set; }
        public PetugasViewModel PetugasVM { get; set; }
        public PenyewaViewModel PenyewaVM { get; set; }
        public KosViewModel KosVM { get; set; }
        public KamarViewModel KamarVM { get; set; }
        public BookingViewModel BookingVM { get; set; }
        public AduanViewModel AduanVM { get; set; }

        public Menup()
        {
            InitializeComponent(); 
        }
        public Menup(PembayaranViewModel PembayaranVM)
        {
            InitializeComponent();

            this.PembayaranVM = PembayaranVM;
        }
        public Menup(PetugasViewModel PetugasVM)
        {
            InitializeComponent();

            this.PetugasVM = PetugasVM;
        }
        private void pembayaranH_Click(object sender, RoutedEventArgs e)
        {
            PembayaranVM = new PembayaranViewModel(); 
            Dashboard.Content = null; 
            Frame.Navigate(new Pembayaranp(this.Frame, this.PembayaranVM));
        }

        private void dashboardH_Click(object sender, RoutedEventArgs e)
        {

            Dashboard.Navigate(new Dashboard());
        }

        private void petugasH_Click(object sender, RoutedEventArgs e)
        {
            PetugasVM = new PetugasViewModel();
            Dashboard.Content = null;
            
            Frame.Navigate(new Petugasp(this.Frame, this.PetugasVM));
        }

        private void penyewaH_Click(object sender, RoutedEventArgs e)
        {
            PenyewaVM = new PenyewaViewModel(); 
            Dashboard.Content = null; 
            Frame.Navigate(new Penyewap(this.Frame, this.PenyewaVM));
        }

        private void kosH_Click(object sender, RoutedEventArgs e)
        {
            KosVM = new KosViewModel(); 
            Dashboard.Content = null; 
            Frame.Navigate(new Kosp(this.Frame, this.KosVM));
        }

        private void kamarH_Click(object sender, RoutedEventArgs e)
        {
            KamarVM = new KamarViewModel();
            Dashboard.Content = null; 
            Frame.Navigate(new Kamarp(this.Frame, this.KamarVM));
        }

        private void bookingH_Click(object sender, RoutedEventArgs e)
        {
            BookingVM = new BookingViewModel();
            Dashboard.Content = null; 
            Frame.Navigate(new Bookingp(this.Frame, this.BookingVM));
        }

        private void aduanH_Click(object sender, RoutedEventArgs e)
        {
            AduanVM = new AduanViewModel();
            Dashboard.Content = null; 
            Frame.Navigate(new Aduanp(this.Frame, this.AduanVM));
        }
    }
}
