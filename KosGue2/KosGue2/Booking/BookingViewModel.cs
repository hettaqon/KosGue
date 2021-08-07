using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KosGue2.Booking
{
    public class BookingViewModel
    {
        public ObservableCollection<Booking> Bookings { get; set; }
        private BookingRepository BookingRepository { get; set; }

        public BookingViewModel()
        {
            BookingRepository = new BookingRepository();
            Bookings = new ObservableCollection<Booking>(BookingRepository.bookingRepository);
            Bookings.CollectionChanged += Bookings_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Bookings Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Booking> BookingRepo()
        {


            List<Booking> BookingsList =                // Temporary list for storing results returned from search query
                (from tempBooking in Bookings
                 select tempBooking).ToList();
            return BookingsList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddBookingToRepo(Booking book)
        {
            if (book == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Bookings.Add(book);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteBookingFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Bookings.Count)
            {
                if (Bookings[index].KodeBayar == id)
                {
                    Bookings.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateBookingInRepo(Booking book)
        {
            if (book.KodeBayar < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Bookings.Count)
            {
                if (Bookings[index].KodeBayar == book.KodeBayar)
                {
                    Bookings[index] = book;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Bookings Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Bookings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                BookingRepository.addBooking(Bookings[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Booking> tempListOfRemovedItems = e.OldItems.OfType<Booking>().ToList();
                BookingRepository.DelBooking(tempListOfRemovedItems[0].KodeBayar);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Booking> tempListOfBookings = e.NewItems.OfType<Booking>().ToList();
                BookingRepository.UpdateBooking(tempListOfBookings[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
