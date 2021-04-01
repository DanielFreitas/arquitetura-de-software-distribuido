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
    public class NaoConformidadeController : Controller
    {

        private INaoConformidadeRepositorio rep = null;
        private IProcessoRepositorio repProcesso = null;
        private IAtividadeDiariaRepositorio repAtiviDiaRep = null;
        private INormaRepositorio normaRepositorio = null;

        public NaoConformidadeController()
        {
            this.rep = new NaoConformidadeRepositorio();
            this.repProcesso = new ProcessoRepositorio();
            this.repAtiviDiaRep = new AtividadeDiariaRepositorio();
            this.normaRepositorio = new NormaRepositorio();
        }

        // GET: NaoConformidade
        public ActionResult Index()
        {
            Acessos acesso = new Acessos();

            if (SessaoUsuario.VerificarLogin())
            {
                Session["Usuario"] = null;

                return RedirectToAction("Login", "Login");
            }

            string caminho = HttpContext.Request.Path;
            if (caminho.ToUpper().Contains(acesso.NAOCONFORMIDADE_INDEX))
                caminho = acesso.NAOCONFORMIDADE_INDEX;

            if (!acesso.ConsultaAcesso(caminho))
            {
                return RedirectToAction("SemAcesso", "Acesso");
            }

            IEnumerable<tbl_NaoConformidade> listaNaoConformidade = null;


            listaNaoConformidade = from naoConf in rep.GetNaoConformidade()
                                   select naoConf;

            NaoConformidadeModel obj = new NaoConformidadeModel();
            List<NaoConformidadeModel> listaObj = new List<NaoConformidadeModel>();
            foreach (var item in listaNaoConformidade)
            {
                obj = new NaoConformidadeModel()
                {
                    DsNaoConformidade = item.DsNaoConformidade,
                    Dt_Cadastro = item.Dt_Cadastro,
                    Dstatus = item.Dstatus,
                    Dt_Alteracao = item.Dt_Alteracao,
                    IdAtividadeDiaria = item.IdAtividadeDiaria,
                    IdNaoConformidade = item.IdNaoConformidade,
                    IdProcesso = item.IdProcesso,
                    Tbl_Atividade_Diaria = item.Tbl_Atividade_Diaria,
                    tbl_Processo = item.tbl_Processo
                };

                obj.Tbl_NaoConformidade_x_Norma = item.Tbl_NaoConformidade_x_Norma;
                listaObj.Add(obj);
            }

            return View(listaObj.AsEnumerable());
        }

        public ActionResult NovaNaoConformidade()
        {
            NaoConformidadeModel naoConf = new NaoConformidadeModel();

            CarregarAtividade();
            CarregarProcesso();
            CarregarNormas(naoConf);

            return View(naoConf);
        }

        private void CarregarNormas(NaoConformidadeModel naoConf)
        {
            IEnumerable<LinksWrapper<Content>> listNorma = this.normaRepositorio.GetAll();
          
            foreach (var x in listNorma.ToList())
            {
                naoConf.Tbl_NaoConformidade_x_Norma.Add(new Tbl_NaoConformidade_x_Norma
                {
                    IdNaoConformidade = naoConf.IdNaoConformidade,
                    IdNorma = x.Content.NormaId,
                    UrlNorma = x.Content.UrlDocumento,
                    Titulo = x.Content.Titulo
                }
                );
            }

            NaoConformidadeModel obj = new NaoConformidadeModel()
            {
                Tbl_NaoConformidade_x_Norma = naoConf.Tbl_NaoConformidade_x_Norma                
            };

            ViewBag.Norma = obj.Tbl_NaoConformidade_x_Norma;
        }

        [HttpPost]
        public ActionResult NovaNaoConformidade(NaoConformidadeModel naoConformidade)
        {
            LinksWrapper<Content> listNorma = this.normaRepositorio.GetNormaById(naoConformidade.NormaId);

            naoConformidade.Tbl_NaoConformidade_x_Norma.Add(new Tbl_NaoConformidade_x_Norma()
            {
                IdNorma = naoConformidade.NormaId,
                IdNaoConformidade = naoConformidade.IdNaoConformidade,
                Titulo = listNorma.Content.Titulo,
                UrlNorma = listNorma.Content.UrlDocumento
            }
            );

            tbl_NaoConformidade obj = new tbl_NaoConformidade()
            {
                DsNaoConformidade = naoConformidade.DsNaoConformidade,
                Dt_Cadastro = naoConformidade.Dt_Cadastro,
                Dstatus = naoConformidade.Dstatus,
                Dt_Alteracao = naoConformidade.Dt_Alteracao,
                IdAtividadeDiaria = naoConformidade.IdAtividadeDiaria,
                IdNaoConformidade = naoConformidade.IdNaoConformidade,
                IdProcesso = naoConformidade.IdProcesso,
                Tbl_Atividade_Diaria = naoConformidade.Tbl_Atividade_Diaria,
                tbl_Processo = naoConformidade.tbl_Processo,
                Tbl_NaoConformidade_x_Norma = naoConformidade.Tbl_NaoConformidade_x_Norma
            };

            rep.AdicionaNaoConformidade(obj);

            return RedirectToAction("Index");
        }

        public ActionResult CarregarProcesso()
        {
            NaoConformidadeModel naoConf = new NaoConformidadeModel();

            IEnumerable<tbl_Processo> listaObj = repProcesso.GetProcessos();

            ViewBag.IdProcesso = new SelectList
                (
                    listaObj,
                    "IdProcesso",
                    "Nome"
                );

            return View(naoConf);
        }

        public ActionResult CarregarAtividade()
        {
            NaoConformidadeModel naoConf = new NaoConformidadeModel();

            IEnumerable<Tbl_Atividade_Diaria> listaObj = repAtiviDiaRep.GetAtividadeDiaria();

            ViewBag.IdAtividadeDiaria = new SelectList
                (
                    listaObj,
                    "IdAtividadeDiaria",
                    "Descricao"
                );

            return View(naoConf);
        }

        public ActionResult EditarNaoConformidade(int IdNaoConformidade = 0)
        {

            CarregarProcesso();
            CarregarAtividade();

            tbl_NaoConformidade naoConf = new tbl_NaoConformidade();
            naoConf = rep.GetNaoConformidadePorID(IdNaoConformidade);

            if (naoConf.Tbl_NaoConformidade_x_Norma.Count > 0)
            {
                naoConf.IdSequencial = naoConf.Tbl_NaoConformidade_x_Norma.FirstOrDefault().IdSequencial;
            }

            naoConf.Tbl_NaoConformidade_x_Norma = new HashSet<Tbl_NaoConformidade_x_Norma>();

            IEnumerable<LinksWrapper<Content>> listNorma = this.normaRepositorio.GetAll();

            foreach (var x in listNorma.ToList())
            {
                naoConf.Tbl_NaoConformidade_x_Norma.Add(new Tbl_NaoConformidade_x_Norma
                {
                    IdNaoConformidade = naoConf.IdNaoConformidade,
                    IdNorma = x.Content.NormaId,
                    UrlNorma = x.Content.UrlDocumento,
                    Titulo = x.Content.Titulo
                }
                );
            }

            NaoConformidadeModel obj = new NaoConformidadeModel()
            {
                DsNaoConformidade = naoConf.DsNaoConformidade,
                Dt_Cadastro = naoConf.Dt_Cadastro,
                Dstatus = naoConf.Dstatus,
                Dt_Alteracao = naoConf.Dt_Alteracao,
                IdAtividadeDiaria = naoConf.IdAtividadeDiaria,
                IdNaoConformidade = naoConf.IdNaoConformidade,
                IdProcesso = naoConf.IdProcesso,
                Tbl_Atividade_Diaria = naoConf.Tbl_Atividade_Diaria,
                tbl_Processo = naoConf.tbl_Processo,
                Tbl_NaoConformidade_x_Norma = naoConf.Tbl_NaoConformidade_x_Norma,
                IdSequencial = naoConf.IdSequencial
            };

            return View(obj);
        }

        [HttpPost]
        public ActionResult EditarNaoConformidade(NaoConformidadeModel naoConformidade)
        {
            LinksWrapper<Content> listNorma = this.normaRepositorio.GetNormaById(naoConformidade.NormaId);

            naoConformidade.Tbl_NaoConformidade_x_Norma.Add(new Tbl_NaoConformidade_x_Norma()
            {
                IdSequencial = naoConformidade.IdSequencial,
                IdNorma = naoConformidade.NormaId,
                IdNaoConformidade = naoConformidade.IdNaoConformidade,
                Titulo = listNorma.Content.Titulo,
                UrlNorma = listNorma.Content.UrlDocumento
            }
            );

            tbl_NaoConformidade obj = new tbl_NaoConformidade()
            {
                DsNaoConformidade = naoConformidade.DsNaoConformidade,
                Dt_Cadastro = naoConformidade.Dt_Cadastro,
                Dstatus = naoConformidade.Dstatus,
                Dt_Alteracao = naoConformidade.Dt_Alteracao,
                IdAtividadeDiaria = naoConformidade.IdAtividadeDiaria,
                IdNaoConformidade = naoConformidade.IdNaoConformidade,
                IdProcesso = naoConformidade.IdProcesso,
                Tbl_Atividade_Diaria = naoConformidade.Tbl_Atividade_Diaria,
                tbl_Processo = naoConformidade.tbl_Processo,
                Tbl_NaoConformidade_x_Norma = naoConformidade.Tbl_NaoConformidade_x_Norma,
                IdSequencial = naoConformidade.IdSequencial

            };

            rep.AtualizaNaoConformidade(obj);

            if (obj.IdSequencial > 0)
            {
                this.normaRepositorio.Atualiza(obj.Tbl_NaoConformidade_x_Norma);
            }
            else
            {
                this.normaRepositorio.AdicionaNaoConformidade_x_Norma(obj.Tbl_NaoConformidade_x_Norma);
            }


            return RedirectToAction("Index");
        }

        public ActionResult DeletarNaoConformidade(int IdNaoConformidade = 0)
        {
            tbl_NaoConformidade naoConf = rep.GetNaoConformidadePorID(IdNaoConformidade);

            NaoConformidadeModel obj = new NaoConformidadeModel()
            {
                DsNaoConformidade = naoConf.DsNaoConformidade,
                Dt_Cadastro = naoConf.Dt_Cadastro,
                Dstatus = naoConf.Dstatus,
                Dt_Alteracao = naoConf.Dt_Alteracao,
                IdAtividadeDiaria = naoConf.IdAtividadeDiaria,
                IdNaoConformidade = naoConf.IdNaoConformidade,
                IdProcesso = naoConf.IdProcesso,
                Tbl_Atividade_Diaria = naoConf.Tbl_Atividade_Diaria,
                tbl_Processo = naoConf.tbl_Processo,
                Tbl_NaoConformidade_x_Norma = naoConf.Tbl_NaoConformidade_x_Norma
            };

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        [HttpPost]
        public ActionResult DeletarNaoConformidade(NaoConformidadeModel naoConf)
        {
            tbl_NaoConformidade obj = rep.GetNaoConformidadePorID(naoConf.IdNaoConformidade);
            this.normaRepositorio.DeleteNaoConformidade_x_Norma(obj.Tbl_NaoConformidade_x_Norma);

            rep.DeletaNaoConformidade(naoConf.IdNaoConformidade);

            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int IdNaoConformidade = 0)
        {
            tbl_NaoConformidade naoConf = rep.Detalhes(IdNaoConformidade);

            NaoConformidadeModel obj = new NaoConformidadeModel()
            {
                DsNaoConformidade = naoConf.DsNaoConformidade,
                Dt_Cadastro = naoConf.Dt_Cadastro,
                Dstatus = naoConf.Dstatus,
                Dt_Alteracao = naoConf.Dt_Alteracao,
                IdAtividadeDiaria = naoConf.IdAtividadeDiaria,
                IdNaoConformidade = naoConf.IdNaoConformidade,
                IdProcesso = naoConf.IdProcesso,
                Tbl_Atividade_Diaria = naoConf.Tbl_Atividade_Diaria,
                tbl_Processo = naoConf.tbl_Processo,
                Tbl_NaoConformidade_x_Norma = naoConf.Tbl_NaoConformidade_x_Norma
            };

            return View(obj);
        }

        public ActionResult Login()
        {
            Session["Usuario"] = null;

            SessaoUsuario.SessaoUsuarios = null;

            return RedirectToAction("Login", "Login");

        }
    }
}