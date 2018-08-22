﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTec39Mio.Models
{
    public class AlumnadoGnl
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Reportes { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Grado { get; set; }

        public string Grupo { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public string Taller { get; set; }
    }
}