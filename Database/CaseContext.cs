using System.Data.Entity;
using WebCase.Models;

namespace CaseDatabase
{
    public class CaseContext : DbContext
    {
        public CaseContext() : base()
        {

        }

        public DbSet<Case> Cases { get; set; }
    }
}
