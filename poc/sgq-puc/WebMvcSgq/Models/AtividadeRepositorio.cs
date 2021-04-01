using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class AtividadeRepositorio : IAtividadeRepositorio
    {

        db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));

        void IAtividadeRepositorio.SalvarAtividade(tbl_atividades atividade)
        {
            try
            {
                db.tbl_atividades.Add(atividade);
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


        IEnumerable<tbl_atividades> IAtividadeRepositorio.GetAtividade(long idAtividadeDiaria)
        {
            try
            {
                IEnumerable<tbl_atividades> lista;
                lista = db.tbl_atividades.Include("tbl_atividade_Diaria").Include("tbl_etapa").Where(p=> p.IdAtividadeDiaria == idAtividadeDiaria).ToList();
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