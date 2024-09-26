using Microsoft.EntityFrameworkCore;


    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; } // Representa la tabla Clientes



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultadoProcedimiento>(entity =>
            {
                entity.HasNoKey(); // Esto es importante si no tiene clave primaria
                // Configuraciones adicionales si es necesario
            });
        }
    }



