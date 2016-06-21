using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using SharpitterVS.Services;
using SharpitterVS.Models;

namespace SharpitterVS.Controllers {
	
    public class UsuarioController : Controller {

		private UsuarioService usuarioService = new UsuarioService();
        private SharppService sharppService = new SharppService();
		
		public JsonResult Index() {
            return Json(usuarioService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Sharpps() {
            return Json(sharppService.GetRecentes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DelAllSharpps() {
            sharppService.DeleteAll();
            return RedirectToAction("Sharpps");
        }

        public ActionResult Details(int id) {
            return View ();
        }

        public ActionResult Create() {
            return View ();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id) {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id) {
            try {
                usuarioService.ExcluiPorId(id);
                return RedirectToAction("Index");
            } catch {
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                Usuario u = new Usuario() { Id = id };
                usuarioService.ExcluiUsuario(u);
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

    }

}