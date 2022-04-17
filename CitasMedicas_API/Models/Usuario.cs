using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cita = new HashSet<Citum>();
            InformacionGenerals = new HashSet<InformacionGeneral>();
        }

        public int Idusuario { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CodigoRecuperacion { get; set; }
        public string Contrasennia { get; set; }
        public bool Activo { get; set; }
        public int? IdusuarioRol { get; set; }

        public virtual UsuarioRol IdusuarioRolNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<InformacionGeneral> InformacionGenerals { get; set; }
    }
}
