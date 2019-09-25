using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.DbLayers
{
    public class AppDbContext : DbContext
    {
        private readonly AppOptions appOptions;

        public AppDbContext(DbContextOptions<AppDbContext> options) : this(options, new AppOptions())
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, AppOptions appOptions) : base(options)
        {
            this.appOptions = appOptions;
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly, appOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}