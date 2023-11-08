using entity;
using data;
using System;
using System.Windows;

namespace Lab07
{
    public partial class ModificarClienteForm : Window
    {
        public ModificarClienteForm()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text))
            {
                MessageBox.Show("Por favor, introduzca el Customer ID.");
                return;
            }

            Cliente clienteAModificar = new Cliente
            {
                CustomerID = int.Parse(txtCustomerId.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Active = chkActive.IsChecked ?? false
            };

            Dcustomer.ModificarCliente(clienteAModificar);
            MessageBox.Show("Cliente modificado con éxito!");
            this.Close();
        }
    }
}
