using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class DetalleValorExtra
    {
        public int IddetalleValor { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
        public int Idcita { get; set; }
        public int IdvalorExtra { get; set; }

        public virtual Citum IdcitaNavigation { get; set; }
        public virtual ValorExtra IdvalorExtraNavigation { get; set; }
    }
}
