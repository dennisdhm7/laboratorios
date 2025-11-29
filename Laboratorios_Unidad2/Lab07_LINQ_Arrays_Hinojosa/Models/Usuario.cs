namespace Lab07_LINQ_Arrays_Hinojosa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(5)]
        public string cod_empleado { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        [Required]
        [StringLength(13)]
        public string nivel { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
