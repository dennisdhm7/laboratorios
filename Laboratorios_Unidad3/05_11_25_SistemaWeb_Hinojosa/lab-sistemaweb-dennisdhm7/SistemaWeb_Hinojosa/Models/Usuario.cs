namespace SistemaWeb_Hinojosa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        //Métodos
        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new ModeloSistema())
                {
                    Password = HashHelper.MD5(Password);
                    var usuario = db.Usuario.Where(x => x.nombre == Usuario)
                        .Where(x => x.clave == Password)
                        .SingleOrDefault();

                    if (Usuario != null)
                    {
                        SessionHelper.AddUserToSession
                            (usuario.id_usuario.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos ...");
                    }
                }
            }
            catch (Exception ex)
            {
                rm.SetResponse(false, "Error: " + ex.Message);
            }
            return rm;
        }

        //Metodo Obtener
        public Usuario Obtener(int id) //retornar un objeto
        {
            var usuario = new Usuario();

            try
            {
                using (var db = new ModeloSistema())
                {
                    usuario = db.Usuario.Include("Empleado")
                                .Where(x => x.id_usuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }


    }

}
