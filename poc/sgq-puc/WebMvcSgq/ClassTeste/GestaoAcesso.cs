using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoAcesso
    {

        private readonly IAcessoRepositorio _ipr;
        public GestaoAcesso(IAcessoRepositorio proId)
        {
            this._ipr = proId;
        }

        public IList<tbl_Acessos> GetAcessosFuncao(long idFuncao)
        {
            IList<tbl_Acessos> acesso = _ipr.GetAcessosFuncao(idFuncao);
            return acesso;
        }

    }
}