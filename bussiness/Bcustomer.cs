using entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using data;

namespace bussiness
{
    public class Bcustomer
    {
        public List<Cliente> ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            return clientes;
        }
        public List<Cliente> BuscarPorNombre(string name)
        {
            List<Cliente> customers = new List<Cliente>();
            customers = Dcustomer.ListarClientes();

            var resul= customers.Where(x=> x.Name.Contains( name)).ToList();

            return resul;
        }
    }
}
    