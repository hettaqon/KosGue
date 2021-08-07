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

namespace KosGue2.Kos
{
    /// <summary>
    /// Interaction logic for Kosp.xaml
    /// </summary>
    public partial class Kosp : UserControl
    {
        KosViewModel KosVM;
        Frame Frame;
        public Kosp()
        {
            InitializeComponent();
        }

        public Kosp(Frame frame, KosViewModel KosVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.KosVM = KosVM;

            this.Loaded += KosPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            AddBtn.IsEnabled = true;
        }

        private void KosPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = KosVM.KosRepo();

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
            KosVM = new KosViewModel();
            Frame.Navigate(new AddKos(this.Frame, this.KosVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Kos kos = (Kos)gridTable.SelectedItem;
            KosVM.DeleteKosFromRepo(kos.KodeKos);
            gridTable.DataContext = KosVM.KosRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Kos tempKos = (Kos)gridTable.SelectedItem;
            Frame.Navigate(new EditKos(Frame, KosVM, tempKos));
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
