using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class EditoraContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        
        public EditoraContext(DbContextOptions<EditoraContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
