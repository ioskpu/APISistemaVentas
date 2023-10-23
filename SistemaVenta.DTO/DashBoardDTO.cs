using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class DashBoardDTO
    {
        public int? TotalVentas { get; set; }
#pragma warning disable CS8618 // El elemento propiedad "TotalIngresos" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public string TotalIngresos { get; set; }
#pragma warning restore CS8618 // El elemento propiedad "TotalIngresos" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.

        public int TotalProductos { get; set; } 
#pragma warning disable CS8618 // El elemento propiedad "VentasUltimaSemana" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public List <VentasSemanaDTO> VentasUltimaSemana { set; get; }   
#pragma warning restore CS8618 // El elemento propiedad "VentasUltimaSemana" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
    }
}
