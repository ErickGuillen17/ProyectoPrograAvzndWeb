using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class WorknetContext : DbContext
    {
        public WorknetContext()
        {
        }

        public WorknetContext(DbContextOptions<WorknetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacora { get; set; } = null!;
        public virtual DbSet<Candidato> Candidato { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Empleo> Empleo { get; set; } = null!;
        public virtual DbSet<Reclutador> Reclutador { get; set; } = null!;
        public virtual DbSet<Rol> Rol { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicitud { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;
        public virtual DbSet<SP_Llenar_Empleos_Result> SP_Llenar_Empleos_Result { get; set; } = null!;
        public virtual DbSet<SP_Buscar_Usuario_Result> SP_Buscar_Usuario_Result { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KJ83GJT\\SQLEXPRESS;Database=Worknet;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.Consecutivo);

                entity.ToTable("BITACORA");

                entity.Property(e => e.Consecutivo).HasColumnName("CONSECUTIVO");

                entity.Property(e => e.CodigoError).HasColumnName("CODIGO_ERROR");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_USUARIO");

                entity.Property(e => e.DescripcionError)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_ERROR");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_HORA");

                entity.Property(e => e.Origen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ORIGEN");

                entity.HasOne(d => d.CorreoUsuarioNavigation)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.CorreoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BITACORA_USUARIOS");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.CorreoUsuario)
                    .HasName("PK_CANDIDATOS");

                entity.ToTable("CANDIDATO");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_USUARIO");

                entity.Property(e => e.ApellidoCandidato)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_CANDIDATO");

                entity.Property(e => e.AreaInteres).HasColumnName("AREA_INTERES");

                entity.Property(e => e.ExpCandidato).HasColumnName("EXP_CANDIDATO");

                entity.Property(e => e.GradoEstudio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GRADO_ESTUDIO");

                entity.Property(e => e.NombreCandidato)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CANDIDATO");

                entity.Property(e => e.TelefonoCandidato).HasColumnName("TELEFONO_CANDIDATO");

                entity.HasOne(d => d.AreaInteresNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.AreaInteres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANDIDATOS_CATEGORIAS");

                entity.HasOne(d => d.CorreoUsuarioNavigation)
                    .WithOne(p => p.Candidato)
                    .HasForeignKey<Candidato>(d => d.CorreoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_8");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("XPKCATEGORIAS")
                    .IsClustered(false);

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.CategoriaDescripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIA_DESCRIPCION");
            });

            modelBuilder.Entity<Empleo>(entity =>
            {
                entity.HasKey(e => e.IdEmpleo)
                    .HasName("XPKEMPLEOS")
                    .IsClustered(false);

                entity.ToTable("EMPLEO");

                entity.Property(e => e.IdEmpleo).HasColumnName("ID_EMPLEO");

                entity.Property(e => e.Compania)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPANIA");

                entity.Property(e => e.CorreoReclutador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_RECLUTADOR");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.EmpleoNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMPLEO_NOMBRE");

                entity.Property(e => e.EstadoPuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO_PUESTO");

                entity.Property(e => e.ExpMinima).HasColumnName("EXP_MINIMA");

                entity.Property(e => e.GradoEstudio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRADO_ESTUDIO");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.Requisitos)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("REQUISITOS");

                entity.HasOne(d => d.CorreoReclutadorNavigation)
                    .WithMany(p => p.Empleo)
                    .HasForeignKey(d => d.CorreoReclutador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEOS_RECLUTADORES");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Empleo)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEOS_CATEGORIAS");
            });

            modelBuilder.Entity<Reclutador>(entity =>
            {
                entity.HasKey(e => e.CorreoReclutador)
                    .HasName("PK_RECLUTADORESS");

                entity.ToTable("RECLUTADOR");

                entity.Property(e => e.CorreoReclutador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_RECLUTADOR");

                entity.Property(e => e.ApellidoReclutador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO_RECLUTADOR");

                entity.Property(e => e.Compania)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPANIA");

                entity.Property(e => e.NombreReclutador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_RECLUTADOR");

                entity.Property(e => e.TelefonoReclutador).HasColumnName("TELEFONO_RECLUTADOR");

                entity.HasOne(d => d.CorreoReclutadorNavigation)
                    .WithOne(p => p.Reclutador)
                    .HasForeignKey<Reclutador>(d => d.CorreoReclutador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECLUTADORES_USUARIOS");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("XPKROLES")
                    .IsClustered(false);

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ROL");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("XPKSOLICITUDES");

                entity.ToTable("SOLICITUD");

                entity.Property(e => e.IdSolicitud).HasColumnName("ID_SOLICITUD");

                entity.Property(e => e.CorreoCandidato)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_CANDIDATO");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_SOLICITUD");

                entity.Property(e => e.IdEmpleo).HasColumnName("ID_EMPLEO");

                entity.HasOne(d => d.CorreoCandidatoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.CorreoCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOLICITUDES_CANDIDATOS");

                entity.HasOne(d => d.IdEmpleoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdEmpleo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_6");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CorreoUsuario)
                    .HasName("XPKUSUARIOS");

                entity.ToTable("USUARIO");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO_USUARIO");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
