using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class UsuarioRol
    {
        public UsuarioRol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdusuarioRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
