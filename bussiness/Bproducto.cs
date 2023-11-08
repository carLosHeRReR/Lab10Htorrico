using data;
using entity;
using System.Collections.Generic;

namespace bussiness
{
    public class Bproducto
    {
        public List<Producto> ListarProducto()
        {
            List<Producto> productos = new List<Producto>();
            return productos;
        }

        public List<Producto> BuscarPorNombre(string name)
        {
            List<Producto> products = new List<Producto>();
            products = Dproduct.ListarProductos();

            var resul = products.Where(x => x.Name.Contains(name)).ToList();

            return resul;
        }

        public Producto BuscarPorId(int productId)
        {
            List<Producto> products = Dproduct.ListarProductos();
            return products.FirstOrDefault(p => p.ProductID == productId);
        }
    }
}
