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
                    // Encriptar la contraseña ingresada
                    Password = HashHelper.MD5(Password);

                    // Buscar usuario que coincida con nombre y clave
                    var usuario = db.Usuario
                        .Where(x => x.nombre == Usuario && x.clave == Password)
                        .SingleOrDefault();

                    // Verificar si se encontró el usuario
                    if (usuario != null)
                    {
                        // Guardar el usuario en sesión
                        SessionHelper.AddUserToSession(usuario.id_usuario.ToString());

                        rm.SetResponse(true);
                    }
                    else
                    {
                        // Usuario o contraseña incorrectos
                        rm.SetResponse(false, "Usuario y/o Password incorrectos ...");
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar o manejar el error según tu necesidad
                rm.SetResponse(false, "Error interno: " + ex.Message);
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
                    usuario = db.Usuario
                                .Where(x => x.id_usuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }
    }
}
