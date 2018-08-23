using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class InfoReportes
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdReporte { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TotalDays { get; set; }

        public Alumnado IdAlumnoNavigation { get; set; }
        public Reportes IdReporteNavigation { get; set; }
    }
}
