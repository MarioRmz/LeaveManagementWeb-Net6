using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    //Hereda de la interfaz y especifica que es un tipo T
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        //Inyeccion del contexto de la db a GenericRepository
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            //Igual que AddAsync, con la diferencia que este permite agregar un listado
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //Al utilizar Set<T> establecemos que la tabla es generica, por lo que el sistema 
            //encontrara el db set acorde al id que se envio para tomarlo como la tabla que afectar
            var entity = await GetAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            //Cualquiera de las 2 opciones son validas
            //context.Entry(entity).State = EntityState.Modified;
            //context.Update(entity);

            //Se actualiza el codigo aqui para lidiar con el auditing y el bug de campos por default 
            //(Explicado mas en LeaveTypesController, en el metodo Edit)
            //Utilizamos la primera opcion de las comentadas para ESPECIFICAR si o si que se esta actualizando y modificando
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
