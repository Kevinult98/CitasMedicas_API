using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class ValorExtra
    {
        public ValorExtra()
        {
            DetalleValorExtras = new HashSet<DetalleValorExtra>();
        }

        public int IdvalorExtra { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<DetalleValorExtra> DetalleValorExtras { get; set; }
    }
}
