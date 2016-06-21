using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SharpitterVS.Services;
using SharpitterVS.Models;
using System.Threading.Tasks;

namespace SharpitterVS.Controllers {
	
	public class HomeController : BaseController {

		private readonly UsuarioService usuarioService = new UsuarioService();
		private readonly SharppService sharppService = new SharppService();

		//private List<Sharpp> _sharpps;

		/*public void IndexAsync(){
			AsyncManager.OutstandingOperations.Increment(1);
			var sharpps = sharppService.GetRecentesAsync();
			var list = sharpps.Result;

			AsyncManager.Parameters["sharpps"] = list;
			AsyncManager.OutstandingOperations.Decrement();
		}*/
		
		/*public ActionResult IndexCompleted(List<Sharpp> sharpps) {
			System.Console.WriteLine ("IndexCompleted");
            //TempData ["sharpps"] = sharpps;
            var usuario = SessionService.Instance.GetUsuarioLogado();
            ViewBag.Usuario = usuario;
            ViewBag.Sharpps = sharpps;

            return View ();
		}*/

		public ActionResult Index(){
			System.Console.WriteLine("HomeController::Index");
			ViewBag.Sharpps = sharppService.GetRecentes();
			var usuario = SessionService.Instance.GetUsuarioLogado ();
			ViewBag.Usuario = usuario;
			return View ();
		}

		public ActionResult Perfil(string _username){
			//Usuario usuario = usuarioService.GetByUsername ("wgbn");
			return null;
		}

		[HttpPost]
		public ActionResult Sharpp([Bind(Include = "Texto")] Sharpp _sharpp){
			_sharpp.Autor = SessionService.Instance.GetUsuarioLogado().Username;
            _sharpp.UsuarioId = SessionService.Instance.GetUsuarioLogado().Id;
			_sharpp.Registro = DateTime.Now;
            //_sharpp.Save ();
            sharppService.PostSharpp(_sharpp);
            Console.WriteLine("Post Sharpp");
			return RedirectToAction("Index");
		}

		[AllowAnonymous, HttpGet]
		public ActionResult Login(){
			ViewBag.Title = "Sharpitter # Login";
			return View ();
		}

		[AllowAnonymous, HttpPost]
		public ActionResult Login([Bind(Include = "Username,Senha")] Usuario _usuario){
			Usuario usuario = usuarioService.LoginUsuario (_usuario);

			if (usuario != null){
				SessionService.Instance.SetUsuarioLogado (usuario);
				return RedirectToAction("Index");
			}

			ViewBag.Title = "Sharpitter # Login";
			ViewBag.MsgStatus = "Usuário ou senha inválidos";
			return View ();
		}

		public ActionResult LogOut(){
			SessionService.Instance.SetUsuarioLogout ();
			return RedirectToAction("Index");
		}

		[AllowAnonymous, HttpGet]
		public ActionResult CriarUsuario(){
			ViewBag.Title = "Sharpitter # Novo Usuário";
			return View ();
		}

		[AllowAnonymous, HttpPost]
		public ActionResult CriarUsuario([Bind(Include = "Username, Nome, Email, Senha, Avatar")] Usuario _usuario){
            _usuario.Registro = DateTime.Now;

			if (!usuarioService.VerificaUsuarioExistente(_usuario)){
				if (usuarioService.CadastraUsuario(_usuario)){
					SessionService.Instance.SetUsuarioLogado (_usuario);
					return RedirectToAction("Index");
				}
			} else {
				ViewBag.MsgStatus = "Já existe um usuário com este e-mail ou nome de usuário";
			}

			ViewBag.Title = "Sharpitter # Novo Usuário";
			return View ();
		}

	}

}