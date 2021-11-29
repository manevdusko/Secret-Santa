using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SecretSantaContext: DbContext
    {
        public SecretSantaContext(DbContextOptions<SecretSantaContext> options) : base(options)
        {

        }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Host> Hosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer("Data Source = SQL5080.site4now.net; Initial Catalog = db_a7d1a0_test; User Id = db_a7d1a0_test_admin; Password = TestPass1!");
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=test;password=test;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
