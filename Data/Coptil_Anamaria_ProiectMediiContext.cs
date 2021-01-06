using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coptil_Anamaria_ProiectMedii.Types;

namespace Coptil_Anamaria_ProiectMedii.Data
{
    public class Coptil_Anamaria_ProiectMediiContext : DbContext
    {
        public Coptil_Anamaria_ProiectMediiContext (DbContextOptions<Coptil_Anamaria_ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<Coptil_Anamaria_ProiectMedii.Types.Game> Game { get; set; }

        public DbSet<Coptil_Anamaria_ProiectMedii.Types.Publisher> Publisher { get; set; }

        public DbSet<Coptil_Anamaria_ProiectMedii.Types.Category> Category { get; set; }
    }
}
