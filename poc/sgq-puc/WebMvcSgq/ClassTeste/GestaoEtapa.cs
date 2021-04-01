using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoEtapa
    {

        private readonly IEtapaRepositorio _ipr;
        public GestaoEtapa(IEtapaRepositorio proId)
        {
            this._ipr = proId;
        }

        public IEnumerable<tbl_etapa> GetEtapas(long processoId)
        {
            return _ipr.GetEtapas(processoId);
        }

        public tbl_etapa GetEtapaByID(long processoId)
        {
            return _ipr.GetEtapaByID(processoId);
        }

    }
}