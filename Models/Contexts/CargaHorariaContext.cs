using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Models.Contexts
{
    public class CargaHorariaContext : DbContext
    {
        public CargaHorariaContext(DbContextOptions<CargaHorariaContext> options) : base(options) { }
        public DbSet<CargaHoraria> CargaHoraria { get; set; }
    }
}
