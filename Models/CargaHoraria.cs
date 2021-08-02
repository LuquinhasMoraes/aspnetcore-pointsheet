using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Models
{
    public class CargaHoraria
    {
        [Key]
        public int? IdCargaHoraria { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime InicioJornada { get; set; }
        public DateTime InicioAlmoco { get; set; }
        public DateTime FimAlmoco { get; set; }
        public DateTime FimJornada { get; set; }
        public decimal HorasTrabalhadas { get; set; }
        public bool Folga { get; set; }
    }
}
