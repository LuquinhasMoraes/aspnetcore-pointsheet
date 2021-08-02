using Microsoft.AspNetCore.Mvc;
using pointsheet_api.Data;
using pointsheet_api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Controllers
{
    [Route("CargaHoraria")]
    public class CargaHorariaController : Controller
    {
        ICargaHorariaData _cargaHorariaData;

        public CargaHorariaController(ICargaHorariaData cargaHorariaData)
        {
            _cargaHorariaData = cargaHorariaData;
        }
        public IActionResult Index()
        {
            var data = _cargaHorariaData.ObtemCargaHoraria();

            return Ok(data);
        }
    }
}
