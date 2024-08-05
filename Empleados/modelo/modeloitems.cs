using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Items
{
    public class ItemsContext : DbContext
    {
        public ItemsContext() : base("name=Empleados.Properties.Settings.EmpleadosContext")
        {
            
        }

        public DbSet<Sistema> Sistemas { get; set; }
    }

    public abstract class Item
    {
        [Key]
        public string ItemId { get; set; }
        public string Description { get; set; }
        public string Grupo { get; set; }
    }

    public class Componente : Item
    {
        public int Orden { get; set; }
        public int Capacidad { get; set; }
        public int Cantidad { get; set; }
    }

    public class Sistema : Item
    {
        List<Componente> _Componentes;
        public Sistema()
        {
            _Componentes = new List<Componente>();
        }
        public List<Componente> Componentes { get { return _Componentes; } set { _Componentes = value; } }
    }
}
