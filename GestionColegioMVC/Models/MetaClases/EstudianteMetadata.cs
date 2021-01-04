using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionColegioMVC.Models
{
    public class EstudianteMetadata
    {
        [StringLength(50)]
        [Display(Name ="Apelidos")]
        public string Apellido { get; set; }
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nombre { get; set; }
        [Display(Name = "Data de Matriculacion")]
        public Nullable<System.DateTime> FechaMatriculacion { get; set; }
        [StringLength(50)]
        [Display(Name = "Segundo Nome")]
        public string SegundoNombre { get; set; }
        //public Nullable<System.DateTime> FechaNacimiento { get; set; }
    }

    [MetadataType(typeof(EstudianteMetadata))]
    public partial class Estudiante
    {

    }
}