using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Proyecto_ENT.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);

        IEnumerable<T> GetPaged<TKey>(int pageNumber, int pageSize);
    }
}
