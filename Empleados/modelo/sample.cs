using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Empleados
{
    public class EmpleadosContext : DbContext
    {

        public EmpleadosContext()
            : base("name=Empleados.Properties.Settings.EmpleadosContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<EmpleadoInterno> EmpleadosInternos { get; set; }
        public DbSet<EmpleadoExterno> EmpleadosExternos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonaMap());

            modelBuilder.Configurations.Add(new EmpleadoInternoMap());

            modelBuilder.Configurations.Add(new EmpleadoExternoMap());

            base.OnModelCreating(modelBuilder);
        }

        public EmpleadoInterno AddEmpleadoInterno(Persona Persona)
        {

            SqlConnection sqlConn = new SqlConnection(Empleados.Properties.Settings.Default.EmpleadosContext);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "spEmpleadoInterno_Add";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PersonaId",Persona.PersonaId));
            cmd.Connection = sqlConn;
            sqlConn.Open();
            cmd.ExecuteNonQuery();
            sqlConn.Close();

            using (var db = new EmpleadosContext())
            {
                 return db.EmpleadosInternos.Single(x => x.PersonaId == Persona.PersonaId);
            }

        }

    }

    [Table("dbo.Personas")]
    public class Persona
    {
        [Key]
        [StringLength(10)]
        [Column("PersonaId")]
        public string PersonaId { get; set; }

        [Column("Nombre")]
        [StringLength(10)]
        public string Nombre { get; set; }

        [Column("Apellido")]
        [StringLength(20)]
        public string Apellido { get; set; }
    }

    [Table("dbo.EmpleadosInternos")]
    public class EmpleadoInterno : Persona
    {
        [Column("Nomina")]
        [StringLength(10)]
        public string Nomina { get; set; }
    }

    [Table("dbo.EmpleadosExternos")]
    public class EmpleadoExterno : Persona
    {
        [Column("NombreEmpresa")]
        [StringLength(10)]
        public string NombreEmpresa { get; set; }
    }

    public class PersonaMap : EntityTypeConfiguration<Persona>
    {
        public PersonaMap()
        {
            HasKey(x => x.PersonaId);
            Property(x => x.Nombre).HasMaxLength(20).IsRequired();
            Property(x => x.Apellido).HasMaxLength(10).IsRequired();
        }
    }

    public class EmpleadoInternoMap : EntityTypeConfiguration<EmpleadoInterno>
    {
        public EmpleadoInternoMap()
        {
            HasKey(x => x.PersonaId);
            ToTable("dbo.EmpleadosInternos");
        }
    }

    public class EmpleadoExternoMap : EntityTypeConfiguration<EmpleadoExterno>
    {
        public EmpleadoExternoMap()
        {
            HasKey(x => x.PersonaId);
            ToTable("dbo.EmpleadosExternos");
        }
    }
}