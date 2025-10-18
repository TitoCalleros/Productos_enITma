using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto_ENT.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(T entidad);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);

        Task<IEnumerable<T>> ObtenerPaginadoAsync<TKey>(int numeroPagina, int registrosPagina);
    }
}
