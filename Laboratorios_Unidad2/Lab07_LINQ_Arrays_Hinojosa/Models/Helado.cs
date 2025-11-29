namespace Lab07_LINQ_Arrays_Hinojosa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Helado")]
    public partial class Helado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Helado()
        {
            Detalle_Pedido = new HashSet<Detalle_Pedido>();
        }

        [Key]
        [StringLength(3)]
        public string cod_helado { get; set; }

        public int id_categ { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(255)]
        public string composicion { get; set; }

        public int? stock_actual { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? precio { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Pedido> Detalle_Pedido { get; set; }

        //Metodos
        public List<Helado> Listar()
        {
            var helados = new List<Helado>();

            try
            {
                //1.Origen de Datos
                using (var db = new ModeloSistema())
                {
                    //2. sentencia LINQ
                    helados = db.Helado.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Resultado de la consulta
            return helados;
        }

        public List<Helado> ListarHeladoCategoria()
        {
            var helados = new List<Helado>();

            try
            {
                //1.Origen de Datos
                using (var db = new ModeloSistema())
                {
                    //2. sentencia LINQ
                    helados = db.Helado.Include("Categoria").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Resultado de la consulta
            return helados;
        }
    }
}
