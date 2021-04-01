using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class AtividadeDiariaRepositorio : IAtividadeDiariaRepositorio
    {

        db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));
        private IAtividadeDiariaRepositorio repAtiv = null;
        private IProcessoRepositorio repProcesso = null;

        void IAtividadeDiariaRepositorio.AdicionaAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria)
        {
            try
            {
                ativDiaria.Dt_Cadastro = DateTime.Now;
                db.Tbl_Atividade_Diaria.Add(ativDiaria);
                db.SaveChanges();

                repAtiv = new AtividadeDiariaRepositorio();
                repProcesso = new ProcessoRepositorio();

                ativDiaria = db.Tbl_Atividade_Diaria.Where(p => p.IdAtividadeDiaria == ativDiaria.IdAtividadeDiaria).FirstOrDefault();

                tbl_Processo processo = repProcesso.GetProcessoPorID(ativDiaria.IdProcesso.Value);

                foreach (var item in processo.tbl_etapa)
                {
                    tbl_atividades atv = null;
                    atv = ativDiaria.tbl_atividades.Where(p => p.IdAtividadeDiaria == ativDiaria.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault();

                    if (atv == null)
                    {
                        atv = new tbl_atividades();
                        atv.IdEtapa = item.IdEtapa;
                        atv.IdAtividadeDiaria = ativDiaria.IdAtividadeDiaria;
                        atv.DsSelecionado = 0;
                        ativDiaria.tbl_atividades.Add(atv);
                    }
                    else
                    {
                        ativDiaria.tbl_atividades.Where(p => p.IdAtividadeDiaria == ativDiaria.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault().DsSelecionado = 1;
                    }
                }

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
        void IAtividadeDiariaRepositorio.EditarAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria, List<tbl_atividades> listaAtividade)
        {
            try
            {
                var novaAtividade = db.Tbl_Atividade_Diaria.Where(x => x.IdAtividadeDiaria == ativDiaria.IdAtividadeDiaria).FirstOrDefault();
                novaAtividade.Descricao = ativDiaria.Descricao;
                novaAtividade.Dt_Alteracao = DateTime.Now;

                foreach (var item in listaAtividade)
                {
                    tbl_atividades atv = null;
                    atv = novaAtividade.tbl_atividades.Where(p => p.IdAtividadeDiaria == novaAtividade.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault();

                    if (atv == null)
                    {
                        atv = new tbl_atividades();
                        atv.IdEtapa = item.IdEtapa;
                        atv.IdAtividadeDiaria = novaAtividade.IdAtividadeDiaria;
                        atv.DsSelecionado = 0;
                        novaAtividade.tbl_atividades.Add(atv);
                    }
                    else
                    {
                        novaAtividade.tbl_atividades.Where(p => p.IdAtividadeDiaria == novaAtividade.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault().DsSelecionado = 1;
                    }
                }

                db.SaveChanges();
                novaAtividade = null;
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

        void IAtividadeDiariaRepositorio.DeletarAtividadeDiaria(long idAtivDiaria)
        {
            try
            {             
                //List<tbl_Processo> processos = db.tbl_Processo.ToList();

                // Obtem a atividade diaria
                Tbl_Atividade_Diaria _atividadeDiaria = db.Tbl_Atividade_Diaria.SingleOrDefault(x => x.IdAtividadeDiaria == idAtivDiaria);

                //// Obtem o processo que a ativdade diaria esta associada
                //tbl_Processo processo = processos.Where(x => x.IdProcesso == _atividadeDiaria.IdProcesso).FirstOrDefault();

                //// Um processo possui varias etapas
                //List<tbl_etapa> etapas = db.tbl_etapa.Where(x => x.IdProcesso == _atividadeDiaria.IdProcesso).ToList();

                List<tbl_atividades> _atividade = db.tbl_atividades.Where(x => x.IdAtividadeDiaria == idAtivDiaria).ToList(); 

                db.tbl_atividades.RemoveRange(_atividade);
                db.Tbl_Atividade_Diaria.Remove(_atividadeDiaria);
                db.SaveChanges();
                _atividadeDiaria = null;
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

        Tbl_Atividade_Diaria IAtividadeDiariaRepositorio.Detalhes(int idAtivDiaria)
        {
            try
            {
                Tbl_Atividade_Diaria obj = new Tbl_Atividade_Diaria();
                obj = db.Tbl_Atividade_Diaria.Include("tbl_Processo").Include("tbl_Atividades").SingleOrDefault(s => s.IdAtividadeDiaria == idAtivDiaria);
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

        IEnumerable<Tbl_Atividade_Diaria> IAtividadeDiariaRepositorio.GetAtividadeDiaria()
        {
            try
            {
                IEnumerable<Tbl_Atividade_Diaria> lista;
                lista = db.Tbl_Atividade_Diaria.Include("tbl_Processo").ToList();
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

        Tbl_Atividade_Diaria IAtividadeDiariaRepositorio.GetAtividadePorID(long idAtivDiaria)
        {
            try
            {
                return db.Tbl_Atividade_Diaria.Include("tbl_Processo").Include("tbl_Atividades").SingleOrDefault(x => x.IdAtividadeDiaria == idAtivDiaria);
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


        #region Atividade Diaria Repositorio Novo

        AtiviModelView IAtividadeDiariaRepositorio.GetAtividadeDiariaPorID(long idAtivDiaria)
        {
            AtiviModelView amv = new AtiviModelView();
            repProcesso = new ProcessoRepositorio();
            try
            {

                Tbl_Atividade_Diaria tbAd = db.Tbl_Atividade_Diaria.Include("tbl_Processo").Include("tbl_Atividades").SingleOrDefault(x => x.IdAtividadeDiaria == idAtivDiaria);
                AtividadeDiariaClass adc = new AtividadeDiariaClass();
                adc.Descricao = tbAd.Descricao;
                adc.NomeProcesso = tbAd.tbl_Processo.Nome;
                adc.Dt_Alteracao = tbAd.Dt_Alteracao;
                adc.Dt_Cadastro = tbAd.Dt_Cadastro;
                adc.IdAtividade = tbAd.IdAtividadeDiaria;
                adc.IdProcesso = tbAd.IdProcesso.Value;

                tbl_Processo tblProcesso = repProcesso.GetProcessoPorID(tbAd.IdProcesso.Value);
                List<EtapaClass> listaEt = new List<EtapaClass>();

                foreach (var etp in tblProcesso.tbl_etapa.ToList())
                {
                    EtapaClass ec = new EtapaClass();
                    ec.IdEtapa = etp.IdEtapa;
                    ec.Descricao = etp.Descricao;
                    ec.Complemento = etp.Complemento;
                    listaEt.Add(ec);
                }

                List<AtividadeClass> listac  = new List<AtividadeClass>();
                
                foreach (var ativid in tbAd.tbl_atividades.ToList())
                {
                    AtividadeClass acv = new AtividadeClass();
                    acv.IdAtividade = ativid.IdAtividade;
                    acv.IdAtividadeDiaria = ativid.IdAtividadeDiaria.Value;
                    acv.IdEtapa = ativid.IdEtapa.Value;
                    acv.DsEtapa = ativid.tbl_etapa.Descricao;
                    acv.Complemento = ativid.tbl_etapa.Complemento;
                    acv.DsSelecionado = ativid.DsSelecionado.Value;
                    listac.Add(acv);
                }

                amv.atividadeDiaCla = adc;
                amv.atividadeCla = listac;
                amv.etapaCla = listaEt;

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

            return amv;
        }

        void IAtividadeDiariaRepositorio.EditarAtividadeDiaria(AtiviModelView amv)
        {
            try
            {
                Tbl_Atividade_Diaria ad = db.Tbl_Atividade_Diaria.Where(x => x.IdAtividadeDiaria == amv.atividadeDiaCla.IdAtividade).FirstOrDefault();
                ad.Descricao = amv.atividadeDiaCla.Descricao;
                ad.Dt_Alteracao = DateTime.Now;

                foreach (var item in amv.atividadeCla)
                {
                    tbl_atividades atv = null;
                    atv = ad.tbl_atividades.Where(p => p.IdAtividadeDiaria == ad.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault();

                    if (atv == null)
                    {
                        atv = new tbl_atividades();
                        atv.IdEtapa = item.IdEtapa;
                        atv.IdAtividadeDiaria = ad.IdAtividadeDiaria;
                        atv.DsSelecionado = item.DsSelecionado;
                        ad.tbl_atividades.Add(atv);
                    }
                    else
                    {
                        ad.tbl_atividades.Where(p => p.IdAtividadeDiaria == ad.IdAtividadeDiaria && p.IdEtapa == item.IdEtapa).FirstOrDefault().DsSelecionado = item.DsSelecionado;
                    }
                }

                db.SaveChanges();
                ad = null;
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

        #endregion

    }
}