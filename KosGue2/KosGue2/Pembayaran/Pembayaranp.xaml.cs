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

namespace KosGue2.Pembayaran
{
    /// <summary>
    /// Interaction logic for Pembayaran.xaml
    /// </summary>
    public partial class Pembayaranp : UserControl
    {
        PembayaranViewModel PembayaranVM;
        Frame Frame;
        public Pembayaranp()
        {
            InitializeComponent();
        }

        public Pembayaranp(Frame frame, PembayaranViewModel PembayaranVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PembayaranVM = PembayaranVM;

            this.Loaded += PembayaranPage_Loaded;
            AddBtn.IsEnabled = true;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
        }

        private void PembayaranPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = PembayaranVM.PembayaranRepo();

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
            PembayaranVM = new PembayaranViewModel();
            Frame.Navigate(new AddPembayaran(this.Frame, this.PembayaranVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Pembayaran pembayaran = (Pembayaran)gridTable.SelectedItem;
            PembayaranVM.DeletePembayaranFromRepo(pembayaran.KodeBayar);
            gridTable.DataContext = PembayaranVM.PembayaranRepo();    // Updating the DataTable

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Pembayaran tempPembayaran = (Pembayaran)gridTable.SelectedItem;
            Frame.Navigate(new EditPembayaran(Frame, PembayaranVM, tempPembayaran));
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
