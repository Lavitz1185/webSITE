namespace webSITE.DataAccess.Repositori.Commons
{
    public interface IBaseRepositori<T> where T : class
    {
        Task<T?> Get(int id);
        Task<T?> GetWithDetail(int id);
        Task<List<T>?> GetAll();
        Task<List<T>?> GetAllWithDetail();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
