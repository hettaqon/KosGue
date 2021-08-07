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
    /// Interaction logic for EditBooking.xaml
    /// </summary>
    public partial class EditBooking : UserControl
    {
        private Frame Frame;
        private BookingViewModel BookingVM;
        private Booking Booking;

        public EditBooking()
        {
            InitializeComponent();
        }

        public EditBooking(Frame frame, BookingViewModel bookingVM, Booking booking)
        {
            InitializeComponent();
            this.Frame = frame;
            this.BookingVM = bookingVM;
            this.Booking = booking;
            // Loading Record into TextBoxes
            this.KodeBookingTBox.Text = booking.KodeBooking.ToString();
            this.KodeKamarTBox.Text = booking.KodeKamar.ToString();
            this.TglBookingTBox.Text = booking.TglBooking;
            this.TglHabisTBox.Text = booking.TglHabis;
            this.NIKTBox.Text = booking.NIK.ToString();
            this.KodeBayarTBox.Text = booking.KodeBayar.ToString();
            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking tempBooking = new Booking();
            tempBooking.KodeBooking = int.Parse(KodeBookingTBox.Text.ToString());
            tempBooking.KodeKamar = int.Parse(KodeKamarTBox.Text.ToString());
            tempBooking.TglBooking = TglBookingTBox.Text;
            tempBooking.TglHabis = TglHabisTBox.Text;
            tempBooking.NIK = int.Parse(NIKTBox.Text.ToString());
            tempBooking.KodeBayar = int.Parse(KodeBayarTBox.Text.ToString());
            BookingVM.UpdateBookingInRepo(tempBooking);
            MessageBox.Show("Booking sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Booking
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
                this.Booking.KodeBooking.Equals(this.KodeBookingTBox.Text)
                && this.Booking.KodeKamar.Equals(this.KodeKamarTBox.Text)
                && this.Booking.TglBooking.Equals(this.TglBookingTBox.Text)
                && this.Booking.TglHabis.Equals(this.TglHabisTBox.Text)
                && this.Booking.NIK.Equals(this.NIKTBox.Text)
                && this.Booking.KodeBayar.Equals(this.KodeBayarTBox.Text)

                ))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
