using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Producto
    {
        private int productoId;
        private string nombre;
        private double precio;
        private string categoria;
        public Producto(int productoId, string nombre, double precio, string categoria)
        {
            this.productoId = productoId;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }

        public int getProductId() 
        { 
            return productoId; 
        }
        public void setProductoId(int productoId) 
        { 
            this.productoId = productoId; 
        }
        public string getNombre() 
        { 
            return nombre; 
        }
        public void setNombre(string nombre) 
        {  
            this.nombre = nombre; 
        }
        public double getPrecio() 
        { 
            return precio; 
        }
        public void setPrecio(double precio) 
        {  
            this.precio = precio; 
        }
        public string getCategoria() 
        { 
            return categoria; 
        }
        public void setCategoria(string categoria) 
        {  
            this.categoria = categoria;
        }
    }
}
