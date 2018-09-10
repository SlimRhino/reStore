using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace restore.Data
{
    public class ApplicationContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
    }
}
