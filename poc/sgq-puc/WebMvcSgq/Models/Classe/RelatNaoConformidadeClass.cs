using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcSgq.Models.Classe
{
    public class RelatNaoConformidadeClass
    {
        public long IdProcesso { get; set; }
        public long IdAtividadeDiaria { get; set; }

        public string DsNaoConformidade { get; set; }

        public bool status { get; set; }

        public IList<NaoConformidades> ListaNaoConformidade { get; set; }
    }


    public class NaoConformidades
    {
        public string NomeProcesso { get; set; }
        public string NomeAtividadeDiaria { get; set; }
        public string DsNaoConformidade { get; set; }
        public bool Dstatus { get; set; }

        public DateTime? DataCadastro { get; set; } 

    }
}