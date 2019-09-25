using System;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.DbLayers
{
    public class AppOptions
    {
        internal Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        /// <summary>
        ///     Get or set a new action for add new configuration for <see cref="DbContextOptionsBuilder" />
        /// </summary>
        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

        /// <summary>
        ///     Get or set default schema for store configuration tables.
        /// </summary>
        public string DefaultSchema { get; set; } = null;

        /// Get or set default table configuration for ApiKeys.
        /// </summary>
        public TableConfiguration Products { get; set; } = new TableConfiguration("Products");
    }
}