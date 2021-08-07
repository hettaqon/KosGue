using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace KosGue2.Petugas
{
    public class PetugasViewModel
    {
        public ObservableCollection<Petugas> Petugass { get; set; }
        private PetugasRepository PetugasRepository { get; set; }

        public PetugasViewModel()
        {
            PetugasRepository = new PetugasRepository();
            Petugass = new ObservableCollection<Petugas>(PetugasRepository.petugasRepository);
            Petugass.CollectionChanged += Petugass_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Petugass Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Petugas> PetugasRepo()
        {


            List<Petugas> PetugassList =                // Temporary list for storing results returned from search query
                (from tempPetugas in Petugass
                 select tempPetugas).ToList();
            return PetugassList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddPetugasToRepo(Petugas bayar)
        {
            if (bayar == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Petugass.Add(bayar);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeletePetugasFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Petugass.Count)
            {
                if (Petugass[index].KodePetugas == id)
                {
                    Petugass.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdatePetugasInRepo(Petugas bayar)
        {
            if (bayar.KodePetugas < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Petugass.Count)
            {
                if (Petugass[index].KodePetugas == bayar.KodePetugas)
                {
                    Petugass[index] = bayar;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Petugass Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Petugass_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                PetugasRepository.addPetugas(Petugass[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Petugas> tempListOfRemovedItems = e.OldItems.OfType<Petugas>().ToList();
                PetugasRepository.DelPetugas(tempListOfRemovedItems[0].KodePetugas);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Petugas> tempListOfPetugass = e.NewItems.OfType<Petugas>().ToList();
                PetugasRepository.UpdatePetugas(tempListOfPetugass[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
