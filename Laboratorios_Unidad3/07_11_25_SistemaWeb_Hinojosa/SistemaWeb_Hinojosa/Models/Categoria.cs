namespace SistemaWeb_Hinojosa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

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

        //Metodos para el CRUD

        //Metodo Listar
        public List<Categoria> Listar() //retornar un collection
        { 
            var categorias = new List<Categoria>();

            try {
                using (var db = new ModeloSistema())
                { 
                    categorias = db.Categoria.ToList();
                }
            }
            catch(Exception) {
                throw;
            }
            return categorias;
        }

        //Metodo Obtener
        public Categoria Obtener(int id) //retornar un objeto
        {
            var categoria = new Categoria();

            try
            {
                using (var db = new ModeloSistema())
                {
                    categoria = db.Categoria
                                .Where(x => x.id_categ == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }


        //Metodo Buscar
        public List<Categoria> Buscar(string criterio) //retornar un collection
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var db = new ModeloSistema())
                {
                    categorias = db.Categoria
                                 .Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio))
                                 .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return categorias;
        }


        //Metodo Guardar
        public void Guardar() 
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if (this.id_categ > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        //Metodo Eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
