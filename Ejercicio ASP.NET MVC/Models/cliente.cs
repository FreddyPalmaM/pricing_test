//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejercicio_ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.telefono_contacto = new HashSet<telefono_contacto>();
            this.venta = new HashSet<venta>();
        }
    
        public int rut { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int id_comuna { get; set; }
        public int id_ciudad { get; set; }
    
        public virtual ciudad ciudad { get; set; }
        public virtual comuna comuna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono_contacto> telefono_contacto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta> venta { get; set; }
    }
}
