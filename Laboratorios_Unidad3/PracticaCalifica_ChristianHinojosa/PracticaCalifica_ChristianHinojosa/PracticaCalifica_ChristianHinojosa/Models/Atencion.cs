using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaCalifica_ChristianHinojosa.Models
{
    [Table("Atenciones")]
    public class Atencion
    {
        public int Id { get; set; }

        public string Semestre { get; set; }
        public DateTime FechaAtencion { get; set; }

        public int DocenteId { get; set; }
        public int EstudianteId { get; set; }

        public string Tema { get; set; }
        public string Consulta { get; set; }
        public string Descripcion { get; set; }
        public string Evidencia { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
