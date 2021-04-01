using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoAtividade
    {
        private readonly IAtividadeRepositorio _ipr;
        public GestaoAtividade(IAtividadeRepositorio proId)
        {
            this._ipr = proId;
        }

        public void SalvarAtividade(tbl_atividades ativ)
        {
            _ipr.SalvarAtividade(ativ);
        }

        public IEnumerable<tbl_atividades> GetAtividade(long idAtividadeDiaria)
        {
           IEnumerable<tbl_atividades> list = _ipr.GetAtividade(idAtividadeDiaria);
            return list;
        }

    }
}