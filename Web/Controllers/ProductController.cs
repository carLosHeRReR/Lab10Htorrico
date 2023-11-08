using bussiness;
using entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.Models;
using data;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private Bproducto _bProducto;

        public ProductController()
        {
            _bProducto = new Bproducto();
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<Producto> productos = _bProducto.BuscarPorNombre("");

            List<ProductModel> models = productos.Select(x => new ProductModel
            {
                ProductID = x.ProductID,
                Name = x.Name,
                Stock = x.Stock,
                Price = x.Price,
                Active = x.Active
            }).ToList();

            return View(models);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoProducto = new Producto
                    {
                        Name = model.Name,
                        Stock = model.Stock,
                        Price = model.Price,
                        Active = true
                    };

                    Dproduct.InsertarProducto(nuevoProducto);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = _bProducto.BuscarPorId(id); // Cambiar BuscarPorNombre a BuscarPorId

            if (producto == null)
            {
                return NotFound();
            }

            var model = new ProductModel
            {
                ProductID = producto.ProductID,
                Name = producto.Name,
                Stock = producto.Stock,
                Price = producto.Price,
                Active = producto.Active
            };

            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel model)
        {
            if (id != model.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    ProductID = model.ProductID,
                    Name = model.Name,
                    Stock = model.Stock,
                    Price = model.Price,
                    Active = model.Active
                };

                Dproduct.ModificarProducto(producto);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto = _bProducto.BuscarPorId(id); // Cambiar BuscarPorNombre a BuscarPorId

            if (producto == null)
            {
                return NotFound();
            }

            var model = new ProductModel
            {
                ProductID = producto.ProductID,
                Name = producto.Name,
                Stock = producto.Stock,
                Price = producto.Price,
                Active = producto.Active
            };

            return View(model);
        }


        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Dproduct.EliminarProductoLogicamente(id);

            return RedirectToAction("Index");
        }
    }
}
