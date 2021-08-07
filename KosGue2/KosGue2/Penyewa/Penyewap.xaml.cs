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

namespace KosGue2.Penyewa
{
    /// <summary>
    /// Interaction logic for Penyewap.xaml
    /// </summary>
    public partial class Penyewap : UserControl
    {
        PenyewaViewModel PenyewaVM;
        Frame Frame;
        public Penyewap()
        {
            InitializeComponent();
        }

        public Penyewap(Frame frame, PenyewaViewModel PenyewaVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PenyewaVM = PenyewaVM;

            this.Loaded += PenyewaPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            AddBtn.IsEnabled = true;
        }

        private void PenyewaPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = PenyewaVM.PenyewaRepo();

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
            PenyewaVM = new PenyewaViewModel();
            Frame.Navigate(new AddPenyewa(this.Frame, this.PenyewaVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Penyewa penyewa = (Penyewa)gridTable.SelectedItem;
            PenyewaVM.DeletePenyewaFromRepo(penyewa.NIK);
            gridTable.DataContext = PenyewaVM.PenyewaRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Penyewa tempPenyewa = (Penyewa)gridTable.SelectedItem;
            Frame.Navigate(new EditPenyewa(Frame, PenyewaVM, tempPenyewa));
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
