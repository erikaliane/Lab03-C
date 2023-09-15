using Lab03_Consola;
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

namespace Lab03_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = Program.ListarProductosListaObjetos();


        }
        /// List of Authors
        /// </summary>
        /// <returns></returns>
        private List<Producto> LoadCollectionData()
        {
            List<Producto> productos = new List<Producto>();
           
            return productos;
        }

        private void RowColorButton_Click(object sender, RoutedEventArgs e)
        {
            Producto author = (Producto)McDataGrid.SelectedItem;
            //  MessageBox.Show("Selected author: " + author.Name);
        }
    }
}
