using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.Models
{
    public class IncidenteRepositorio : IIncidenteRepositorio
    {
        db_sgqEntities db = new db_sgqEntities();

        // void IIncidenteRepositorio.AdicionaIncidente(Incidente incidente)
        //{
        //    try
        //    {
        //        db.Incidente.Add(incidente);
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if ((db == null))
        //            db.Dispose();
        //    }
        //}
        // void IIncidenteRepositorio.AtualizaIncidente(Incidente incidente)
        //{
        //    try
        //    {
        //        var novoIncidente = db.Incidente.Where(x => x.IdIncidente == incidente.IdIncidente).FirstOrDefault();
        //        novoIncidente.IdEtapa = incidente.IdEtapa;
        //        novoIncidente.IdItem = incidente.IdItem;
        //        novoIncidente.IdProblema = incidente.IdProblema;
        //        novoIncidente.Descricao = incidente.Descricao;
        //        db.SaveChanges();
        //        novoIncidente = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.Dispose();
        //    }
        //}

        // void IIncidenteRepositorio.DeletaIncidente(long incidenteId)
        //{
        //    try
        //    {
        //        Incidente _incidente = db.Incidente.SingleOrDefault(x => x.IdIncidente == incidenteId);
        //        db.Incidente.Remove(_incidente);
        //        db.SaveChanges();
        //        _incidente = null/* TODO Change to default(_) if this is not a reference type */;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.Dispose();
        //    }
        //}

        // Incidente IIncidenteRepositorio.Detalhes(int incidenteId)
        //{
        //    try
        //    {
        //        Incidente obj = new Incidente();
        //        obj = db.Incidente.SingleOrDefault(s => s.IdIncidente == incidenteId);
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.Dispose();
        //    }
        //}

        // IEnumerable<Incidente> IIncidenteRepositorio.GetIncidenteDetalhes()
        //{
        //    try
        //    {
        //        IEnumerable<Incidente> lista;
        //        lista = db.Incidente.ToList();
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.Dispose();
        //    }
        //}

        // Incidente IIncidenteRepositorio.GetIncidentePorID(int incidenteId)
        //{
        //    try
        //    {
        //        return db.Incidente.SingleOrDefault(x => x.IdIncidente == incidenteId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.Dispose();
        //    }
        //}
    }
}