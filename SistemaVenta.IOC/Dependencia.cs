﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.Repositorios;

using SistemaVenta.Utility;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.BLL.Servicios;
using SistemaVenta.DTO;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {

        public static void inyectarDependecias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbventaContext>(options => { options.UseSqlServer(configuration.GetConnectionString("cadenaSQL")); }
                );

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IDashBoarService, DashBoarService>();
            services.AddScoped<IMenuService, MenuService>();





        }
    }
}
