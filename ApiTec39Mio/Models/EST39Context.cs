using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiTec39Mio.Models
{
    public partial class EST39Context : DbContext
    {
        public EST39Context()
        {
        }

        public EST39Context(DbContextOptions<EST39Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnado> Alumnado { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<GradoAlumno> GradoAlumno { get; set; }
        public virtual DbSet<GrupoAlumno> GrupoAlumno { get; set; }
        public virtual DbSet<InfoReportes> InfoReportes { get; set; }
        public virtual DbSet<Mano> Mano { get; set; }
        public virtual DbSet<RegistroUsuario> RegistroUsuario { get; set; }
        public virtual DbSet<Reportes> Reportes { get; set; }
        public virtual DbSet<StatusAlumno> StatusAlumno { get; set; }
        public virtual DbSet<TallerAlumno> TallerAlumno { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E1PQI4V\\SQLEXPRESS;Database=EST39;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnado>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio).HasMaxLength(200);

                entity.Property(e => e.FechaDeIngreso).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePadreTutor).HasMaxLength(200);

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany(p => p.Alumnado)
                    .HasForeignKey(d => d.Grado)
                    .HasConstraintName("FK__Alumnado__Grado__5DCAEF64");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Alumnado)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("FK__Alumnado__Grupo__5EBF139D");

                entity.HasOne(d => d.ReportesNavigation)
                    .WithMany(p => p.Alumnado)
                    .HasForeignKey(d => d.Reportes)
                    .HasConstraintName("FK__Alumnado__Report__5BE2A6F2");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Alumnado)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Alumnado__Taller__5AEE82B9");

                entity.HasOne(d => d.TallerNavigation)
                    .WithMany(p => p.Alumnado)
                    .HasForeignKey(d => d.Taller)
                    .HasConstraintName("FK__Alumnado__Taller__5CD6CB2B");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrupoAlumno>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InfoReportes>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

          
            });

            modelBuilder.Entity<Mano>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<RegistroUsuario>(entity =>
            {
                entity.Property(e => e.FechaDeSesion)
                    .HasColumnName("fechaDeSesion")
                    .HasColumnType("datetime");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reportes>(entity =>
            {
                entity.Property(e => e.TipoDeReporte)
                    .IsRequired()
                    .HasColumnName("tipoDeReporte")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusAlumno>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TallerAlumno>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumentos>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
