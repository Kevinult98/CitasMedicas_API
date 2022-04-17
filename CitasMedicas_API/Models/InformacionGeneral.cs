using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class InformacionGeneral
    {
        public InformacionGeneral()
        {
            DetallePadecimientos = new HashSet<DetallePadecimiento>();
        }

        public string Idinformacion { get; set; }
        public string TipoSangre { get; set; }
        public string Genero { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string Edad { get; set; }
        public int Idusuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<DetallePadecimiento> DetallePadecimientos { get; set; }
    }
}
