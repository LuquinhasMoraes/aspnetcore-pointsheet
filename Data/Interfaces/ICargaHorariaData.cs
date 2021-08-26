using pointsheet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Data.Interfaces
{
    public interface ICargaHorariaData
    {
        IEnumerable<CargaHoraria> ObtemCargaHoraria();
        IEnumerable<CargaHoraria> IniciaDiaDeTrabalho();
        int IniciaAlmoco(int idCargaHoraria);
        int EncerraAlmoco(int idCargaHoraria);
        int EncerraJornada(int idCargaHoraria);
        IEnumerable<CargaHoraria> CriaDiaDeFolga();
        CargaHoraria ObtemCargaHorariaPorId(int idCargaHoraria);
    }
}
