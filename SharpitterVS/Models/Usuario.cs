namespace SharpitterVS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;
    using System.Text;
    using Services;

    [Table("wgbnc837_sharpitter.Usuario")]
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(512)]
        public string Senha { get; set; }

        [Required]
        [StringLength(512)]
        public string Avatar { get; set; }

        public DateTime Registro { get; set; }

        [NotMapped]
        public List<Usuario> Seguindo { get; set; }

        /*public bool Save() {
            UsuarioService us = new UsuarioService();
            //if (this._id.Increment == 0 && this._id.Machine == 0 && this._id.Pid == 0 && this._id.Timestamp == 0)
            if (this.Id == null || this.Id == 0)
                us.CadastraUsuario(this);
            else
                us.EditaUsuario(this);

            return true;
        }

        public bool Delete() {
            UsuarioService us = new UsuarioService();
            us.ExcluiUsuario(this);
            return true;
        }*/

        public void HashSenha() {
            HashAlgorithm algorithm = SHA1.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(this.Senha));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));

            this.Senha = sb.ToString();
        }
    }
}
