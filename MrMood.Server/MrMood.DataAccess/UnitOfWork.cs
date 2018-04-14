using MrMood.DataAccess.Context;
using System.Data.Entity;

namespace MrMood.DataAccess
{
    public class UnitOfWork
    {
        private readonly MoodContext _context;

        public UnitOfWork(MoodContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
