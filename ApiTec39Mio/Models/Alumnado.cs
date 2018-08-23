using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class Alumnado
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public int? Reportes { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Grado { get; set; }
        public int? Grupo { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public int? Taller { get; set; }
        public string Domicilio { get; set; }
        public string NombrePadreTutor { get; set; }

        public GradoAlumno GradoNavigation { get; set; }
        public GrupoAlumno GrupoNavigation { get; set; }
        public Reportes ReportesNavigation { get; set; }
        public StatusAlumno StatusNavigation { get; set; }
        public TallerAlumno TallerNavigation { get; set; }
    }
}
