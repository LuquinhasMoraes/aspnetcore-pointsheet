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
        // Context Carga Horaria
        CargaHorariaContext _context = null;

        public CargaHorariaData(CargaHorariaContext context)
        {
            _context = context;
        }

        public IEnumerable<CargaHoraria> ObtemCargaHoraria()
        {
            var cargaHoraria = _context.CargaHoraria.Where(x => x.Folga == false).OrderByDescending(x => x.DataEntrada).ToList();

            return cargaHoraria;
        }

        public CargaHoraria ObtemCargaHorariaPorId(int idCargaHoraria)
        {
            var cargaHoraria = _context.CargaHoraria.FirstOrDefault(x => x.Folga == false && x.IdCargaHoraria == idCargaHoraria);

            return cargaHoraria;
        }

        public IEnumerable<CargaHoraria> CriaDiaDeFolga()
        {
            try
            {
                CargaHoraria folgaAIniciar = new CargaHoraria().CriaFolga();
                var cargaHoraria = _context.CargaHoraria;
                cargaHoraria.Add(folgaAIniciar);
                _context.SaveChanges();
                return cargaHoraria;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<CargaHoraria> IniciaDiaDeTrabalho()
        {
            try
            {
                var cargaHorariaAIniciar = new CargaHoraria();
#if (DEBUG)
                cargaHorariaAIniciar.DataEntrada = DateTime.Now;
                cargaHorariaAIniciar.InicioJornada = DateTime.Now;
                cargaHorariaAIniciar.Folga = false;
#else
                cargaHorariaAIniciar.DataEntrada = DateTime.Now.AddHours(-3);
                cargaHorariaAIniciar.InicioJornada = DateTime.Now.AddHours(-3);
#endif

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
                var cargaHorariaAIniciar = _context.CargaHoraria.FirstOrDefault(x => x.IdCargaHoraria == idCargaHoraria);

#if (DEBUG)
                cargaHorariaAIniciar.InicioAlmoco = DateTime.Now;
#else
                cargaHorariaAIniciar.InicioAlmoco = DateTime.Now.AddHours(-3);
#endif


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
                
#if (DEBUG)
                cargaHoraria.FimAlmoco = DateTime.Now;
#else
                cargaHoraria.FimAlmoco = DateTime.Now.AddHours(-3);
#endif
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

#if (DEBUG)
                cargaHoraria.FimJornada = DateTime.Now;
#else
                cargaHoraria.FimJornada = DateTime.Now.AddHours(-3);
#endif

                return _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
