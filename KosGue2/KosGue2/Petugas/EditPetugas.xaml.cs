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
    /// Interaction logic for EditPetugas.xaml
    /// </summary>
    public partial class EditPetugas : UserControl
    {
        private Frame Frame;
        private PetugasViewModel PetugasVM;
        private Petugas Petugas;

        public EditPetugas()
        {
            InitializeComponent();
        }

        public EditPetugas(Frame frame, PetugasViewModel petugasVM, Petugas petugas)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PetugasVM = petugasVM;
            this.Petugas = petugas;
            // Loading Record into TextBoxes
            this.KodePetugasTBox.Text = petugas.KodePetugas.ToString();
            this.NamaTBox.Text = petugas.Nama;
            this.NoHPTBox.Text = petugas.NoHP;
            this.JobTBox.Text = petugas.Job;
            this.ShiftTBox.Text = petugas.Shift;
            this.editBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for edit Button
         * edits the record in Collection
         */
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Petugas tempPetugas = new Petugas();
            tempPetugas.KodePetugas = int.Parse(KodePetugasTBox.Text.ToString());
            tempPetugas.Nama = NamaTBox.Text;
            tempPetugas.NoHP = NoHPTBox.Text;
            tempPetugas.Job = JobTBox.Text;
            tempPetugas.Shift = ShiftTBox.Text;
            PetugasVM.UpdatePetugasInRepo(tempPetugas);
            MessageBox.Show("Petugas sudah diganti", "Sukses !");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Petugas
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        /* 
         * Function: Event Handler for TextBox
         * Enable update button if text is edited in Box
         */
        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(
                this.Petugas.KodePetugas.Equals(int.Parse(this.KodePetugasTBox.Text))
                && this.Petugas.Nama.Equals(this.NamaTBox.Text)
                && this.Petugas.NoHP.Equals(this.NoHPTBox.Text)
                && this.Petugas.Job.Equals(this.JobTBox.Text)
                && this.Petugas.Shift.Equals(this.ShiftTBox.Text)))
            {
                editBtn.IsEnabled = true;
            }
        }
    }
}
