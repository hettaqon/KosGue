using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KosGue2.Aduan
{
    public class AduanViewModel
    {
        public ObservableCollection<Aduan> Aduans { get; set; }
        private AduanRepository AduanRepository { get; set; }

        public AduanViewModel()
        {
            AduanRepository = new AduanRepository();
            Aduans = new ObservableCollection<Aduan>(AduanRepository.aduanRepository);
            Aduans.CollectionChanged += Aduans_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Aduans Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Aduan> AduanRepo()
        {


            List<Aduan> AduansList =                // Temporary list for storing results returned from search query
                (from tempAduan in Aduans
                 select tempAduan).ToList();
            return AduansList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddAduanToRepo(Aduan adu)
        {
            if (adu == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Aduans.Add(adu);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteAduanFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Aduans.Count)
            {
                if (Aduans[index].KodeAduan == id)
                {
                    Aduans.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateAduanInRepo(Aduan adu)
        {
            if (adu.KodeAduan < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Aduans.Count)
            {
                if (Aduans[index].KodeAduan == adu.KodeAduan)
                {
                    Aduans[index] = adu;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Aduans Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Aduans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                AduanRepository.addAduan(Aduans[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Aduan> tempListOfRemovedItems = e.OldItems.OfType<Aduan>().ToList();
                AduanRepository.DelAduan(tempListOfRemovedItems[0].KodeAduan);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Aduan> tempListOfAduans = e.NewItems.OfType<Aduan>().ToList();
                AduanRepository.UpdateAduan(tempListOfAduans[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}
