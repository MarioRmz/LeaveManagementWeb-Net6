namespace LeaveManagement.Application.Contracts
{
    //Interfaz utilizable en diferentes clases (generica)
    //De esta manera podemos utilizar los metodos para las clases diversas que utilicemos
    public interface IGenericRepository<T> where T : class
    {
        //El <T> representa que el Task en cuestion es relativo al tipo T en que se usa, y puede regresar un valor
        Task<T?> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        //En este caso el task utiliza un entero si o si
        Task<T> AddAsync(T entity);
        //Task<int> GetCountAsync(); //Este comentado es sugerido, mas no se decidieron utilizar
        Task AddRangeAsync(List<T> entities);
        Task<bool> Exist(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
