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
    public class EtapaController : Controller
    {
        private IEtapaRepositorio rep = null/* TODO Change to default(_) if this is not a reference type */;

        public EtapaController()
        {
            this.rep = new EtapaRepositorio();
        }

        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }

        public ActionResult Index(int id = 0)
        {
            Acessos acesso = new Acessos();

            if (SessaoUsuario.VerificarLogin())
            {
                Session["Usuario"] = null;

                return RedirectToAction("Login", "Login");
            }

            string caminho = HttpContext.Request.Path;
            if (caminho.ToUpper().Contains(acesso.ETAPA_INDEX))
                caminho = acesso.ETAPA_INDEX;

            if (!acesso.ConsultaAcesso(caminho))
            {
                return RedirectToAction("SemAcesso", "Acesso");
            }

            IEnumerable<tbl_etapa> listaEtapas = null;

            if (id > 0)
            {
                listaEtapas = from etapa in rep.GetEtapas(id)
                              select etapa;
            }
            else
            {
                listaEtapas = from etapa in rep.GetEtapas()
                                  select etapa;
            }

            SessaoProcesso.SessaoProcessoId = id;

            return View(listaEtapas);
        }

        public ActionResult AdicionarEtapa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarEtapa(tbl_etapa etapa)
        {
            rep.AdicionaEtapa(etapa);
            return RedirectToAction("Index");
        }

        public ActionResult EditarEtapa(int id = 0)
        {
            tbl_etapa etapa = rep.GetEtapaByID(id);

            if (etapa == null)
                return HttpNotFound();

            return View(etapa);
        }

        [HttpPost]
        public ActionResult EditarEtapa(tbl_etapa etapa)
        {
            rep.AtualizaEtapa(etapa);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarEtapa(int id = 0)
        {
            tbl_etapa etapa = rep.GetEtapaByID(id);

            if (etapa == null)
                return HttpNotFound();

            return View(etapa);
        }

        [HttpPost]
        public ActionResult DeletarEtapa(tbl_etapa etapa)
        {
            rep.DeletaEtapa(etapa.IdEtapa);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id = 0)
        {
            tbl_etapa etapa = rep.Detalhes(id);
            return View(etapa);
        }
    }
}