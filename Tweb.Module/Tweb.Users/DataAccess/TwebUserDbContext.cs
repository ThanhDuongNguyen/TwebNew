using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tweb.Users.DataAccess
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class TwebUserDbContext : DbContext
    {
        public TwebUserDbContext( DbContextOptions<TwebUserDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
    }
}
