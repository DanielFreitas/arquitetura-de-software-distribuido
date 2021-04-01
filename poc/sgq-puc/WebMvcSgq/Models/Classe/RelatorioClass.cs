using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcSgq.Models.Classe
{
    public class RelatorioClass
    {
        public long IdProcesso { get; set; }
        public long IdAtividadeDiaria { get; set; }

        public System.Web.Mvc.SelectList IdProcessos { get; set; }

        public System.Web.Mvc.SelectList IdAtividadeDiarias { get; set; }

        public int DsSelecionado { get; set; }

        public bool IsActive
        {
            get => DsSelecionado > 0;
            set => DsSelecionado = value == true ? 1 : 0;
        }

        public IList<RelatorioProcesso> relatProcesso { get; set; }

    }

    public class RelatorioProcesso
    {
        public string NomeProcesso { get; set; }
        public string NomeAtividadeDiaria { get; set; }
        public string Etapa { get; set; }

        public DateTime? DataCadastro { get; set; }

        public string status { get; set; }

    }

}