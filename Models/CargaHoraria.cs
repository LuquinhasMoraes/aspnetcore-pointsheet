using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pointsheet_api.Models
{
    public class CargaHoraria
    {
        decimal _diferencaHorasTrabalhadas = 0;
        decimal _horasTrabalhadas = 0;
        decimal? _tempoDeAlmoco = 0;

        [Key]
        public int? IdCargaHoraria { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime InicioJornada { get; set; }
        [NotMapped]
        public TimeSpan InicioJornadaTime
        {
            get
            {
                var tempo = InicioJornada;
                //decimal TempoDeAlmoco = Convert.ToDecimal(tempo.TotalHours);
                return new TimeSpan(tempo.Ticks);
                //return Math.Round(TempoDeAlmoco, 2);
            }
            set
            {


            }
        }
        [NotMapped]
        public TimeSpan FimJornadaTime { get; set; }
        public DateTime InicioAlmoco { get; set; }
        public DateTime FimAlmoco { get; set; }
        public DateTime FimJornada { get; set; }
        //[NotMapped]
        [NotMapped]
        public TimeSpan? TempoDeAlmoco {
            get
            {
                var tempo = FimAlmoco - InicioAlmoco;
                //decimal TempoDeAlmoco = Convert.ToDecimal(tempo.TotalHours);
                return tempo;
                //return Math.Round(TempoDeAlmoco, 2);
            }
            set
            {


            }
        }
        //[NotMapped]
        [JsonIgnore]
        public bool? Folga { get; set; }
        [NotMapped]
        public decimal DiferencaHorasTrabalhadas { 
            get 
            {
                decimal horarioBase = 8;
                decimal diff = 0;

                if (Folga == false)
                {
                    diff = (decimal)HorasTrabalhadas - horarioBase;
                }

                _diferencaHorasTrabalhadas = diff;
                
                return Math.Round(_diferencaHorasTrabalhadas, 2);
            } 
            set
            {
                

            } 
        }

        [NotMapped]
        public decimal? HorasTrabalhadas { 
            get 
            {
                if(Folga == false)
                {
                    var totalHoras = FimJornada - InicioJornada - (FimAlmoco - InicioAlmoco);

                    var t = Convert.ToDecimal(totalHoras.TotalHours < 0 ? 0 : totalHoras.TotalHours);

                    return Math.Round(t, 2);
                }

                return null;
                
            }
            set 
            {
                
            }
        }

        public CargaHoraria CriaFolga()
        {
            CargaHoraria folga = new CargaHoraria();
            folga.DataEntrada = DateTime.Now.ToLocalTime();
            folga.Folga = true;

            return folga;
        }
        
    }
}
