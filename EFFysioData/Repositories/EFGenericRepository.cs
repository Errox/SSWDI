using DomainServices.Repositories;
using EFFysioData.DAL;

namespace EFFysioData.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFGenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">ApplicationDbContext.</param>
        public EFGenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity FindByID(int ID)
        {
            return _context.Set<TEntity>().Find(ID);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(int id, TEntity entity)
        {
            TEntity obj = _context.Set<TEntity>().Find(id);
            if (obj != null)
            {
                _context.Entry(obj).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }
    }
}

