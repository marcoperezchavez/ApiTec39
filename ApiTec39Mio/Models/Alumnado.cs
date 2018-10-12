using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiTec39Mio.Models
{
    public partial class Alumnado
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? Grado { get; set; }
        public int? Grupo { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public int? Taller { get; set; }
        public string Domicilio { get; set; }
        public string NombrePadreTutor { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdMano { get; set; }
        public string Telefono { get; set; }

        public GradoAlumno GradoNavigation { get; set; }
        public GrupoAlumno GrupoNavigation { get; set; }
        public Mano IdManoNavigation { get; set; }
        public StatusAlumno StatusNavigation { get; set; }
        public TallerAlumno TallerNavigation { get; set; }
    }
}
