using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVentaa.API.Utilidad;

namespace SistemaVentaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;

        public VentaController(IVentaService ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var rsp = new Response<VentaDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _ventaServicio.Registrar(venta);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);


        }


        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string?numeroVenta, string? fechaInicio, string? fechaFin)
        {

            var rsp = new Response<List<VentaDTO>>();
            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "": fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaInicio;


            try
            {

                rsp.status = true;
                rsp.value = await _ventaServicio.Historial(buscarPor,numeroVenta,fechaInicio,fechaFin);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);

        }


        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte( string? fechaInicio, string? fechaFin)
        {

            var rsp = new Response<List<ReporteDTO>>();

         

            try
            {

                rsp.status = true;
#pragma warning disable CS8604 // Posible argumento de referencia nulo para el parámetro "fechaFin" en "Task<List<ReporteDTO>> IVentaService.Reporte(string fechaInicio, string fechaFin)".
#pragma warning disable CS8604 // Posible argumento de referencia nulo para el parámetro "fechaInicio" en "Task<List<ReporteDTO>> IVentaService.Reporte(string fechaInicio, string fechaFin)".
                rsp.value = await _ventaServicio.Reporte(fechaInicio, fechaFin);
#pragma warning restore CS8604 // Posible argumento de referencia nulo para el parámetro "fechaInicio" en "Task<List<ReporteDTO>> IVentaService.Reporte(string fechaInicio, string fechaFin)".
#pragma warning restore CS8604 // Posible argumento de referencia nulo para el parámetro "fechaFin" en "Task<List<ReporteDTO>> IVentaService.Reporte(string fechaInicio, string fechaFin)".


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);

        }


    }
}
