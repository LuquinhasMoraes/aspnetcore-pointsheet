using pointsheet_api.Data.Interfaces;
using pointsheet_api.Models;
using pointsheet_api.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Data
{
    public class CargaHorariaData : ICargaHorariaData
    {
        CargaHorariaContext _context = null;

        public CargaHorariaData(CargaHorariaContext context)
        {
            _context = context;
        }

        public IEnumerable<CargaHoraria> ObtemCargaHoraria()
        {
            return _context.CargaHoraria;
        }
    }
}
