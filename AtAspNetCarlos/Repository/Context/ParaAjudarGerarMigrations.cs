using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<EditoraContext>
    {
        public EditoraContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EditoraContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AtAspNetCarlos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new EditoraContext(optionsBuilder.Options);
        }
    }
}
