using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lan2.Models;

namespace lan2.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<lan2.Models.User> User { get; set; } = default!;
        public DbSet<lan2.Models.Job> Job { get; set; } = default!;
    }
}
