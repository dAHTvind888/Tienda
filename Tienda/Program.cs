using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto producto1 = new Producto(1, "iphone", 100, "celular");
            Producto producto2 = new Producto(2, "iphone", 100, "celular");
            Producto producto3 = new Producto(3, "iphone", 100, "celular");

            Producto producto4 = new Producto(4, "cuaderno", 50.5, "escolar");
            Producto producto5 = new Producto(5, "lapiz", 2.99, "escolar");

            Producto producto6 = new Producto(6, "clavo", 0.5, "construccion");

            Inventario inventario = new Inventario();

            inventario.agregarProducto(producto1);
            inventario.agregarProducto(producto2);
            inventario.agregarProducto(producto3);
            inventario.agregarProducto(producto4);
            inventario.agregarProducto(producto5);
            inventario.agregarProducto(producto6);


            int rolTipo;
            int? NIT = null;
            Usuario usuario;
            Usuario usuario1 = new Usuario(Rol.Administrador, "Admin");
            
            string nombreProducto;
            int cantidad;
            string opcionUsuario;

            Console.WriteLine("Bienvenido");
            Console.WriteLine("Eres un cliente o administrador (cliente = 1, administrador = 2)");
            while (true)
            {
                string inputRolTipo = Console.ReadLine();
                if (int.TryParse(inputRolTipo, out rolTipo))
                {
                    if(rolTipo != 1 && rolTipo != 2)
                    {
                        Console.WriteLine("Opcion no valida");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Entrada no valida");
            }
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            if(rolTipo == 1)
            {
                while (true)
                {
                    Console.WriteLine("Deseas ingresar tu NIT? (s/n)");
                    string respuesta = Console.ReadLine();
                    if (respuesta == "s")
                    {
                        Console.WriteLine("NIT: ");
                        while (true)
                        {
                            string respuestaNIT = Console.ReadLine();
                            //una variable temporal para pasar el valor a NIT
                            int tempNIT;
                            if (int.TryParse(respuestaNIT, out tempNIT))
                            {
                                NIT = tempNIT;
                                break;
                            }
                            Console.WriteLine("Entrada no valida");
                        }
                        break;
                    }
                    else if(respuesta == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entrada no valida");
                    }
                }
                usuario = new Usuario(Rol.Cliente, nombre, NIT);
            }
            else
            {
                usuario = new Usuario(Rol.Administrador, nombre, NIT);
            }
            if(usuario.getRolTipo() == Rol.Cliente)
            {
                
                Console.WriteLine("1. Mostrar Carrito | 2. Agregar Al Carrito | 3. Remover Del Carrito | 4. Confirmar Compra | 5. Mostrar Productos Disponibles | 6. Salir");
                opcionUsuario = Console.ReadLine();
                while(opcionUsuario != "6")
                {
                    if (opcionUsuario == "1")
                    {
                        usuario.mostrarCarrito();
                    }
                    else if (opcionUsuario == "2")
                    {
                        Console.Write("Nombre del producto a agregar: ");
                        nombreProducto = Console.ReadLine();
                        Console.Write("Cantidad a Agregar: ");
                        cantidad = int.Parse(Console.ReadLine());
                        usuario.agregarAlCarrito(nombreProducto, cantidad, ref inventario);
                    }
                    else if (opcionUsuario == "3")
                    {
                        Console.Write("Nombre del Producto a remover del Carrito:");
                        nombreProducto = Console.ReadLine();
                        Console.Write("Cantidad a Eliminar: ");
                        cantidad = int.Parse(Console.ReadLine());
                        usuario.removerDelCarrito(nombreProducto, cantidad, ref inventario);
                    }
                    else if (opcionUsuario == "4")
                    {
                        Factura factura = new Factura(usuario);
                        usuario.confirmarCompra(ref inventario, ref factura);
                    }
                    else if(opcionUsuario == "5")
                    {
                        usuario.mostrarInventario(ref inventario);
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida");
                    }
                    Console.WriteLine("1. Mostrar Carrito | 2. Agregar Al Carrito | 3. Remover Del Carrito | 4. Confirmar Compra | 5. Mostrar Productos Disponibles | 6. Salir");
                    opcionUsuario = Console.ReadLine();
                }
                Console.WriteLine("Gracias por tu visita!");
            }
            else if(usuario.getRolTipo() == Rol.Administrador)
            {
                Console.WriteLine("1. Agregar al Inventario | 2. Remover del Inventario | 3. Mostrar Inventario | 4. Salir");
                opcionUsuario = Console.ReadLine();
                while(opcionUsuario != "4")
                {
                    if (opcionUsuario == "1")
                    {
                        usuario.agregarProducto(ref inventario);
                    }
                    else if (opcionUsuario == "2")
                    {
                        Console.WriteLine("Id del Producto a Eliminar: ");
                        int productoId = int.Parse(Console.ReadLine());
                        usuario.removerProducto(productoId, ref inventario);
                    }
                    else if (opcionUsuario == "3")
                    {
                        usuario.mostrarInventario(ref inventario);
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida");
                    }
                    Console.WriteLine("1. Agregar al Inventario | 2. Remover del Inventario | 3. Mostrar Inventario | 4. Salir");
                    opcionUsuario = Console.ReadLine();
                }
                Console.WriteLine("Sesion cerrada");
            }
        }
    }
}
