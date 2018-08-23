﻿using System;
using System.Collections.Generic;
using System.Linq;
using ApiTec39Mio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTec39Mio.Methods
{
    public static class Helpers
    {
        static EST39Context _context = new EST39Context();
        static List<AlumnadoGnl> alumandoList = new List<AlumnadoGnl>();
        private static List<InfoReportesGnl> reportesList = new List<InfoReportesGnl>();
           
        internal static IEnumerable<AlumnadoGnl> GetAlumnosList()
        {
            var alumnos = _context.Alumnado.ToList();
            var alumnadoMapping = Mapping(alumnos);
            return alumnadoMapping;
        }

        internal static AlumnadoGnl GetAlumno(int id)
        {
            var alumno = _context.Alumnado.Where(x => x.Id == id).FirstOrDefault();
            if (alumno is null)
                return null;
            var alumnoMapping = MappingAlumno(alumno);
            return alumnoMapping;
        }

        internal static InfoReportesGnl GetAlumnoId(int id)
        {
            var reporte = _context.InfoReportes.Where(x => x.Id == id).FirstOrDefault();
            if (reporte is null)
                return null;
            var reporteMapping = MappingReporteId(reporte);  
            return reporteMapping;
        }

        private static InfoReportesGnl MappingReporteId(InfoReportes reporte)
        {
            InfoReportesGnl reporteGnl = new InfoReportesGnl()
            {
                Id = reporte.Id,
                IdAlumno = reporte.IdAlumno,
                IdReporte = reporte.IdReporte,
                Description = reporte.Description,
                CreationDate = reporte.CreationDate,
                TotalDays = reporte.TotalDays,
                NombreReporte = GetNombreReporte(reporte.Id)
            };
            return reporteGnl;
        }

      
    

        internal static IEnumerable<InfoReportesGnl> GetReportesList()
        {
            var reportes = _context.InfoReportes.ToList();
            var reportesMapping = Mapping(reportes);
            return reportesMapping;
        }

        private static IEnumerable<InfoReportesGnl> Mapping(List<InfoReportes> reportes)
        {
            foreach (var reporte in reportes)
            {
                InfoReportesGnl repos = new InfoReportesGnl()
                {
                    Id = reporte.Id,
                    IdAlumno = reporte.IdAlumno,
                    Description = reporte.Description,
                    CreationDate = reporte.CreationDate,
                    NombreReporte = GetNombreReporte(reporte.IdReporte),
                    IdReporte = reporte.IdReporte,
                    TotalDays = reporte.TotalDays
                };
                    reportesList.Add(repos);   
            }               
            return reportesList;
        }

        private static string GetNombreReporte(int idReporte)
        {
            var nombre = idReporte.ToString() == "1" ? "Citatorio"
                : idReporte.ToString() == "2" ? "Reporte"
                    : idReporte.ToString() == "3" ? "Justificante"
                       : string.Empty;
            return nombre;
        }

        internal static bool SaveAlumno(AlumnadoGnl alumno)
        {
            try
            {
                var alumnoDB = mappingAlumnoDB(alumno);
                _context.Alumnado.Add(alumnoDB);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        internal static bool DeleteId(int id)
        {
            var alumno = _context.Alumnado.Where(x => x.Id == id).FirstOrDefault();
            if (alumno is null)
                return false;
            _context.Entry(alumno).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        internal static bool UpdateAlumno(int id, AlumnadoGnl alumno)
        {
            try
            {
                var alumnoDB = mappingAlumnoDB(alumno);
                alumnoDB.Id = id;
                _context.Entry(alumnoDB).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        private static List<AlumnadoGnl> Mapping(List<Alumnado> alumnos)
        {
            foreach (var alumno in alumnos)
            {
                AlumnadoGnl alum = new AlumnadoGnl()
                {
                    Id = alumno.Id,
                    Nombre = alumno.Nombre,
                    ApellidoPaterno = alumno.ApellidoPaterno,
                    ApellidoMaterno = alumno.ApellidoMaterno,
                    FechaDeIngreso = alumno.FechaDeIngreso,
                    Taller = GetTaller(alumno.Taller),
                    Status = GetStatus(alumno.Status),
                    Grado = alumno.Grado,
                    Grupo = GetGrupo(alumno.Grupo),
                    Reportes = GetReportes(alumno.Reportes)    
                };
                alumandoList.Add(alum);
            }                   
            return alumandoList;
        }
                                                                          
        private static Alumnado mappingAlumnoDB(AlumnadoGnl alumno)
        {
            Alumnado al = new Alumnado()
            {   
                Nombre = alumno.Nombre,
                ApellidoPaterno = alumno.ApellidoPaterno,
                ApellidoMaterno = alumno.ApellidoMaterno,
                FechaDeIngreso = alumno.FechaDeIngreso,
                Taller = GetTallerDB(alumno.Taller),
                Status = GetStatusDB(alumno.Status),
                Grado = alumno.Grado,
                Grupo = GetGrupoDB(alumno.Grupo),
                Reportes = GetReportesDB(alumno.Reportes) 
            };

            return al;
        }

        private static AlumnadoGnl MappingAlumno(Alumnado alumno)
        {
            AlumnadoGnl alum = new AlumnadoGnl()
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                ApellidoPaterno = alumno.ApellidoPaterno,
                ApellidoMaterno = alumno.ApellidoMaterno,
                FechaDeIngreso = alumno.FechaDeIngreso,
                Taller = GetTaller(alumno.Taller),
                Status = GetStatus(alumno.Status),
                Grado = alumno.Grado,
                Grupo = GetGrupo(alumno.Grupo),
                Reportes = GetReportes(alumno.Reportes)
            };
            return alum;
        }

        private static int GetReportesDB(string reportes)
        {
            return _context.Reportes.Where(x => x.TipoDeReporte == reportes).Select(x => x.Id).FirstOrDefault();
        }

        private static int GetGrupoDB(string grupo)
        {
            return _context.GrupoAlumno.Where(x => x.Descripcion == grupo).Select(x => x.Id).FirstOrDefault();
        }

        private static int GetStatusDB(string status)
        {
            return _context.StatusAlumno.Where(x => x.Descripcion == status).Select(x => x.Id).FirstOrDefault();
        }

        private static int GetTallerDB(string taller)
        {

            return _context.TallerAlumno.Where(x => x.Descripcion == taller).Select(x => x.Id).FirstOrDefault();
            
        }      

        private static string GetReportes(int? reportes)
        {
            return _context.Reportes.Find(reportes).TipoDeReporte;
        }

        private static string GetGrupo(int? grupo)
        {
            return _context.GrupoAlumno.Find(grupo).Descripcion;
        }

        private static string GetStatus(int? status)
        {
            return _context.StatusAlumno.Find(status).Descripcion;
        }

        private static string GetTaller(int? taller)
        {
            return _context.TallerAlumno.Find(taller).Descripcion;    
        }
    }
}
