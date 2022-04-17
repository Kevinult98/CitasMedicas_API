using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CitasMedicas_API.Models
{
    public partial class CitasMedicasContext : DbContext
    {
        public CitasMedicasContext()
        {
        }

        public CitasMedicasContext(DbContextOptions<CitasMedicasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; }
        public virtual DbSet<DetallePadecimiento> DetallePadecimientos { get; set; }
        public virtual DbSet<DetalleValorExtra> DetalleValorExtras { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorEspecialidad> DoctorEspecialidads { get; set; }
        public virtual DbSet<InformacionGeneral> InformacionGenerals { get; set; }
        public virtual DbSet<Padecimiento> Padecimientos { get; set; }
        public virtual DbSet<TipoCitum> TipoCita { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }
        public virtual DbSet<ValorExtra> ValorExtras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-7U6LGFC;DATABASE=CitasMedicas; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => e.Idcita)
                    .HasName("PK__Cita__36D350AB60A8093D");

                entity.Property(e => e.Idcita).HasColumnName("IDCita");

                entity.Property(e => e.CostoFinal).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.CostoInicial).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.IdtipoCita).HasColumnName("IDTipoCita");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IddoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Iddoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCita107848");

                entity.HasOne(d => d.IdtipoCitaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdtipoCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCita119614");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCita784178");
            });

            modelBuilder.Entity<DetallePadecimiento>(entity =>
            {
                entity.HasKey(e => e.IddetallePadecimiento)
                    .HasName("PK__DetalleP__4A6D75D15CC19F60");

                entity.ToTable("DetallePadecimiento");

                entity.Property(e => e.IddetallePadecimiento).HasColumnName("IDDetallePadecimiento");

                entity.Property(e => e.Idinformacion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDInformacion");

                entity.Property(e => e.Idpadecimiento).HasColumnName("IDPadecimiento");

                entity.HasOne(d => d.IdinformacionNavigation)
                    .WithMany(p => p.DetallePadecimientos)
                    .HasForeignKey(d => d.Idinformacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetallePad154591");

                entity.HasOne(d => d.IdpadecimientoNavigation)
                    .WithMany(p => p.DetallePadecimientos)
                    .HasForeignKey(d => d.Idpadecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetallePad716926");
            });

            modelBuilder.Entity<DetalleValorExtra>(entity =>
            {
                entity.HasKey(e => e.IddetalleValor)
                    .HasName("PK__DetalleV__443DC101D75CDFB9");

                entity.ToTable("DetalleValorExtra");

                entity.Property(e => e.IddetalleValor).HasColumnName("IDDetalleValor");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Idcita).HasColumnName("IDCita");

                entity.Property(e => e.IdvalorExtra).HasColumnName("IDValorExtra");

                entity.Property(e => e.Precio).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.PrecioFinal).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdcitaNavigation)
                    .WithMany(p => p.DetalleValorExtras)
                    .HasForeignKey(d => d.Idcita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetalleVal849441");

                entity.HasOne(d => d.IdvalorExtraNavigation)
                    .WithMany(p => p.DetalleValorExtras)
                    .HasForeignKey(d => d.IdvalorExtra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetalleVal775417");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Iddoctor)
                    .HasName("PK__Doctor__A4F7F9ECD72FA7AA");

                entity.ToTable("Doctor");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IddoctorEspecialidad).HasColumnName("IDDoctorEspecialidad");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddoctorEspecialidadNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IddoctorEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDoctor22919");
            });

            modelBuilder.Entity<DoctorEspecialidad>(entity =>
            {
                entity.HasKey(e => e.IddoctorEspecialidad)
                    .HasName("PK__DoctorEs__395D493DCA1CB63D");

                entity.ToTable("DoctorEspecialidad");

                entity.Property(e => e.IddoctorEspecialidad).HasColumnName("IDDoctorEspecialidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InformacionGeneral>(entity =>
            {
                entity.HasKey(e => e.Idinformacion)
                    .HasName("PK__Informac__BED0A9E13F261B94");

                entity.ToTable("InformacionGeneral");

                entity.Property(e => e.Idinformacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDInformacion");

                entity.Property(e => e.Altura)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSangre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.InformacionGenerals)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInformacio454906");
            });

            modelBuilder.Entity<Padecimiento>(entity =>
            {
                entity.HasKey(e => e.Idpadecimiento)
                    .HasName("PK__Padecimi__B218BC6558F4FD1D");

                entity.ToTable("Padecimiento");

                entity.Property(e => e.Idpadecimiento).HasColumnName("IDPadecimiento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCitum>(entity =>
            {
                entity.HasKey(e => e.IdtipoCita)
                    .HasName("PK__TipoCita__56B987A184EF2E7D");

                entity.Property(e => e.IdtipoCita).HasColumnName("IDTipoCita");

                entity.Property(e => e.Costo).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__52311169145A1345");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecuperacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasennia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdusuarioRol).HasColumnName("IDUsuarioRol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdusuarioRol)
                    .HasConstraintName("FKUsuario119109");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => e.IdusuarioRol)
                    .HasName("PK__UsuarioR__3A284C8036CD6B07");

                entity.ToTable("UsuarioRol");

                entity.Property(e => e.IdusuarioRol).HasColumnName("IDUsuarioRol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValorExtra>(entity =>
            {
                entity.HasKey(e => e.IdvalorExtra)
                    .HasName("PK__ValorExt__486374FE9B3FA321");

                entity.ToTable("ValorExtra");

                entity.Property(e => e.IdvalorExtra).HasColumnName("IDValorExtra");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(11, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
