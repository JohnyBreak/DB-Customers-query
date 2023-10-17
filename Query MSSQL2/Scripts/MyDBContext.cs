
using System.Data.Entity;

namespace Query_MSSQL2.Scripts
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DBConnectionString") 
        {

        }

        public void ReCreateDB() 
        {
            Database.Delete();
            Database.Create();
        }

        public DbSet<Manager> managers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
