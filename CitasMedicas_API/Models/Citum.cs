using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class Citum
    {
        public Citum()
        {
            DetalleValorExtras = new HashSet<DetalleValorExtra>();
        }

        public int Idcita { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public decimal CostoInicial { get; set; }
        public decimal? CostoFinal { get; set; }
        public int IdtipoCita { get; set; }
        public int Idusuario { get; set; }
        public int Iddoctor { get; set; }

        public virtual Doctor IddoctorNavigation { get; set; }
        public virtual TipoCitum IdtipoCitaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<DetalleValorExtra> DetalleValorExtras { get; set; }
    }
}
