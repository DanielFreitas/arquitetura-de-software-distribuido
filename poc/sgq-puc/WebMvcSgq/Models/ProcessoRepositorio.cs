using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class ProcessoRepositorio : IProcessoRepositorio
    {

        db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));

        void IProcessoRepositorio.AdicionaProcesso(tbl_Processo processo)
        {
            try
            {
                processo.Dt_Cadastro = DateTime.Now;

                db.tbl_Processo.Add(processo);
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
        void IProcessoRepositorio.AtualizaProcesso(tbl_Processo processo)
        {
            try
            {
                var novoProcesso = db.tbl_Processo.Where(x => x.IdProcesso == processo.IdProcesso).FirstOrDefault();
                novoProcesso.Nome = processo.Nome;
                processo.Dt_Alteracao = DateTime.Now;
                novoProcesso.Dt_Alteracao = processo.Dt_Alteracao;
                db.SaveChanges();
                novoProcesso = null;
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

        void IProcessoRepositorio.DeletaProcesso(long processoId)
        {
            try
            {
                tbl_Processo _processo = db.tbl_Processo.SingleOrDefault(x => x.IdProcesso == processoId);
                db.tbl_Processo.Remove(_processo);
                db.SaveChanges();
                _processo = null/* TODO Change to default(_) if this is not a reference type */;
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

        tbl_Processo IProcessoRepositorio.Detalhes(long processoId)
        {
            try
            {
                tbl_Processo obj = new tbl_Processo();
                obj = db.tbl_Processo.SingleOrDefault(s => s.IdProcesso == processoId);
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

        IEnumerable<tbl_Processo> IProcessoRepositorio.GetProcessos()
        {
            try
            {
                IEnumerable<tbl_Processo> lista;
                lista = db.tbl_Processo.ToList();
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


        IList<RelatorioProcesso> IProcessoRepositorio.GetProcessoRelatorio(ref RelatorioClass relat)
        {
            try
            {
                tbl_Processo processo;
                long IdProcesso = relat.IdProcesso;
                long IdAtividadeDiaria = relat.IdAtividadeDiaria;
                //int DsSeleci = relat.IsActive ? 1 : 0;

                IList<RelatorioProcesso> listProcesso = new List<RelatorioProcesso>();

                using (var dbs = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString")))
                {
                    processo = dbs.tbl_Processo.Include("tbl_Atividade_Diaria").Include("tbl_etapa").Where(p => p.IdProcesso == IdProcesso).FirstOrDefault();

                    if (processo != null)
                    {
                        Tbl_Atividade_Diaria ativDiaria = processo.Tbl_Atividade_Diaria.Where(p => p.IdAtividadeDiaria == IdAtividadeDiaria).FirstOrDefault();

                        if (ativDiaria != null)
                        {
                            foreach (var p in ativDiaria.tbl_atividades.Where(p => p.tbl_etapa.IdProcesso == IdProcesso).ToList())
                            {
                                RelatorioProcesso rp = new RelatorioProcesso();
                                rp.NomeProcesso = processo.Nome;
                                rp.DataCadastro = (processo.Dt_Cadastro != null ? processo.Dt_Cadastro.Value : DateTime.MinValue);
                                rp.NomeAtividadeDiaria = ativDiaria.Descricao;
                                rp.Etapa = p.tbl_etapa.Descricao;
                                rp.status = (p.DsSelecionado == 1 ? "Concluído" : "Em andamento");

                                listProcesso.Add(rp);
                            }

                            relat.relatProcesso = listProcesso;
                            return relat.relatProcesso;
                        }

                    }

                }

                return listProcesso;
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

        tbl_Processo IProcessoRepositorio.GetProcessoPorID(long processoId)
        {
            try
            {
                return db.tbl_Processo.Include("tbl_etapa").SingleOrDefault(x => x.IdProcesso == processoId);
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