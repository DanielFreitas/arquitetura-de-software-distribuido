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
    public class AtividadeDiariaController : Controller
    {
        private IAtividadeDiariaRepositorio rep = null;
        private IProcessoRepositorio processoRep = null;
        private IEtapaRepositorio etapaRep = null;
        private IAtividadeRepositorio ativRep = null;
        private INaoConformidadeRepositorio repNaoConformidade = null;
        private IAtividadeRepositorio repAtividadeRepositorio = null;
        
        public AtividadeDiariaController()
        {
            this.rep = new AtividadeDiariaRepositorio();
            this.processoRep = new ProcessoRepositorio();
            this.etapaRep = new EtapaRepositorio();
            this.ativRep = new AtividadeRepositorio();
            this.repNaoConformidade = new NaoConformidadeRepositorio();
            this.repAtividadeRepositorio = new AtividadeRepositorio();
        }

        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }

        // GET: AtividadeDiaria
        public ActionResult Index(int id = 0)
        {
            Acessos acesso = new Acessos();

            if (SessaoUsuario.VerificarLogin())
            {
                Session["Usuario"] = null;

                return RedirectToAction("Login", "Login");
            }

            string caminho = HttpContext.Request.Path;
            if (caminho.ToUpper().Contains(acesso.ATIVIDADEDIARIA_INDEX))
                caminho = acesso.ATIVIDADEDIARIA_INDEX;

            if (!acesso.ConsultaAcesso(caminho))
            {
                return RedirectToAction("SemAcesso", "Acesso");
            }

            IEnumerable<Tbl_Atividade_Diaria> listaAtivDiaria = null;

            if (id > 0) { 
                listaAtivDiaria = from ativDiaria in rep.GetAtividadeDiaria().Where(p=> p.IdProcesso == id)
               select ativDiaria;
            }
            else
            {
                listaAtivDiaria = from ativDiaria in rep.GetAtividadeDiaria()
                                  select ativDiaria;
            }

            SessaoProcesso.SessaoProcessoId = id;

            return View(listaAtivDiaria);
        }

        public ActionResult GetAtividades()
        {
            IEnumerable<tbl_atividades> listaAtividade = ativRep.GetAtividade(SessaoAtividadeDiaria.SessaoAtivDiariaId);

            ViewBag.listAtividades = listaAtividade;
            return View(listaAtividade.ToList());
        }

        public ActionResult AdicionaAtividadeDiaria(int IdAtividadeDiaria)
        {
            Tbl_Atividade_Diaria ativDiaria = new Tbl_Atividade_Diaria();

            SessaoAtividadeDiaria.SessaoAtivDiariaId = IdAtividadeDiaria;

            GetAtividades();

            ViewBag.IdProcesso = new SelectList
                (
                    processoRep.GetProcessos(),
                    "IdProcesso",
                    "Nome"
                );


            return View(ativDiaria);
        }

        [HttpPost]
        public ActionResult AdicionaAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria)
        {
            ViewBag.IdProcesso = new SelectList
               (
                   processoRep.GetProcessos(),
                   "IdProcesso",
                   "Nome"
               );

            rep.AdicionaAtividadeDiaria(ativDiaria);
            return RedirectToAction("Index");
        }

        public ActionResult EditarAtividadeDiaria(int IdAtividadeDiaria = 0,int IdProcesso = 0)
        {
            AtiviModelView amv = new AtiviModelView();
            amv = rep.GetAtividadeDiariaPorID(IdAtividadeDiaria);

            SessaoProcesso.SessaoProcessoId = IdProcesso;
            SessaoAtividadeDiaria.SessaoAtivDiariaId = IdAtividadeDiaria;

            return View(amv);

        }

        [HttpPost]
        public ActionResult EditarAtividadeDiaria(AtiviModelView amv)
        {
            rep.EditarAtividadeDiaria(amv);
            return RedirectToAction("Index");

        }

        public ActionResult DeletarAtividadeDiaria(int IdAtividadeDiaria = 0)
        {
            Tbl_Atividade_Diaria ativDiaria = rep.GetAtividadePorID(IdAtividadeDiaria);

            if (ativDiaria == null)
                return HttpNotFound();

            return View(ativDiaria);
        }

        [HttpPost]
        public ActionResult DeletarAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria)
        {
            tbl_NaoConformidade naoConformidade = repNaoConformidade.GetNaoConformidadePorAtividadeDiaria(ativDiaria.IdAtividadeDiaria);

            if (naoConformidade != null)
            {
                ViewBag.Message = "Não é possível excluir pois existe registro de não conformidade associado à atividade!";
                return View(ativDiaria);
            }                      

            rep.DeletarAtividadeDiaria(ativDiaria.IdAtividadeDiaria);

            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int IdAtividadeDiaria = 0)
        {
            Tbl_Atividade_Diaria ativDiaria = rep.Detalhes(IdAtividadeDiaria);
            return View(ativDiaria);
        }
    }
}