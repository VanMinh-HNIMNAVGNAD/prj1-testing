using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<SinhVien> SinhViens { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}