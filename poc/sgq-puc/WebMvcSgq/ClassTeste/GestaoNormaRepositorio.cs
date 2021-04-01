using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoNormaRepositorio
    {
        private readonly INormaRepositorio _inr;
        public GestaoNormaRepositorio(INormaRepositorio proId)
        {
            this._inr = proId;
        }
        public LinksWrapper<Content> GetNormaId(long nId)
        {
            LinksWrapper<Content> proRet = _inr.GetNormaById(nId);
            return proRet;
        }
    }
}