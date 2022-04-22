using System;
using Microsoft.EntityFrameworkCore;
using TestDeveloper.Services.Domain.Entities;

namespace TestDeveloper.Service.Infraestructure.DBContext
{
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Inicializa el cosntructor
        /// </summary>
        /// <param name="options">Instancia de mapper.</param>
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        /// <summary>
        /// Obtiene o establece el identificador del modelo de datos de la tabla Authors
        /// </summary>
        public DbSet<Author> Author { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la tabla Books
        /// </summary>
        public DbSet<Book> Book { get; set; }

        //{CODEDELPHIINJECTION}

        /// <summary>
        /// Inicializa una nueva instancia del objeto <see cref="OnModelCreating"/> class.
        /// </summary>
        /// <param name="modelBuilder">Instancia de mapper.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasForeignKey(p => p.AuthorId);
        }
    }
}
