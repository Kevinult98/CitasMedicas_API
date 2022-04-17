using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Cita = new HashSet<Citum>();
        }

        public int Iddoctor { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public int IddoctorEspecialidad { get; set; }

        public virtual DoctorEspecialidad IddoctorEspecialidadNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
