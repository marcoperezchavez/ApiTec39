using System;
using System.Collections.Generic;

namespace ApiTec39Mio.Models
{
    public partial class RegistroUsuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaDeSesion { get; set; }
    }
}
