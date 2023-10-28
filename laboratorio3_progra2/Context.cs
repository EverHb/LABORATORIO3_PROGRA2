using Microsoft.EntityFrameworkCore;
public class Context : DbContext
{
    public DbSet<Asignaturas> asignaturas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-H8P0V0H\\SQLEXPRESS;Database=DBlab3; Trusted_Connection = true; ");
    }
}
