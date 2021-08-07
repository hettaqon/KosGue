using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace KosGue2.Pembayaran
{
    public class PembayaranViewModel
    {
        public ObservableCollection<Pembayaran> Pembayarans { get; set; }
        private PembayaranRepository PembayaranRepository { get; set; }

        public PembayaranViewModel()
        {
            PembayaranRepository = new PembayaranRepository();
            Pembayarans = new ObservableCollection<Pembayaran>(PembayaranRepository.pembayaranRepository);
            Pembayarans.CollectionChanged += Pembayarans_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Pembayarans Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Pembayaran> PembayaranRepo()
        {


            List<Pembayaran> PembayaransList =                // Temporary list for storing results returned from search query
                (from tempPembayaran in Pembayarans
                 select tempPembayaran).ToList();
            return PembayaransList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddPembayaranToRepo(Pembayaran bayar)
        {
            if (bayar == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Pembayarans.Add(bayar);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeletePembayaranFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Pembayarans.Count)
            {
                if (Pembayarans[index].KodeBayar == id)
                {
                    Pembayarans.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdatePembayaranInRepo(Pembayaran bayar)
        {
            if (bayar.KodeBayar < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Pembayarans.Count)
            {
                if (Pembayarans[index].KodeBayar == bayar.KodeBayar)
                {
                    Pembayarans[index] = bayar;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Pembayarans Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Pembayarans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                PembayaranRepository.addPembayaran(Pembayarans[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Pembayaran> tempListOfRemovedItems = e.OldItems.OfType<Pembayaran>().ToList();
                PembayaranRepository.DelPembayaran(tempListOfRemovedItems[0].KodeBayar);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Pembayaran> tempListOfPembayarans = e.NewItems.OfType<Pembayaran>().ToList();
                PembayaranRepository.UpdatePembayaran(tempListOfPembayarans[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
