using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Quote.DataAccess.Models;

namespace Quote.DataAccess.DbLayers
{
    public class QuoteDbContext : DbContext
    {
          private readonly string connectionString;
        public QuoteDbContext(string connectionString)
        : base(GetOptions(connectionString))
        {
             this.connectionString = connectionString;
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public QuoteDbContext(DbContextOptions<QuoteDbContext> options)
          : base(options)
        {
        }

        public virtual DbSet<Models.Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                // optionsBuilder.UseSqlServer("Data Source=10.9.30.23,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;");
                // optionsBuilder.UseSqlServer("Data Source=192.168.86.71,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
    public class QuoteContextFactory : IDesignTimeDbContextFactory<QuoteDbContext>
    {
        public QuoteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuoteDbContext>();
            optionsBuilder.UseSqlServer("Data Source=10.9.30.23,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;");
            // optionsBuilder.UseSqlServer("Data Source=10.9.30.23,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;");
            //  optionsBuilder.UseSqlServer("Data Source=192.168.86.71,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;");
            return new QuoteDbContext(optionsBuilder.Options);
        }
    }
}
