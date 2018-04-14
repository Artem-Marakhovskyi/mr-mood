using System.Data.Entity;
using System.Threading.Tasks;

namespace MrMood.DataAccess
{
    public class UnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
