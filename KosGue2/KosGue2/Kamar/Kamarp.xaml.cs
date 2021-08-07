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

namespace KosGue2.Kamar
{
    /// <summary>
    /// Interaction logic for Kamarp.xaml
    /// </summary>
    public partial class Kamarp : UserControl
    {
        KamarViewModel KamarVM;
        Frame Frame;
        public Kamarp()
        {
            InitializeComponent();
        }

        public Kamarp(Frame frame, KamarViewModel KamarVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.KamarVM = KamarVM;

            this.Loaded += KamarPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            AddBtn.IsEnabled = true;
        }

        private void KamarPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = KamarVM.KamarRepo();

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
            KamarVM = new KamarViewModel();
            Frame.Navigate(new AddKamar(this.Frame, this.KamarVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Kamar pembayaran = (Kamar)gridTable.SelectedItem;
            KamarVM.DeleteKamarFromRepo(pembayaran.KodeKamar);
            gridTable.DataContext = KamarVM.KamarRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Kamar tempKamar = (Kamar)gridTable.SelectedItem;
            Frame.Navigate(new EditKamar(Frame, KamarVM, tempKamar));
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
