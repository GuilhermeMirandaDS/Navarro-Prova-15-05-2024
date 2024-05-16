using API_Navarro.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Navarro.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=API_NavarroDB;ConnectRetryCount=0");
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
