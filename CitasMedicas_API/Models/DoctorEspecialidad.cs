using System;
using System.Collections.Generic;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class DoctorEspecialidad
    {
        public DoctorEspecialidad()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int IddoctorEspecialidad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
