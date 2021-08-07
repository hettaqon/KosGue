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

namespace KosGue2.Aduan
{
    /// <summary>
    /// Interaction logic for Aduanp.xaml
    /// </summary>
    public partial class Aduanp : UserControl
    {
        AduanViewModel AduanVM;
        Frame Frame;
        public Aduanp()
        {
            InitializeComponent();
        }

        public Aduanp(Frame frame, AduanViewModel AduanVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.AduanVM = AduanVM;

            this.Loaded += AduanPage_Loaded;
            AddBtn.IsEnabled = true;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
        }

        private void AduanPage_Loaded(object sender, RoutedEventArgs e)
        {
            gridTable.DataContext = AduanVM.AduanRepo();

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
            AduanVM = new AduanViewModel();
            Frame.Navigate(new AddAduan(this.Frame, this.AduanVM));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Aduan aduan = (Aduan)gridTable.SelectedItem;
            AduanVM.DeleteAduanFromRepo(aduan.KodeAduan);
            gridTable.DataContext = AduanVM.AduanRepo();    // Updating the DataTable
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Aduan tempAduan = (Aduan)gridTable.SelectedItem;
            Frame.Navigate(new EditAduan(Frame, AduanVM, tempAduan));
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
