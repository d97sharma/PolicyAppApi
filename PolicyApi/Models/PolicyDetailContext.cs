using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyApi.Models
{
    public class PolicyDetailContext : DbContext
    {
        public PolicyDetailContext(DbContextOptions<PolicyDetailContext> options) : base(options)
        {

        }

        public DbSet<PolicyDetail> PolicyDetails { get; set; }
    }
}
