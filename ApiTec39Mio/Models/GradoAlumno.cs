using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class GradoAlumno
    {
        public GradoAlumno()
        {
            Alumnado = new HashSet<Alumnado>();
        }

        public int Id { get; set; }
        public int? Descripcion { get; set; }

        public ICollection<Alumnado> Alumnado { get; set; }
    }
}
