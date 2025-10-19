using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_ENT.Interfaces;

namespace Proyecto_DAL.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly ProductosDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repositorio(ProductosDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task ActualizarAsync(T entidad)
        {            
            _dbSet.Attach(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AgregarAsync(T entidad)
        {
            _dbSet.Add(entidad);
            return await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entity = await ObtenerPorIdAsync(id) ?? throw new KeyNotFoundException($"No existe una entidad con el id {id}");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ObtenerPaginadoAsync<TKey>(int numeroPagina, int registrosPagina)
        {
            IQueryable<T> query = _dbSet;

            return await query
                            .Skip((numeroPagina - 1) * registrosPagina)
                            .Take(registrosPagina)
                            .ToListAsync();
        }

        public async Task<T> ObtenerPorIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> ObtenerTodosAsync() => await _dbSet.ToListAsync();
    }
}
