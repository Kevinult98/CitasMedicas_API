using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class Padecimiento
    {
        public Padecimiento()
        {
            DetallePadecimientos = new HashSet<DetallePadecimiento>();
        }

        public int Idpadecimiento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DetallePadecimiento> DetallePadecimientos { get; set; }
    }
}
