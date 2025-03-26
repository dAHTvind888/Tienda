using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public enum Rol { Cliente, Administrador };
    public class Usuario
    {
        private Rol rolTipo;
        private List<string> carrito;
        private string nombre;
        private int NIT;

        //? permite que el valor pueda ser null
        public Usuario(Rol rolTipo, string nombre, int? NIT = null)
        {
            this.rolTipo = rolTipo;
            carrito = new List<string>();
            this.nombre = nombre;
            //?? asigna 0 a this.NIT si NIT es null
            this.NIT = NIT ?? 0;
        }
        public Rol getRolTipo()
        {
            return this.rolTipo;
        }

        public string getNombre()
        {
            return nombre;
        }
        public int getNIT()
        {
            return NIT;
        }
        public void mostrarCarrito()
        {
            foreach(string carrito in carrito)
            {
                Console.WriteLine(carrito);
            }
        }
        public void agregarAlCarrito(string nombreProducto, int cantidad, ref Inventario inventario)
        {
            if(rolTipo == Rol.Cliente)
            {
                //List<Producto> refListaProductos = inventario.getListaProductos();
                //Producto producto = refListaProductos.FirstOrDefault(n => n.getNombre() == nombreProducto);
                
                if(inventario.stock(nombreProducto) > cantidad)
                {
                    while (cantidad > 0)
                    {
                        carrito.Add(nombreProducto);
                        cantidad--;
                    }
                }
                else
                {
                    Console.WriteLine("Producto sin stock suficiente");
                }
            }
            else
            {
                Console.WriteLine("Accion no permitida");
            }
        }

        public void removerDelCarrito(string nombreProducto, int cantidad, ref Inventario inventario)
        {
            if(rolTipo == Rol.Cliente)
            {
                int contador = carrito.Count(nombre => nombre == nombreProducto);
                if (contador == 0)
                {
                    Console.Write("No existe tal producto");
                }
                else if (cantidad > contador) 
                {
                    Console.WriteLine("La cantidad a eliminar es mayor que la cantidad actual en el carrito");
                }
                else 
                {
                    for(int i = 0; i < cantidad; i++)
                    {
                        carrito.Remove(nombreProducto);
                    }
                }
                return;
            }
            else
            {
                Console.WriteLine("Accion no permitida");
            }
        }

        public void confirmarCompra(ref Inventario inventario, ref Factura factura)
        {
            if(rolTipo== Rol.Cliente)
            {
                List<Producto> refListaProductos = inventario.getListaProductos();
                List<Producto> refproductosComprados = factura.getProductosComprados();
                while (carrito.Count > 0)
                {
                    string productoDeCarrito = carrito.First();
                    Producto productoEliminar = refListaProductos.Find(p => p.getNombre() == productoDeCarrito);
                    refproductosComprados.Add(productoEliminar);
                    refListaProductos.Remove(productoEliminar);
                    carrito.RemoveAt(0);
                }
                //dependencia circular, usamos this para pasar el objetoc Usuario que llama al metodo confirmarCompra()
                //Factura crearFactura = new Factura(this);
                factura.mostrarFactura();
            }
            else
            {
                Console.WriteLine("Accion no permitida");
            }
        }

        public void agregarProducto(ref Inventario inventario)
        {
            if(rolTipo == Rol.Administrador)
            {
                int productoId;
                double precio;
                string nombre, categoria;
                Console.WriteLine("Agregar producto:");
                while (true)
                {
                    Console.Write("ProducotId = ");
                    string inputProductoId = Console.ReadLine();

                    if (int.TryParse(inputProductoId, out productoId))
                    {
                        break;
                    }
                    Console.WriteLine("Entrada no valida");
                }
                while (true)
                {
                    Console.Write("Precio = ");
                    string inputPrecio = Console.ReadLine();
                    if(double.TryParse(inputPrecio, out precio))
                    {
                        break;
                    }
                    Console.WriteLine("Entrada no valida");
                }

                Console.Write("Nombre = ");
                nombre = Console.ReadLine();

                Console.Write("Categoria = ");
                categoria = Console.ReadLine();

                Producto producto = new Producto(productoId, nombre, precio, categoria);
                List<Producto> refListaProducto = inventario.getListaProductos();
                refListaProducto.Add(producto);
            }
            else
            {
                Console.WriteLine("Accion no permitida");
            }
        }

        public void removerProducto(int productoId, ref Inventario inventario)
        {
            if(rolTipo == Rol.Administrador)
            {
                List<Producto> refListaProductos = inventario.getListaProductos();
                Producto productoEliminar = refListaProductos.Find(p => p.getProductId() == productoId);
                refListaProductos.Remove(productoEliminar);
            }
            else
            {
                Console.WriteLine("Accion no permitida");
            }
        }
        public void mostrarInventario(ref Inventario inventario)
        {
            List<Producto> reflistaProductos = inventario.getListaProductos();
            foreach (Producto producto in reflistaProductos)
            {
                Console.Write("Producto Id = ");
                Console.WriteLine(producto.getProductId());
                Console.Write("Nombre = ");
                Console.WriteLine(producto.getNombre());
                Console.Write("Categoria = ");
                Console.WriteLine(producto.getCategoria());
                Console.Write("Precio = ");
                Console.WriteLine(producto.getPrecio());
                Console.WriteLine();
            }
        }
    }
}
