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
    public class RelatorioController : Controller
    {

        private IProcessoRepositorio repProcesso = null;
        private IAtividadeDiariaRepositorio repAtiviDiaRep = null;
        private RelatorioClass rc;

        public RelatorioController()
        {
            this.repProcesso = new ProcessoRepositorio();
            this.repAtiviDiaRep = new AtividadeDiariaRepositorio();

            if (rc == null)
            {
                this.rc = new RelatorioClass();
                this.rc.relatProcesso = new List<RelatorioProcesso>();
            }

        }

        // GET: Relatorio
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

            RelatorioClass rc = new RelatorioClass();

            rc.relatProcesso = new List<RelatorioProcesso>();

            CarregarAtividade();
            CarregarProcesso();

            return View(rc);
        }

        [HttpPost]
        public ActionResult Index(RelatorioClass rel)
        {
            CarregarAtividade();
            CarregarProcesso();

            rel.relatProcesso = repProcesso.GetProcessoRelatorio(ref rel);

            if (rel.relatProcesso.Count() == 0)
            {
                ViewBag.Message = "Nenhum registro encontrado!";
            }

            //ViewBag.Status = (rel.IsActive ? "Concluído" : "Em andamento");

            return View(rel);
        }

        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }

        #region DropDowPesquisa
        public ActionResult CarregarProcesso()
        {

            ViewBag.IdProcesso = new SelectList
                (
                    repProcesso.GetProcessos(),
                    "IdProcesso",
                    "Nome"
                );

            rc.IdProcessos = ViewBag.IdProcesso;

            return View(rc);
        }

        public ActionResult CarregarAtividade()
        {

            ViewBag.IdAtividadeDiaria = new SelectList
                (
                    repAtiviDiaRep.GetAtividadeDiaria(),
                    "IdAtividadeDiaria",
                    "Descricao"
                );

            rc.IdAtividadeDiarias = ViewBag.IdAtividadeDiaria;

            return View(rc);

        }
        #endregion 

    }
}