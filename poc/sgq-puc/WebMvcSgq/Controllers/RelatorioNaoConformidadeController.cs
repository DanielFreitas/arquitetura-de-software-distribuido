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
    public class RelatorioNaoConformidadeController : Controller
    {
        private IProcessoRepositorio repProcesso = null;
        private IAtividadeDiariaRepositorio repAtiviDiaRep = null;
        private INaoConformidadeRepositorio repNaoConf = null;
        private RelatNaoConformidadeClass rnc;

        public RelatorioNaoConformidadeController()
        {
            this.repProcesso = new ProcessoRepositorio();
            this.repAtiviDiaRep = new AtividadeDiariaRepositorio();
            this.repNaoConf = new NaoConformidadeRepositorio();

            if (rnc == null)
            {
                this.rnc = new RelatNaoConformidadeClass();
                this.rnc.ListaNaoConformidade = new List<NaoConformidades>();
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

            RelatNaoConformidadeClass rc = new RelatNaoConformidadeClass();

            rc.ListaNaoConformidade = new List<NaoConformidades>();

            CarregarAtividade();
            CarregarProcesso();

            return View(rc);
        }

        [HttpPost]
        public ActionResult Index(RelatNaoConformidadeClass rel)
        {
            CarregarAtividade();
            CarregarProcesso();

            rel.ListaNaoConformidade = repNaoConf.GetNaoConformidadeRelatorio(ref rel);

            if (rel.ListaNaoConformidade.Count() == 0)
            {
                ViewBag.Message = "Nenhum registro encontrado!";
            }

            ViewBag.Status = (rel.status ? "Concluído" : "Não Concluído");

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

            return View(rnc);
        }

        public ActionResult CarregarAtividade()
        {

            ViewBag.IdAtividadeDiaria = new SelectList
                (
                    repAtiviDiaRep.GetAtividadeDiaria(),
                    "IdAtividadeDiaria",
                    "Descricao"
                );

            return View(rnc);

        }
        #endregion 

    }
}