//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionColegioMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matricula
    {
        public int IdMatricula { get; set; }
        public Nullable<decimal> Nota { get; set; }
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
        public Nullable<int> IdProfe { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Profe Profe { get; set; }
    }
}
