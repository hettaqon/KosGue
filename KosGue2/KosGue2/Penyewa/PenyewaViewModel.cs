using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KosGue2.Penyewa
{
    public class PenyewaViewModel
    {
        public ObservableCollection<Penyewa> Penyewas { get; set; }
        private PenyewaRepository PenyewaRepository { get; set; }

        public PenyewaViewModel()
        {
            PenyewaRepository = new PenyewaRepository();
            Penyewas = new ObservableCollection<Penyewa>(PenyewaRepository.penyewaRepository);
            Penyewas.CollectionChanged += Penyewas_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Penyewas Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Penyewa> PenyewaRepo()
        {


            List<Penyewa> PenyewasList =                // Temporary list for storing results returned from search query
                (from tempPenyewa in Penyewas
                 select tempPenyewa).ToList();
            return PenyewasList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddPenyewaToRepo(Penyewa sewa)
        {
            if (sewa == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Penyewas.Add(sewa);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeletePenyewaFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Penyewas.Count)
            {
                if (Penyewas[index].NIK == id)
                {
                    Penyewas.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdatePenyewaInRepo(Penyewa sewa)
        {
            if (sewa.NIK < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Penyewas.Count)
            {
                if (Penyewas[index].NIK == sewa.NIK)
                {
                    Penyewas[index] = sewa;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Penyewas Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Penyewas_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                PenyewaRepository.addPenyewa(Penyewas[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Penyewa> tempListOfRemovedItems = e.OldItems.OfType<Penyewa>().ToList();
                PenyewaRepository.DelPenyewa(tempListOfRemovedItems[0].NIK);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Penyewa> tempListOfPenyewas = e.NewItems.OfType<Penyewa>().ToList();
                PenyewaRepository.UpdatePenyewa(tempListOfPenyewas[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
