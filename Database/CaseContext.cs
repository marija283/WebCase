using System.Data.Entity;
using WebCase.Models;

namespace Database
{
    public class CaseContext : DbContext
    {
        public CaseContext() : base("CaseContext")
        {

        }

        public DbSet<Case> Cases { get; set; }
    }
}
