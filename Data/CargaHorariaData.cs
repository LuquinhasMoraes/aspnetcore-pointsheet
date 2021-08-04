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
            var cargaHoraria = _context.CargaHoraria;

            return cargaHoraria;
        }

        public IEnumerable<CargaHoraria> IniciaDiaDeTrabalho()
        {
            try
            {
                var cargaHorariaAIniciar = new CargaHoraria();
                cargaHorariaAIniciar.DataEntrada = DateTime.Now.AddHours(-3);
                cargaHorariaAIniciar.InicioJornada = DateTime.Now.AddHours(-3);
                var cargaHoraria = _context.CargaHoraria;
                cargaHoraria.Add(cargaHorariaAIniciar);
                _context.SaveChanges();
                return cargaHoraria;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int IniciaAlmoco(int idCargaHoraria)
        {
            try
            {
                var cargaHoraria = _context.CargaHoraria.FirstOrDefault(x => x.IdCargaHoraria == idCargaHoraria);
                cargaHoraria.InicioAlmoco = DateTime.Now.AddHours(-3); ;
                return _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EncerraAlmoco(int idCargaHoraria)
        {
            try
            {
                var cargaHoraria = _context.CargaHoraria.FirstOrDefault(x => x.IdCargaHoraria == idCargaHoraria);
                cargaHoraria.FimAlmoco = DateTime.Now.AddHours(-3); ;
                return _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EncerraJornada(int idCargaHoraria)
        {
            try
            {
                var cargaHoraria = _context.CargaHoraria.FirstOrDefault(x => x.IdCargaHoraria == idCargaHoraria);
                cargaHoraria.FimJornada = DateTime.Now.AddHours(-3); ;
                return _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
