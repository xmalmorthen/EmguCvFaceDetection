//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.dataBases
{
    using System;
    using System.Collections.Generic;
    
    public partial class caUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public caUsers()
        {
            this.caFaces = new HashSet<caFaces>();
        }
    
        public int id { get; set; }
        public int idPerson { get; set; }
        public string nip { get; set; }
        public string username { get; set; }
        public bool active { get; set; }
        public System.DateTime fIns { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<caFaces> caFaces { get; set; }
        public virtual caPerson caPerson { get; set; }
    }
}
