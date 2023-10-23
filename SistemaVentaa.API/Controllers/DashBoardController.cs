using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVentaa.API.Utilidad;

namespace SistemaVentaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoarService _dashBoardServicio;

        public DashBoardController(IDashBoarService dashBoarService)
        {
            _dashBoardServicio = dashBoarService;
        }
        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {

            var rsp = new Response<DashBoardDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _dashBoardServicio.Resumen();


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
