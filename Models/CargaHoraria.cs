using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Models
{
    public class CargaHoraria
    {
        decimal _diferencaHorasTrabalhadas = 0;
        decimal _horasTrabalhadas = 0;

        [Key]
        public int? IdCargaHoraria { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime InicioJornada { get; set; }
        public DateTime InicioAlmoco { get; set; }
        public DateTime FimAlmoco { get; set; }
        public DateTime FimJornada { get; set; }
        public bool Folga { get; set; }
        [NotMapped]
        public decimal DiferencaHorasTrabalhadas { 
            get 
            {
                decimal horarioBase = 8;

                decimal diff = HorasTrabalhadas - horarioBase;

                _diferencaHorasTrabalhadas = diff;
                
                return Math.Round(_diferencaHorasTrabalhadas, 2);
            } 
            set
            {
                

            } 
        }

        [NotMapped]
        public decimal HorasTrabalhadas { 
            get 
            {
                var totalHoras = FimJornada - InicioJornada - (FimAlmoco - InicioAlmoco);

                var t = Convert.ToDecimal(totalHoras.TotalHours < 0 ? 0 : totalHoras.TotalHours);

                return Math.Round(t, 2);
            }
            set 
            {
                
            }
        }

        public CargaHoraria CriaFolga()
        {
            CargaHoraria folga = new CargaHoraria();
            folga.DataEntrada = DateTime.Now.AddHours(-3);
            folga.Folga = true;

            return folga;
        }
        
    }
}
