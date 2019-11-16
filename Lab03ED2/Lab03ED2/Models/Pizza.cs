using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03ED2.Models
{
    public class Pizza
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string[] Ingredientes { get; set; }
        public string Tipo_Masa { get; set; }
        public string Tamanio { get; set; }
        public int Cantidad_Porciones { get; set; }
        public bool Extra_Queso { get; set; }
    }
}
