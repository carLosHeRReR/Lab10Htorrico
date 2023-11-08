using data;
using entity;
using System;
using System.Windows;

namespace Lab07
{
    public partial class EliminarClienteForm : Window
    {
        public EliminarClienteForm()
        {
            InitializeComponent();
        }

        private void btnConfirmarEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text))
            {
                MessageBox.Show("Por favor, introduzca el Customer ID.");
                return;
            }

            int customerId = int.Parse(txtCustomerId.Text);
            Dcustomer.EliminarClienteLogicamente(customerId);

            MessageBox.Show("Cliente eliminado con éxito (eliminación lógica)!");
            this.Close();
        }
    }
}
