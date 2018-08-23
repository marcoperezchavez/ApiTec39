using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTec39Mio.Models
{
    public class InfoReportesGnl
    {  
            public int Id { get; set; }
            public int IdAlumno { get; set; }
            public int IdReporte { get; set; }
            public string NombreReporte { get; set; }
            public string Description { get; set; }
            public DateTime? CreationDate { get; set; }
            public int? TotalDays { get; set; }
                                                               

    }
}
