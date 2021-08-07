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
using KosGue2.Pembayaran;
using KosGue2.Petugas;

namespace KosGue2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PembayaranViewModel PembayaranVM { get; set; }
        //public PetugasViewModel PetugasVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            PembayaranVM = new PembayaranViewModel();
            //PetugasVM = new PetugasViewModel();
            Frame.Navigate(new Menup(PembayaranVM));
            //Frame.Navigate(new Menup(PetugasVM));
        }
    }
}
