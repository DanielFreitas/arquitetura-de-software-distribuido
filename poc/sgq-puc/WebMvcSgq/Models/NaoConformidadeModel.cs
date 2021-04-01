using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcSgq.Models
{
    public class NaoConformidadeModel
    {
        public NaoConformidadeModel()
        {
            this.Tbl_NaoConformidade_x_Norma = new HashSet<Tbl_NaoConformidade_x_Norma>();
        }

        public long IdNaoConformidade { get; set; }
        public Nullable<long> IdProcesso { get; set; }
        public Nullable<long> IdAtividadeDiaria { get; set; }
        public string DsNaoConformidade { get; set; }
        public bool Dstatus { get; set; }
        public Nullable<System.DateTime> Dt_Cadastro { get; set; }
        public Nullable<System.DateTime> Dt_Alteracao { get; set; }

        public virtual Tbl_Atividade_Diaria Tbl_Atividade_Diaria { get; set; }
        public virtual tbl_Processo tbl_Processo { get; set; }
        public virtual ICollection<Tbl_NaoConformidade_x_Norma> Tbl_NaoConformidade_x_Norma { get; set; }

        public int NormaId { get; set; }
        public long IdSequencial { get; set; }

    }
}