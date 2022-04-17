using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class TipoCitum
    {
        public TipoCitum()
        {
            Cita = new HashSet<Citum>();
        }

        public int IdtipoCita { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
    }
}
