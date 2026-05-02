using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSets - đại diện cho các bảng
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<AppAdvance> AppAdvances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== RELATIONSHIPS =====

            // Category -> Expenses (One-to-Many)
            modelBuilder
                .Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Không cho xóa category nếu còn expense

            // Category -> Budgets (One-to-Many)
            modelBuilder
                .Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Person -> Loans (One-to-Many)
            modelBuilder
                .Entity<Loan>()
                .HasOne(l => l.Person)
                .WithMany(p => p.Loans)
                .HasForeignKey(l => l.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== CONSTRAINTS =====

            // Budget: Unique constraint (CategoryId, Month, Year)
            // 1 category chỉ có 1 budget mỗi tháng
            modelBuilder
                .Entity<Budget>()
                .HasIndex(b => new
                {
                    b.CategoryId,
                    b.Month,
                    b.Year,
                })
                .IsUnique();

            // ===== DECIMAL PRECISION =====

            // Expense.Amount
            modelBuilder.Entity<Expense>().Property(e => e.Amount).HasPrecision(18, 2);

            // Budget.Amount
            modelBuilder.Entity<Budget>().Property(b => b.Amount).HasPrecision(18, 2);

            // Budget.WarningThreshold
            modelBuilder.Entity<Budget>().Property(b => b.WarningThreshold).HasPrecision(5, 2);

            // Loan.Amount
            modelBuilder.Entity<Loan>().Property(l => l.Amount).HasPrecision(18, 2);

            // Loan.PaidAmount
            modelBuilder.Entity<Loan>().Property(l => l.PaidAmount).HasPrecision(18, 2);

            // AppAdvance.Amount
            modelBuilder.Entity<AppAdvance>().Property(a => a.Amount).HasPrecision(18, 2);

            // ===== SEED DATA =====

            // Seed Categories (7 categories mặc định)
            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Food & Drink",
                        Icon = "🍔",
                        Color = "#EF4444",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Transport",
                        Icon = "🚗",
                        Color = "#3B82F6",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Entertainment",
                        Icon = "🎮",
                        Color = "#8B5CF6",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Shopping",
                        Icon = "🛍️",
                        Color = "#EC4899",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Bills & Utilities",
                        Icon = "💡",
                        Color = "#F59E0B",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Health & Fitness",
                        Icon = "⚕️",
                        Color = "#10B981",
                        CreatedDate = DateTime.Now,
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Other",
                        Icon = "💰",
                        Color = "#6B7280",
                        CreatedDate = DateTime.Now,
                    }
                );

            // Seed sample People
            modelBuilder
                .Entity<Person>()
                .HasData(
                    new Person
                    {
                        Id = 1,
                        Name = "Minh",
                        PhoneNum = "0901234567",
                        Avatar = "👨",
                        CreatedDate = DateTime.Now,
                    },
                    new Person
                    {
                        Id = 2,
                        Name = "An",
                        PhoneNum = "0909876543",
                        Avatar = "👩",
                        CreatedDate = DateTime.Now,
                    }
                );
        }
    }
}
