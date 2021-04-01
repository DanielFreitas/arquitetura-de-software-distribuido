using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class EtapaRepositorio : IEtapaRepositorio
    {
        db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));

        IEnumerable<tbl_etapa> IEtapaRepositorio.GetEtapas(long processoId)
        {
            try
            {
                IEnumerable<tbl_etapa> lista;
                lista = db.tbl_etapa.Include("tbl_processo").Where(p=> p.IdProcesso == processoId).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        tbl_etapa IEtapaRepositorio.GetEtapaProcessoPorID(long processoId)
        {
            try
            {
                return db.tbl_etapa.Include("tbl_Processo").SingleOrDefault(x => x.IdProcesso == processoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        tbl_etapa IEtapaRepositorio.GetEtapaByID(long etapaId)
        {
            try
            {
                return db.tbl_etapa.Include("tbl_Processo").Where(x => x.IdEtapa == etapaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }


        void IEtapaRepositorio.AdicionaEtapa(tbl_etapa etapa)
        {
            try
            {
                etapa.Dt_Cadastro = DateTime.Now;

                db.tbl_etapa.Add(etapa);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((db == null))
                    db.Dispose();
            }
        }
        void IEtapaRepositorio.AtualizaEtapa(tbl_etapa etapa)
        {
            try
            {
                var novoetapa = db.tbl_etapa.Where(x => x.IdEtapa == etapa.IdEtapa).FirstOrDefault();
                novoetapa.Descricao = etapa.Descricao;
                novoetapa.Dt_Alteração = DateTime.Now;
                novoetapa.Complemento = etapa.Complemento;
                db.SaveChanges();
                novoetapa = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        void IEtapaRepositorio.DeletaEtapa(long etapaId)
        {
            try
            {
                tbl_etapa _etapa = db.tbl_etapa.SingleOrDefault(x => x.IdEtapa == etapaId);
                db.tbl_etapa.Remove(_etapa);
                db.SaveChanges();
                _etapa = null/* TODO Change to default(_) if this is not a reference type */;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        tbl_etapa IEtapaRepositorio.Detalhes(long etapaId)
        {
            try
            {
                tbl_etapa obj = new tbl_etapa();
                obj = db.tbl_etapa.SingleOrDefault(s => s.IdEtapa == etapaId);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        IEnumerable<tbl_etapa> IEtapaRepositorio.GetEtapas()
        {
            try
            {
                IEnumerable<tbl_etapa> lista;
                lista = db.tbl_etapa.Include("tbl_processo").ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }


    }
}