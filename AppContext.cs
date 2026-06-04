using Microsoft.EntityFrameworkCore;
internal class AppContext : DbContext {
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Testdb;Trusted_Connection = True;");
    }
}
