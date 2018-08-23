using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class Reportes
    {
        public Reportes()
        {
            Alumnado = new HashSet<Alumnado>();
        }

        public int Id { get; set; }
        public string TipoDeReporte { get; set; }

        public ICollection<Alumnado> Alumnado { get; set; }
    }
}
