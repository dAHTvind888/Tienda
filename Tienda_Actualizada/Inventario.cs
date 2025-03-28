using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Inventario
    {
        private List<Producto> listaProductos;

        public Inventario()
        {
            listaProductos = new List<Producto>();
        }

        public void mostrarListaProductos()
        {
            foreach(Producto producto in listaProductos)
            {
                Console.WriteLine(producto.getNombre() + " cantida: " + this.stock(producto.getNombre()));
            }
        }
        public int stock(string nombreProducto)
        {
            int stockDisponible = 1;
            foreach(Producto producto in listaProductos)
            {
                if(producto.getNombre() == nombreProducto)
                {
                    stockDisponible++;
                }
            }
            return stockDisponible;
        }
        public void agregarProducto(Producto producto)
        {
            //.Any(condicion) returns true if codicion is met else false
            if(listaProductos.Any(p => p.getProductId() == producto.getProductId()))
            {
                Console.WriteLine($"Ya existe un producto con el id = {producto.getProductId()}");
                return;
            }
            listaProductos.Add(producto);
        }
        
        public void eliminarProducto(string nombreProducto)
        {
            //FirstOrDefault returns the first elements that satisfies (condition) else return null
            Producto producto = listaProductos.FirstOrDefault(p => p.getNombre() == nombreProducto);
            if(producto != null)
            {
                listaProductos.Remove(producto);
                return;
            }
            Console.WriteLine("Producto no encontrado");
        }

        public List<Producto> getListaProductos()
        {
            return listaProductos;
        }
    }
}
