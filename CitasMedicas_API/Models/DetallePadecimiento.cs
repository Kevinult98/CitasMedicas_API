using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class DetallePadecimiento
    {
        public int IddetallePadecimiento { get; set; }
        public string Idinformacion { get; set; }
        public int Idpadecimiento { get; set; }

        public virtual InformacionGeneral IdinformacionNavigation { get; set; }
        public virtual Padecimiento IdpadecimientoNavigation { get; set; }
    }
}
