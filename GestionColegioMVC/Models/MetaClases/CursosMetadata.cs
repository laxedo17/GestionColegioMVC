using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//Esta libreria permitenos crear as validacions con distintos patrons

//namespace GestionColegioMVC.Models.MetaClases
namespace GestionColegioMVC.Models //orixinalmente o namespace de arriba, como creamos unha clase partial, desta maneira a clase buscara Curso no namespace GestionColegioMVC, senon en Metaclases non atopara Curso. Erro bastante comun este que se evita asi
{
    /// <summary>
    /// Clase de metadatos (datos sobre datos) dos Cursos para validacions.
    /// Esta clase non seria necesaria pero as validacions nesta clase, como o fixemos basandonos no dogma Database First, se actualizamos a base de datos cunha nova variable, perdemos estos valores na clase Curso.cs e teriamos que facelo cada vez
    /// </summary>
    public class CursosMetadata
    {
        [StringLength(50)] //limitacion de maximo 50 caracteres
        public string Titulo { get; set; }
        [Range(1,8)] //limitacion que indica que empeza minimo en 1, e o maximo e 8
        public int Creditos { get; set; }
    }

    /// <summary>
    /// Hai quen di que crer varias clases nun solo arquivo e mala idea, pero neste caso valenos para crear unha clase Partial (parcial) que se basara na clase Curso.cs e a traves de Partial queda asociada a ela
    /// </summary>
    [MetadataType(typeof(CursosMetadata))]
    public partial class Curso
    {
        
    }
}