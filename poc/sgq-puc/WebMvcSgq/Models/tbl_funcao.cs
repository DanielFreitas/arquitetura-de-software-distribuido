//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMvcSgq.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_funcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_funcao()
        {
            this.tbl_Acessos = new HashSet<tbl_Acessos>();
            this.tbl_Funcionario = new HashSet<tbl_Funcionario>();
        }
    
        public long IdFuncao { get; set; }
        public string DsFuncao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Acessos> tbl_Acessos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Funcionario> tbl_Funcionario { get; set; }
    }
}
