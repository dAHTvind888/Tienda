using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Reporte
    {
        private List<Factura> listaFacturas;
        
        public Reporte(List<Factura> listaFacturas)
        {
            this.listaFacturas = listaFacturas;
        }

        public double totalGanadoEnDia(DateTime fecha)
        {
            return listaFacturas
                //filtra las facturas por fecha
                .Where(factura => factura.getFechaCompra().Date == fecha.Date) 
                //suma el total de cada factura de listaFacturas
                .Sum(factura => factura.calcularTotal()); 
        }
    }
}
