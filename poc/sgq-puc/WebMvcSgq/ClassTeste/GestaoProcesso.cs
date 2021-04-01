using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoProcesso
    {
        private readonly IProcessoRepositorio _ipr;
        public GestaoProcesso(IProcessoRepositorio proId)
        {
            this._ipr = proId;
        }
        public tbl_Processo GetDetalheProcesso(long pro)
        {
            tbl_Processo proRet = _ipr.Detalhes(pro);
            return proRet;
        }

        public void AdicionaProcesso(tbl_Processo pro)
        {
            _ipr.AdicionaProcesso(pro);
        }

        public void AtualizaProcesso(tbl_Processo pro)
        {
            _ipr.AtualizaProcesso(pro);
        }

        public void DeletaProcesso(long pro)
        {
            _ipr.DeletaProcesso(pro);
        }

        public tbl_Processo Detalhes(long pro)
        {
            return _ipr.Detalhes(pro);
        }

        public IEnumerable<tbl_Processo> GetProcessos()
        {
            return _ipr.GetProcessos();
        }

        public IList<RelatorioProcesso> GetProcessoRelatorio(ref RelatorioClass relat)
        {
            return _ipr.GetProcessoRelatorio(ref relat);
        }

        public tbl_Processo GetProcessoPorID(long idPro)
        {
            return _ipr.GetProcessoPorID(idPro);
        }
    }
}