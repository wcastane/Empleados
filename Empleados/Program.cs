using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Items;

using System.Data;
using System.Data.SqlClient;

namespace Empleados
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using(SqlConnection sqlConn = new SqlConnection(@"data source=.\SRV2008R2;initial catalog=Test;integrated security=True;"))
            {
                sqlConn.Open();

                sqlConn.Close();
            }


            //using (var db = new EmpleadosContext())
            //{
            //    //Persona p = new Persona() { PersonaId = "1", Nombre = "Pedro", Apellido = "Fernandez" };
            //    //EmpleadoInterno ei = new EmpleadoInterno() { PersonaId = "2", Nombre = "Paco", Apellido = "stanley", Nomina = "100" };
            //    //EmpleadoExterno ee = new EmpleadoExterno() { PersonaId = "3", Nombre = "Pablo", Apellido = "Solis", NombreEmpresa = "Consultor" };

            //    //db.Personas.Add(p);
            //    //db.EmpleadosInternos.Add(ei);
            //    //db.EmpleadosExternos.Add(ee);

            //    //db.SaveChanges();

            //    //EmpleadoInterno new_ei = new EmpleadoInterno() { PersonaId = p.PersonaId, Nombre = p.Nombre, Apellido = p.Apellido, Nomina = "1010" };
            //    //db.Entry(new_ei).State = System.Data.Entity.EntityState.;

            //    //EmpleadoInterno new_ei = db.AddEmpleadoInterno(p);
            //    //new_ei.Nomina = "1010";

            //    db.SaveChanges();
            //}

            //using (var db = new Items.ItemsContext())
            //{
            //    //Sistema sis1 = new Sistema() { ItemId = "A", Description = "AA", Grupo = "GA" };
            //    //Componente B = new Componente() { ItemId = "B", Description = "BB", Grupo = "GB", Orden = 1, Capacidad = 12, Cantidad = 1 };
            //    //sis1.Componentes.Add(B);
            //    //Componente C = new Componente() { ItemId = "C", Description = "CC", Grupo = "GC", Orden = 1, Capacidad = 12, Cantidad = 1 };
            //    //sis1.Componentes.Add(C);
            //    //Componente D = new Componente() { ItemId = "D", Description = "DD", Grupo = "GD", Orden = 1, Capacidad = 12, Cantidad = 1 };
            //    //sis1.Componentes.Add(D);

            //    //db.Sistemas.Add(sis1);
            //    //db.SaveChanges();

            //    Sistema sis2 = db.Sistemas.First();
            //}
        }
    }
}
