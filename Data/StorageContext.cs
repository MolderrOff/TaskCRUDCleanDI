using Microsoft.EntityFrameworkCore;
using TaskCRUDCleanDI.Models;

// сделать миграцию
//через терминал

// dotnet tool install --global dotnet-ef
// dotnet ef migrations add InitialCreate
// dotnet ef database update 

namespace TaskCRUDCleanDI.Data
{
    public class StorageContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }        
        private readonly string _dbConnectionString;
        public StorageContext() {}
        public StorageContext(string connection)
        {
            _dbConnectionString = connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=books;TrustServerCertificate=True;Trusted_Connection=True;")
            .UseLazyLoadingProxies()
            .LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id)
                      .HasName("book_pk");

                entity.ToTable("book");

                entity.Property(pr => pr.Name)
                      .HasColumnName("namebook")
                      .HasMaxLength(255);
            });
        }
    }
}
