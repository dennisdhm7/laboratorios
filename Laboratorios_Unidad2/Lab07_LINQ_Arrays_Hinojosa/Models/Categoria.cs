namespace Lab07_LINQ_Arrays_Hinojosa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Helado = new HashSet<Helado>();
        }

        [Key]
        public int id_categ { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        [StringLength(70)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Helado> Helado { get; set; }

        //Metodos

        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            try
            {
                //1.Origen de Datos
                using (var db = new ModeloSistema())
                {
                    //2. sentencia LINQ
                    categorias = db.Categoria.ToList();
                }
            }
            catch (Exception ex) 
            {
                throw;
            }
            //3. Resultado de la consulta
            return categorias;
        }

        public List<Categoria> Consulta1()
        {
            var categorias = new List<Categoria>();

            try
            {
                //1.Origen de Datos
                using (var db = new ModeloSistema())
                {
                    //2. sentencia LINQ
                    categorias = db.Categoria
                        .Where(x => x.nombre.StartsWith("A")).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Resultado de la consulta
            return categorias;
        }
    }
}
