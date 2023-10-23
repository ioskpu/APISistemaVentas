using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        //Metodos para realizar el CRUD
        Task<TModel>Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel modelo);

        Task<bool> Editar(TModel modelo);
        Task<bool> Delete(TModel modelo);

#pragma warning disable CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);
#pragma warning restore CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.

    }
}
