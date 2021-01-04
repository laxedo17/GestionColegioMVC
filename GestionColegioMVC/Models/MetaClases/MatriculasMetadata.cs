using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionColegioMVC.Models
{
    public class MatriculasMetadata
    {
        [Display(Name = "Nota de estudiante")]
        public Nullable<decimal> Nota { get; set; }

        [Display(Name ="Curso")]
        public int IdCurso { get; set; }

        [Display(Name ="Estudiante")]
        public int IdEstudiante { get; set; }

        [Display(Name = "Estudiante")]
        public Estudiante Estudiante { get; set; }

        [Display(Name = "Profe")]
        public Nullable<int> IdProfe { get; set; }

        [Display(Name ="Profe")]
        public Profe Profe { get; set; }
    }

    [MetadataType(typeof(MatriculasMetadata))]
    public partial class Matriculas 
    {
        //[Display(Name = "Nome Estudiante")]
        //public string NomeCompletoEstudiante
        //{

        //    get
        //    {
        //        Estudiante estudiante = new Estudiante();
        //        return ( estudiante.Nombre + " " + estudiante.Apellido);
        //    }
        //}

        //[Display(Name = "Nome Profe")]
        //public string NomeCompletoProfe
        //{
        //    get
        //    {
        //        Profe profesorado = new Profe();
        //        return (profesorado.Nombre + " " + profesorado.Apellidos);
        //    }
        //}
    }
}