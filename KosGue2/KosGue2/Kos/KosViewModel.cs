using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KosGue2.Kos
{
    public class KosViewModel
    {
        public ObservableCollection<Kos> Koss { get; set; }
        private KosRepository KosRepository { get; set; }

        public KosViewModel()
        {
            KosRepository = new KosRepository();
            Koss = new ObservableCollection<Kos>(KosRepository.kosRepository);
            Koss.CollectionChanged += Koss_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Koss Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Kos> KosRepo()
        {


            List<Kos> KossList =                // Temporary list for storing results returned from search query
                (from tempKos in Koss
                 select tempKos).ToList();
            return KossList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddKosToRepo(Kos sewa)
        {
            if (sewa == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Koss.Add(sewa);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteKosFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Koss.Count)
            {
                if (Koss[index].KodeKos == id)
                {
                    Koss.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateKosInRepo(Kos sewa)
        {
            if (sewa.KodeKos < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Koss.Count)
            {
                if (Koss[index].KodeKos == sewa.KodeKos)
                {
                    Koss[index] = sewa;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Koss Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Koss_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                KosRepository.addKos(Koss[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Kos> tempListOfRemovedItems = e.OldItems.OfType<Kos>().ToList();
                KosRepository.DelKos(tempListOfRemovedItems[0].KodeKos);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Kos> tempListOfKoss = e.NewItems.OfType<Kos>().ToList();
                KosRepository.UpdateKos(tempListOfKoss[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
