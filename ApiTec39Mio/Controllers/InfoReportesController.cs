using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTec39Mio.Models;

namespace ApiTec39Mio.Controllers
{
    [Route("api/[controller]")]
    public class InfoReportesController : Controller
    {
      

        // GET: api/InfoReportes
        [HttpGet]
        public IEnumerable<InfoReportesGnl> GetInfoReportes()
        {
            var reportsList = Methods.Helpers.GetReportesList();
            return reportsList;          
        }

        // GET: api/InfoReportes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoReportes([FromRoute] int id)
        {
            var reporte = Methods.Helpers.GetAlumnoId(id);
            if (reporte is null)
                return NotFound();
            return Ok(reporte); 
        }

        // PUT: api/InfoReportes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoReportes([FromRoute] int id, [FromBody] InfoReportes infoReportes)
        {
            return null;
        }

        // POST: api/InfoReportes
        [HttpPost]
        public async Task<IActionResult> PostInfoReportes([FromBody] InfoReportes infoReportes)
        {
            return null;
        }

        // DELETE: api/InfoReportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoReportes([FromRoute] int id)
        {
            return null;
        }

        private bool InfoReportesExists(int id)
        {
            return true;
        }
    }
}