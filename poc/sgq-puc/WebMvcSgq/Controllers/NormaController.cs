using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Sessao;

namespace WebMvcSgq.Controllers
{
    public class NormaController : Controller
    {

        private INormaRepositorio normaRepositorio = null;

        public NormaController()
        {
            this.normaRepositorio = new NormaRepositorio();
        }


        // GET: Norma
        public ActionResult Index()
        {

            Acessos acesso = new Acessos();

            if (SessaoUsuario.VerificarLogin())
            {
                Session["Usuario"] = null;

                return RedirectToAction("Login", "Login");
            }

            if (!acesso.ConsultaAcesso(HttpContext.Request.Path))
            {
                return RedirectToAction("SemAcesso", "Acesso");
            }

            IEnumerable<LinksWrapper<Content>> listNorma = this.normaRepositorio.GetAll();
           

            return View(listNorma.ToList());
        }


        public ActionResult Detalhes(long normaId = 0)
        {
            LinksWrapper<Content> c =  this.normaRepositorio.GetNormaById(normaId);

            return View(c);
        }


        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }
    }
}