using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class Reportes
    {
        public Reportes()
        {
            Alumnado = new HashSet<Alumnado>();
            InfoReportes = new HashSet<InfoReportes>();
        }

        public int Id { get; set; }
        public string TipoDeReporte { get; set; }

        public ICollection<Alumnado> Alumnado { get; set; }
        public ICollection<InfoReportes> InfoReportes { get; set; }
    }
}
