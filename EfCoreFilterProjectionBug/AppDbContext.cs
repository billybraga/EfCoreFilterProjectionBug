using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EfCoreFilterProjectionBug;

public class AppDbContext : DbContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Child> Children { get; set; }
    public DbSet<GrandChild> GrandChildren { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite(
                new SqliteConnectionStringBuilder
                {
                    DataSource = "testDb.sqlite",
                }.ConnectionString
            );
    }
}