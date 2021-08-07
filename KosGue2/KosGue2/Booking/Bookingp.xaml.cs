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
    /// Interaction logic for Bookingp.xaml
    /// </summary>
    public partial class Bookingp : UserControl
    {
        BookingViewModel BookingVM;
        Frame Frame;
        public Bookingp()
        {
            InitializeComponent();
        }

        public Bookingp(Frame frame, BookingViewModel BookingVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.BookingVM = BookingVM;

            this.Loaded += BookingPage_Loaded;
            AddBtn.IsEnabled = true;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
        }

        private void BookingPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = BookingVM.BookingRepo();

            if (gridTable.SelectedCells.Count == 0)         // Disable the Edit and Delete Button if no row selected
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            BookingVM = new BookingViewModel();
            Frame.Navigate(new AddBooking(this.Frame, this.BookingVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking pembayaran = (Booking)gridTable.SelectedItem;
            BookingVM.DeleteBookingFromRepo(pembayaran.KodeBayar);
            gridTable.DataContext = BookingVM.BookingRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking tempBooking = (Booking)gridTable.SelectedItem;
            Frame.Navigate(new EditBooking(Frame, BookingVM, tempBooking));
        }
        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
                return;
            }
            EditBtn.IsEnabled = true;
            DelBtn.IsEnabled = true;
        }
    }
}
