using entity;
using data;
using System;
using System.Windows;

namespace Lab07
{
    public partial class InsertarClienteForm : Window
    {
        public InsertarClienteForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí debes validar que los campos estén completos antes de intentar guardar
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Active = chkActive.IsChecked ?? false  // Esto maneja si la casilla está sin marcar (null)
            };

            try
            {
                Dcustomer.InsertarCliente(nuevoCliente);
                MessageBox.Show("Cliente insertado con éxito!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al insertar el cliente: {ex.Message}");
            }
        }
    }
}
