using server.Contexts;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
