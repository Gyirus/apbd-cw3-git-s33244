namespace apbd_cw3_s33244.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetById(string id);
    void Add(T entity);
    void Remove(T entity);
}