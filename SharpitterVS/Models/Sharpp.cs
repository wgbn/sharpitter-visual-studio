namespace SharpitterVS.Models
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wgbnc837_sharpitter.Sharpp")]
    public partial class Sharpp {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        [Required]
        [StringLength(160)]
        public string Texto { get; set; }

        public DateTime Registro { get; set; }

        public int Like { get; set; }

        public int? Resposta { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [NotMapped]
        public Usuario Usuario {
            get {
                UsuarioService usr = new UsuarioService();
                return usr.GetPorId(this.UsuarioId);
            }
        }

        public bool Save() {
            SharppService usr = new SharppService();
            usr.PostSharpp(this);
            return true;
        }

        public String TempoDecorrido() {
            DateTime agora = DateTime.Now;
            TimeSpan ts = agora - this.Registro;

            int diffEmDias = ts.Days;
            int diffEmHoras = ts.Hours;
            int diffEmMins = ts.Minutes;
            int diffEmSecs = ts.Seconds;

            string tempo = "há " + diffEmDias.ToString() + " dias";

            if (diffEmDias == 0)
                if (diffEmHoras == 0)
                    if (diffEmMins == 0)
                        if (diffEmSecs == 0)
                            tempo = "agora mesmo";
                        else
                            tempo = "há " + diffEmSecs.ToString() + " segundos";
                        else
                            tempo = "há " + diffEmMins.ToString() + " minutos";
                    else
                        tempo = "há " + diffEmHoras.ToString() + " horas";

            return tempo;
        }
    }
}
