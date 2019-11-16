using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03ED2.Models
{
    public class Pizza
    {
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string[] Ingredientes { get; set; }
        string Tipo_Masa { get; set; }
        string Tamanio { get; set; }
        int Cantidad_Porciones { get; set; }
        bool Extra_Queso { get; set; }
    }
}
