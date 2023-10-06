namespace Hospital.Repositories.Interface;
public interface IUnitOfWork
{
    IRepository<T> Repository<T>() where T : class;
    void Save();
}
