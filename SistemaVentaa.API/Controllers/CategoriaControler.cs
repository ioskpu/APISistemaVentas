using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVentaa.API.Utilidad;

namespace SistemaVentaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaControler : ControllerBase
    {
        private readonly ICategoriaService _categoriaServicio;
public CategoriaControler(ICategoriaService categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;


        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {

            var rsp = new Response<List<CategoriaDTO>>();
            try
            {

                rsp.status = true;
                rsp.value = await _categoriaServicio.Lista();


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
