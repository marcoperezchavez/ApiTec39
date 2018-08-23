using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class TallerAlumno
    {
        public TallerAlumno()
        {
            Alumnado = new HashSet<Alumnado>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Alumnado> Alumnado { get; set; }
    }
}
