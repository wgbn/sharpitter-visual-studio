using System;
using System.Linq;
using SharpitterVS.Models;
using SharpitterVS.Helpers;
using System.Data.Entity;
using System.Collections.Generic;

namespace SharpitterVS.Services {

    public class UsuarioService {
        //private SharpitterDbMysql db;
        private SharpitterDbLocal db;

		public UsuarioService () {
            //db = new SharpitterDbMysql();
            db = new SharpitterDbLocal();
		}

		public bool CadastraUsuario(Usuario _usuario){
			_usuario.HashSenha ();
            db.Usuarios.Add(_usuario);
            db.SaveChanges();
			return true;
		}

		public bool EditaUsuario(Usuario _usuario){
            db.Entry(_usuario).State = EntityState.Modified;
            db.SaveChanges();
            return true;
		}

		public bool ExcluiUsuario(Usuario _usuario){
            db.Usuarios.Remove(_usuario);
            db.SaveChanges(); 
            return true;
		}

        public bool ExcluiPorId(int _id) {
            Usuario userDel = null;

            try {
                var usuario = from u in db.Usuarios
                              where u.Id.Equals(_id)
                              select u;

                userDel = usuario.Single<Usuario>();
                db.Usuarios.Remove(userDel);
                db.SaveChanges();

                return true;
            } catch {
                return false;
            }
        }

		public Usuario GetByUsername(string _username){
			return null;
		}

        public Usuario GetPorId(int _id) {
            Usuario u = null;
            try {
                u = db.Usuarios.Find(_id);
            } catch (Exception e) {
                Console.Write(e.StackTrace);
            }

            return u;
        }

		public Usuario LoginUsuario(Usuario _usuario){
			_usuario.HashSenha();

			try {
                var usuario = from u in db.Usuarios
                    where u.Username.Equals(_usuario.Username)
                    select u;

                Usuario us = usuario.Single<Usuario>();

                if (us != null && us.Senha.Equals(_usuario.Senha))
                    return us;

			} catch (Exception e){
				Console.WriteLine (e.StackTrace);
			}

			return null;
		}

		public bool VerificaUsuarioExistente(Usuario _usuario){
            Usuario eu = null;
            try {
                var existeUsername = from u in db.Usuarios
                                     where u.Username.Equals(_usuario.Username)
                                     select u;

                eu = existeUsername.First<Usuario>();
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }

            Usuario ee = null;
            try {
                var existeEmail = from u in db.Usuarios
                                  where u.Email.Equals(_usuario.Email)
                                     select u;
                
                ee = existeEmail.First<Usuario>();
			} catch (Exception e) {
				Console.WriteLine (e.StackTrace);
			}

            if (eu == null && ee == null)
                return false;

            return true;
		}

        public List<Usuario> GetAll() {
            return db.Usuarios.ToList();
        }

	}

}

