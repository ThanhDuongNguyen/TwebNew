using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tweb.Mails.DataAccess
{
    public class Mail
    {
        public int MailID { get; set; }
        public string Sender { get; set; }
        public string MailProvider { get; set; }
        public string Content { get; set; }
    }
    public class TwebMailDbContext : DbContext
    {
        public TwebMailDbContext(DbContextOptions<TwebMailDbContext> option) : base(option)
        {
        }
        public DbSet<Mail> Mails { get; set; }
    }

    public class TwebMailDbContextFactory : IDesignTimeDbContextFactory<TwebMailDbContext>
    {
        public TwebMailDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TwebNew"))
           .AddJsonFile("appsettings.json")
           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TwebMailDbContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Tweb"]);

            return new TwebMailDbContext(optionsBuilder.Options);
        }
    }
}
