using Hospital.Repositories.Interface;

namespace Hospital.Repositories.Implementation;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    private bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        IRepository<T> repo = new Repository<T>(_context);
        return repo;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
