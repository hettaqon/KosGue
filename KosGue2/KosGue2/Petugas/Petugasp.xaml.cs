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

namespace KosGue2.Petugas
{
    /// <summary>
    /// Interaction logic for Petugasp.xaml
    /// </summary>
    public partial class Petugasp : UserControl
    {
        PetugasViewModel PetugasVM;
        Frame Frame;
        public Petugasp()
        {
            InitializeComponent();
        }

        public Petugasp(Frame frame, PetugasViewModel PetugasVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PetugasVM = PetugasVM;

            this.Loaded += PetugasPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            AddBtn.IsEnabled = true;
        }

        private void PetugasPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = PetugasVM.PetugasRepo();

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
            PetugasVM = new PetugasViewModel();
            Frame.Navigate(new AddPetugas(this.Frame, this.PetugasVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Petugas petugas = (Petugas)gridTable.SelectedItem;
            PetugasVM.DeletePetugasFromRepo(petugas.KodePetugas);
            gridTable.DataContext = PetugasVM.PetugasRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Petugas tempPetugas = (Petugas)gridTable.SelectedItem;
            Frame.Navigate(new EditPetugas(Frame, PetugasVM, tempPetugas));
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
