using entity;
using data;
using System;
using System.Windows;

namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            InsertarClienteForm insertForm = new InsertarClienteForm();
            insertForm.ShowDialog();
            
            // Opcionalmente, puedes recargar la lista de clientes después de cerrar el formulario de inserción:
            LoadClients();
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarClienteForm modificarForm = new ModificarClienteForm();
            modificarForm.ShowDialog();

            // Opcionalmente, puedes recargar la lista de clientes después de cerrar el formulario de modificación:
            LoadClients();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarClienteForm eliminarForm = new EliminarClienteForm();
            eliminarForm.ShowDialog();

            // Opcionalmente, puedes recargar la lista de clientes después de cerrar el formulario de eliminación:
            LoadClients();
        }


        private void LoadClients()
        {
            dgSimple.ItemsSource = Dcustomer.ListarClientes();
        }
    } 
}
