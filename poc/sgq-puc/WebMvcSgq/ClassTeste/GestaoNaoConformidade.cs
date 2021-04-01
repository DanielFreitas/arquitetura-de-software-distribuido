using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoNaoConformidade
    {

        private readonly INaoConformidadeRepositorio _ipr;
        public GestaoNaoConformidade(INaoConformidadeRepositorio proId)
        {
            this._ipr = proId;
        }

        public void AdicionaNaoConformidade(tbl_NaoConformidade naoConformidade)
        {
            _ipr.AdicionaNaoConformidade(naoConformidade);
        }

        public void AtualizaNaoConformidade(tbl_NaoConformidade naoConformidade)
        {
            _ipr.AtualizaNaoConformidade(naoConformidade);
        }

        public tbl_NaoConformidade Detalhes(long naoConformidade)
        {
          return  _ipr.Detalhes(naoConformidade);
        }

        public void DeletaNaoConformidade(long naoConformidade)
        {
             _ipr.DeletaNaoConformidade(naoConformidade);
        }

        public IEnumerable<tbl_NaoConformidade> GetNaoConformidade()
        {
           return _ipr.GetNaoConformidade();
        }

        public IList<NaoConformidades> GetNaoConformidadeRelatorio(ref RelatNaoConformidadeClass relNaoConf)
        {
            return _ipr.GetNaoConformidadeRelatorio(ref relNaoConf);
        }

        public tbl_NaoConformidade GetNaoConformidadePorID(long naoConformidadeId)
        {
            return _ipr.GetNaoConformidadePorID(naoConformidadeId);
        }

    }
}