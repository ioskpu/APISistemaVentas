using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class LoginDTO
    {

#pragma warning disable CS8618 // El elemento propiedad "Correo" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public string Correo { get; set; }
#pragma warning restore CS8618 // El elemento propiedad "Correo" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
#pragma warning disable CS8618 // El elemento propiedad "Clave" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public string Clave { get; set; }
#pragma warning restore CS8618 // El elemento propiedad "Clave" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.

    }
}
