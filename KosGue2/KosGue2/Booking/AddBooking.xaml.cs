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

namespace KosGue2.Booking
{
    /// <summary>
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : UserControl
    {
        BookingViewModel BookingVM;
        Frame Frame;
        public AddBooking()
        {
            InitializeComponent();
        }

        public AddBooking(Frame frame1, BookingViewModel bookingVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.BookingVM = bookingVM;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void KodeKamarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeKamarTBox.Text = "";
            KodeKamarTBox.FontStyle = FontStyles.Normal;
            KodeKamarTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for TextBox_GotFocus Event
         */
        private void TglBookingTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TglBookingTBox.Text = "";
            TglBookingTBox.FontStyle = FontStyles.Normal;
            TglBookingTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void TglHabisTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TglHabisTBox.Text = "";
            TglHabisTBox.FontStyle = FontStyles.Normal;
            TglHabisTBox.FontWeight = FontWeights.Normal;
        }

        /*
        * Function: Event Handler for TextBox_GotFocus Event
        */
        private void NIKTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NIKTBox.Text = "";
            NIKTBox.FontStyle = FontStyles.Normal;
            NIKTBox.FontWeight = FontWeights.Normal;
        }
        private void KodeBayarTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeBayarTBox.Text = "";
            KodeBayarTBox.FontStyle = FontStyles.Normal;
            KodeBayarTBox.FontWeight = FontWeights.Normal;
        }

        /*
         * Function: Event Handler for Add Button
         * Adds the entered data to the Collection and Database
         */
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            booking.KodeBooking = int.Parse(KodeBookingTBox.Text);
            booking.KodeKamar = int.Parse(KodeKamarTBox.Text);
            booking.TglBooking = TglBookingTBox.Text;
            booking.TglHabis = TglHabisTBox.Text;
            booking.NIK = int.Parse(NIKTBox.Text);
            booking.KodeBayar = int.Parse(KodeBayarTBox.Text);

            BookingVM.AddBookingToRepo(booking);
            MessageBox.Show("Booking sudah ditambah", "Sukses !");
        }

        /*
         * Function: Event Handler for back button
         * Navigates to back page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void KodeBookingTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KodeBookingTBox.Text = "";
            KodeBookingTBox.FontStyle = FontStyles.Normal;
            KodeBookingTBox.FontWeight = FontWeights.Normal;
        }
    }
}
