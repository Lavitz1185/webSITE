namespace webSITE.Repositori.Commons
{
    public interface IBaseRepositori<T> where T : class
    {
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
    }
}
