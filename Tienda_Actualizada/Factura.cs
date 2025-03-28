using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Factura
    {
        private List<Producto> productosComprados;
        private double total;
        private DateTime fechaCompra;
        private Usuario usuario;
        public Factura(Usuario usuario)
        {
            this.productosComprados = new List<Producto>();
            total = 0;
            fechaCompra = DateTime.Now;
            this.usuario = usuario;
        }

        public DateTime getFechaCompra()
        {
            return fechaCompra;
        }

        public List<Producto> getProductosComprados()
        {
            return productosComprados;
        }
        public double calcularTotal()
        {
            total = 0;
            foreach(Producto producto in productosComprados)
            {
                total += producto.getPrecio();
            }
            return total;
        }
        public void mostrarFactura()
        {
            Console.WriteLine($"Factura para {usuario.getNombre()}");
            Console.WriteLine($"Fecha: {fechaCompra}");
            Console.WriteLine($"NIT: {usuario.getNIT()}");
            Console.WriteLine("Productos comprados:");
            foreach (Producto producto in productosComprados)
            {
                Console.WriteLine($"{producto.getNombre()} -> {producto.getPrecio()}");
            }
            total = calcularTotal();
            Console.WriteLine($"Total a pagar: {total}");
        }

    }
}
