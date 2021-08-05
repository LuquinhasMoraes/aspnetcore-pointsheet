using Microsoft.AspNetCore.Mvc;
using pointsheet_api.Data;
using pointsheet_api.Data.Interfaces;
using pointsheet_api.Models;
using pointsheet_api.Models.Enums;
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

        [HttpPost]
        [Route("Iniciar")]
        public IActionResult IniciarCargaHoraria()
        {
            try
            {
                var cargaHorariaInserida = _cargaHorariaData.IniciaDiaDeTrabalho();
                return Ok(cargaHorariaInserida);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("CriaFolga")]
        public IActionResult CriaFolga()
        {
            try
            {
                var cargaHorariaInserida = _cargaHorariaData.CriaDiaDeFolga();
                return Ok(cargaHorariaInserida);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPut]
        [Route("Atualiza")]
        public IActionResult Teste(int idCargaHoraria, ETipoAtualizacao tipoAtualizacao)
        {
            try
            {
                object response = null;

                if(tipoAtualizacao == ETipoAtualizacao.InicioAlmoco)
                {
                    response = _cargaHorariaData.IniciaAlmoco(idCargaHoraria);
                }
                else if(tipoAtualizacao == ETipoAtualizacao.FimAlmoco)
                {
                    response = _cargaHorariaData.EncerraAlmoco(idCargaHoraria);
                }
                else
                {
                    response = _cargaHorariaData.EncerraJornada(idCargaHoraria);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

public class Teste
{
    public int? Id { get; set; }
    public DateTime Foo { get; set; }
    public bool Folga { get; set; }
}
