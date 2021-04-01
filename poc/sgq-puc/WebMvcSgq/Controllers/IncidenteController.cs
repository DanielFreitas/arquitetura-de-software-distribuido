using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcSgq.Models;

namespace WebMvcSgq.Controllers
{
    public class IncidenteController : Controller
    {
        //private IIncidenteRepositorio rep = null/* TODO Change to default(_) if this is not a reference type */;

        //public IncidenteController()
        //{
        //    this.rep = new IncidenteRepositorio();
        //}

        //public IncidenteController(IIncidenteRepositorio repositorio)
        //{
        //    this.rep = repositorio;
        //}

        //public ActionResult Index()
        //{
        //    var listaIncidente = from incidentes in rep.GetIncidenteDetalhes()
        //                         select incidentes;
        //    return View(listaIncidente);
        //}

        //public ActionResult AdicionarIncidente()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AdicionarIncidente(Incidente incidente)
        //{
        //    rep.AdicionaIncidente(incidente);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult EditarIncidente(int id = 0)
        //{
        //    Incidente incidente = rep.GetIncidentePorID(id);

        //    if (incidente == null)
        //        return HttpNotFound();

        //    return View(incidente);
        //}

        //[HttpPost]
        //public ActionResult EditarIncidente(Incidente incidente)
        //{
        //    rep.AtualizaIncidente(incidente);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult DeletarIncidente(int id = 0)
        //{
        //    Incidente usuario = rep.GetIncidentePorID(id);

        //    if (usuario == null)
        //        return HttpNotFound();

        //    return View(usuario);
        //}

        //[HttpPost]
        //public ActionResult DeletarIncidente(Incidente incidente)
        //{
        //    rep.DeletaIncidente(incidente.IdIncidente);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Detalhes(int id = 0)
        //{
        //    Incidente usuario = rep.Detalhes(id);
        //    return View(usuario);
        //}
    }

}