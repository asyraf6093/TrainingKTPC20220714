using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingKTPC20220714.Models;

namespace TrainingKTPC20220714.Data
{
    public class TrainingKTPC20220714Context : DbContext
    {
        public TrainingKTPC20220714Context (DbContextOptions<TrainingKTPC20220714Context> options)
            : base(options)
        {
        }

        public DbSet<TrainingKTPC20220714.Models.Bangunan> Bangunan { get; set; } = default!;
        public DbSet<TrainingKTPC20220714.Models.Lokasi> Lokasi { get; set; } = default!;
    }
}
