using Microsoft.EntityFrameworkCore;
using OrchardCore.Environment.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwebNew.DataAccess
{
    public class TwebDbContext : DbContext
    {
        private readonly string _connectionString;
        public TwebDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
