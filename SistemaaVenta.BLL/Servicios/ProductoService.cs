﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;


namespace SistemaVenta.BLL.Servicios
{
    public class ProductoService : IProductoService
    {

        private readonly IGenericRepository<Producto> _productoRepositorio;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> Lista()
        {
            try {

                var queryProducto = await _productoRepositorio.Consultar();
                var listaProductos = queryProducto.Include(cat => cat.IdCategoriaNavigation).ToList();

                return _mapper.Map<List<ProductoDTO>>(listaProductos.ToList());
            
            } catch {
                throw;
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try 
            {
            var productoCreado = await _productoRepositorio.Crear(_mapper.Map<Producto>(modelo));
                if(productoCreado.IdProducto == 0 ) 
                    throw new TaskCanceledException("no te creo naranja");

                return _mapper.Map<ProductoDTO>(productoCreado);
            
            
            } catch { throw; }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            
            {
                var productoModelo = _mapper.Map<Producto>(modelo);
                var productoEncontrado = await _productoRepositorio.Obtener(u => u.IdProducto == productoModelo.IdProducto);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("FANTASSSSMA");

                productoEncontrado.Nombre = productoModelo.Nombre;
                productoEncontrado.IdCategoria = productoModelo.IdCategoria;
                productoEncontrado.Stock = productoModelo.Stock;
                productoEncontrado.Precio= productoModelo.Precio;
                productoEncontrado.EsActivo = productoModelo.EsActivo;


                bool repuesta = await _productoRepositorio.Editar(productoEncontrado);
                if(!repuesta)
                    throw new TaskCanceledException("No te edito nadaaaa");

                return repuesta;


            } 
            
            catch { throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try {

                var productoEncontrado = await _productoRepositorio.Obtener(p => p.IdProducto == id);
                if (productoEncontrado == null) throw new TaskCanceledException("Noooo!!!");

                bool repuesta = await _productoRepositorio.Delete(productoEncontrado);


               
                if (!repuesta)
                    throw new TaskCanceledException("No te elimino nadaaaa");

                return repuesta;




            }
            catch { throw; }
        }


    }
}
