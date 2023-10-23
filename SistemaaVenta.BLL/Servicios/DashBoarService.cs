using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using AutoMapper;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;

namespace SistemaVenta.BLL.Servicios
{
    public class DashBoarService: IDashBoarService
    {
        private readonly IVentaRepository _ventaRepositorio;
        private readonly IGenericRepository<Producto> _productoRepositorio;
        private readonly IMapper _mapper;

        public DashBoarService(IVentaRepository ventaRepositorio, IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _ventaRepositorio = ventaRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }



        private IQueryable<Venta> retornarVentas(IQueryable<Venta> tablaVenta,int restarCantidadDias)
        {
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).Select(v=>v.FechaRegistro).First();
#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
            return tablaVenta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
        }


        private async Task<int> TotalVentasUltimasSemana()
        {
            int total = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();

            if(_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                total = tablaVenta.Count();
            }

            return total;

        }

        private async Task<string> TotalIngresosUltimaSemana()
        {
            decimal resultado = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();
            if (_ventaQuery.Count() > 0)
            {
                var tablaventa = retornarVentas(_ventaQuery, -7);
#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                resultado = tablaventa.Select(v => v.Total).Sum(v=> v.Value);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.

            }


            return Convert.ToString(resultado,new CultureInfo("es_es"));
        }


        private async Task<int> TotalProductos()
        {
            IQueryable<Producto> _productoQuery = await _productoRepositorio.Consultar();
            int total = _productoQuery.Count(); 
            return total;
        }


        private async Task<Dictionary<string, int>> VentasUltimaSemana()
        {
            Dictionary<string,int> resultado = new Dictionary<string,int>();
            IQueryable<Venta> _ventaQuery = await _ventaRepositorio.Consultar();
            if (_ventaQuery.Count()> 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date).OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.


            }

            return resultado;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashBoard = new DashBoardDTO();
            try 
            {
                vmDashBoard.TotalVentas = await TotalVentasUltimasSemana();
                vmDashBoard.TotalIngresos = await TotalIngresosUltimaSemana();
                vmDashBoard.TotalProductos = await TotalProductos();


                List<VentasSemanaDTO> listaVentaSemana = new List<VentasSemanaDTO>();

                    foreach(KeyValuePair<string,int> item in await VentasUltimaSemana())
                {

                    listaVentaSemana.Add(new VentasSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                    vmDashBoard.VentasUltimaSemana = listaVentaSemana;


                }
            
            }
            catch { throw; }
            return vmDashBoard;
        }
    }
}
