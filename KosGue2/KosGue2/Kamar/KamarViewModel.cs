using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KosGue2.Kamar
{
    public class KamarViewModel
    {
        public ObservableCollection<Kamar> Kamars { get; set; }
        private KamarRepository KamarRepository { get; set; }

        public KamarViewModel()
        {
            KamarRepository = new KamarRepository();
            Kamars = new ObservableCollection<Kamar>(KamarRepository.kamarRepository);
            Kamars.CollectionChanged += Kamars_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Kamars Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Kamar> KamarRepo()
        {


            List<Kamar> KamarsList =                // Temporary list for storing results returned from search query
                (from tempKamar in Kamars
                 select tempKamar).ToList();
            return KamarsList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddKamarToRepo(Kamar sewa)
        {
            if (sewa == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Kamars.Add(sewa);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteKamarFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Kamars.Count)
            {
                if (Kamars[index].KodeKamar == id)
                {
                    Kamars.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateKamarInRepo(Kamar sewa)
        {
            if (sewa.KodeKamar < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Kamars.Count)
            {
                if (Kamars[index].KodeKamar == sewa.KodeKamar)
                {
                    Kamars[index] = sewa;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Kamars Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Kamars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                KamarRepository.addKamar(Kamars[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Kamar> tempListOfRemovedItems = e.OldItems.OfType<Kamar>().ToList();
                KamarRepository.DelKamar(tempListOfRemovedItems[0].KodeKamar);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Kamar> tempListOfKamars = e.NewItems.OfType<Kamar>().ToList();
                KamarRepository.UpdateKamar(tempListOfKamars[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
