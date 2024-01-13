namespace webSITE.Repositori.Commons
{
    public interface IBaseRepositori<T> where T : class
    {
        Task<T> Get(int id);
        Task<T> GetWithDetail(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithDetail();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
