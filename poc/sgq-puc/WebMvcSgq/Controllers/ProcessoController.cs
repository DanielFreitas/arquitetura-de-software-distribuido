using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Sessao;

namespace WebMvcSgq.Controllers
{
    public class ProcessoController : Controller
    {

        private IProcessoRepositorio rep = null/* TODO Change to default(_) if this is not a reference type */;

        public ProcessoController()
        {
            this.rep = new ProcessoRepositorio();
        }

        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }

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

            var listaProcessos = from processos in rep.GetProcessos()
                                 select processos;
            return View(listaProcessos);
        }

        public ActionResult AdicionarProcesso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarProcesso(tbl_Processo processo)
        {
            rep.AdicionaProcesso(processo);
            return RedirectToAction("Index");
        }

        public ActionResult EditarProcesso(int id = 0)
        {
            tbl_Processo processo = rep.GetProcessoPorID(id);

            if (processo == null)
                return HttpNotFound();

            return View(processo);
        }

        [HttpPost]
        public ActionResult EditarProcesso(tbl_Processo processo)
        {
            rep.AtualizaProcesso(processo);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarProcesso(int id = 0)
        {
            tbl_Processo processo = rep.GetProcessoPorID(id);

            if (processo == null)
                return HttpNotFound();

            return View(processo);
        }

        [HttpPost]
        public ActionResult DeletarProcesso(tbl_Processo processo)
        {
            rep.DeletaProcesso(processo.IdProcesso);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id = 0)
        {
            tbl_Processo processo = rep.Detalhes(id);
            return View(processo);
        }

    }
}