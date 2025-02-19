using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiataProjectTracker.Models;

namespace MiataProjectTracker.Data
{
    public class MiataProjectTrackerContext : DbContext
    {
        public MiataProjectTrackerContext(DbContextOptions<MiataProjectTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<MiataProjectTracker.Models.Parts> Parts { get; set; } = default!;
        public DbSet<MiataProjectTracker.Models.BuildLog> BuildLog { get; set; } = default!;
        public DbSet<MiataProjectTracker.Models.PriceComparison> PriceComparison { get; set; } = default!;
        public DbSet<MiataProjectTracker.Models.BuildTasks> BuildTasks { get; set; } = default!;
    }
}