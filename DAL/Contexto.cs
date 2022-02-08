using Microsoft.EntityFrameworkCore;
using PerlaD_P1_AP1_20190008.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlaD_P1_AP1_20190008.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Aportes> Aportes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\DBPerlaD_P1_AP1_20190008.db");
        }
    }
}
