using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tweb.Users.DataAccess
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class TwebUserDbContext : DbContext
    {
        public TwebUserDbContext( DbContextOptions<TwebUserDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
    }

    public class TwebUserDbContextFactory : IDesignTimeDbContextFactory<TwebUserDbContext>
    {
        public TwebUserDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TwebNew"))
           .AddJsonFile("appsettings.json")
           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TwebUserDbContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Tweb"]);

            return new TwebUserDbContext(optionsBuilder.Options);
        }
    }
}
