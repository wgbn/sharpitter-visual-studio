using System;
using System.Web.Mvc;
using SharpitterVS.Services;
using SharpitterVS.Enums;
using System.Web;
using System.Linq;
using System.Web.Routing;

namespace SharpitterVS.Filters {

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public class AuthFilter : AuthorizeAttribute {
		private Permissoes[] _permissoes;
		//private MeuProjetoContext context = new MeuProjetoContext();

		public AuthFilter(params Permissoes[] permissoes){
			_permissoes = permissoes;
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext) {
			SessionService ss = SessionService.Instance;
			if (!ss.IsLogado ())
				return false;

			if (!_permissoes.Any()) return true;

			foreach (var permissao in _permissoes){
				switch (permissao) {
				case Permissoes.Usuario:
					return true;
				case Permissoes.Administrador:
					return true;
				}
			}

			return false;
		}

		// Implemente abaixo pra onde a requisição vai se o usuário não estiver autorizado
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
			filterContext.Result = new RedirectToRouteResult (
				new RouteValueDictionary (
					new {
                    controller = "Home",
                    action = "Login"
                })
			);

		}
    	
	}

}