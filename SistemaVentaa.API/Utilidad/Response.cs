using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SistemaVentaa.API.Utilidad
{
    public class Response <T>
    {

         public bool status { get; set; }
#pragma warning disable CS8618 // El elemento propiedad "value" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
         public T value { get; set; }
#pragma warning restore CS8618 // El elemento propiedad "value" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
#pragma warning disable CS8618 // El elemento propiedad "msg" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.
        public string msg { get; set; } 
#pragma warning restore CS8618 // El elemento propiedad "msg" que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declarar el elemento propiedad como que admite un valor NULL.


    }
}
